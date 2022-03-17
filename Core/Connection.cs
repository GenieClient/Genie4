using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient.Genie
{
    public class Connection
    {

        public event EventConnectedEventHandler EventConnected;

        public delegate void EventConnectedEventHandler();

        public event EventDisconnectedEventHandler EventDisconnected;

        public delegate void EventDisconnectedEventHandler();

        public event EventDataSentEventHandler EventDataSent;

        public delegate void EventDataSentEventHandler();

        public event EventDataRecieveEndEventHandler EventDataRecieveEnd;

        public delegate void EventDataRecieveEndEventHandler();

        public event EventParseRowEventHandler EventParseRow;

        public delegate void EventParseRowEventHandler(StringBuilder row);

        public event EventParsePartialRowEventHandler EventParsePartialRow;

        public delegate void EventParsePartialRowEventHandler(string row);

        public event EventPrintTextEventHandler EventPrintText;

        public delegate void EventPrintTextEventHandler(string text);

        public event EventPrintErrorEventHandler EventPrintError;

        public delegate void EventPrintErrorEventHandler(string text);

        public event EventConnectionLostEventHandler EventConnectionLost;

        public delegate void EventConnectionLostEventHandler();

        public enum SocketErrorCodes
        {
            InterruptedFunctionCall = 10004,
            PermissionDenied = 10013,
            BadAddress = 10014,
            InvalidArgument = 10022,
            TooManyOpenFiles = 10024,
            ResourceTemporarilyUnavailable = 10035,
            OperationNowInProgress = 10036,
            OperationAlreadyInProgress = 10037,
            SocketOperationOnNonSocket = 10038,
            DestinationAddressRequired = 10039,
            MessgeTooLong = 10040,
            WrongProtocolType = 10041,
            BadProtocolOption = 10042,
            ProtocolNotSupported = 10043,
            SocketTypeNotSupported = 10044,
            OperationNotSupported = 10045,
            ProtocolFamilyNotSupported = 10046,
            AddressFamilyNotSupported = 10047,
            AddressInUse = 10048,
            AddressNotAvailable = 10049,
            NetworkIsDown = 10050,
            NetworkIsUnreachable = 10051,
            NetworkReset = 10052,
            ConnectionAborted = 10053,
            ConnectionResetByPeer = 10054,
            NoBufferSpaceAvailable = 10055,
            AlreadyConnected = 10056,
            NotConnected = 10057,
            CannotSendAfterShutdown = 10058,
            ConnectionTimedOut = 10060,
            ConnectionRefused = 10061,
            HostIsDown = 10064,
            HostUnreachable = 10065,
            TooManyProcesses = 10067,
            NetworkSubsystemIsUnavailable = 10091,
            UnsupportedVersion = 10092,
            NotInitialized = 10093,
            ShutdownInProgress = 10101,
            ClassTypeNotFound = 10109,
            HostNotFound = 11001,
            HostNotFoundTryAgain = 11002,
            NonRecoverableError = 11003,
            NoDataOfRequestedType = 11004
        }

        private TcpClient _client;
        private const int MAX_PACKET_SIZE = 2048;
        private SslStream sslStream;

        private Socket m_SocketClient;
        private IPEndPoint m_IPEndPoint;
        private StringBuilder m_ParseBuffer = new StringBuilder();
        private StringBuilder m_RowBuffer = new StringBuilder();
        private DateTime m_oLastServerActivity = DateTime.Now;

        public DateTime LastServerActivity
        {
            get
            {
                return m_oLastServerActivity;
            }
        }

        public bool IsConnected
        {
            get
            {
                if (Information.IsNothing(m_SocketClient))
                {
                    return false;
                }
                else
                {
                    if(_client != null) return _client.Connected;
                    return m_SocketClient.Connected;
                }
            }
        }

        private string m_sHostname = string.Empty;

        public void Connect(string sHostname, int iPort)
        {
            try
            {
                m_RowBuffer.Clear(); // Reset row buffer
                m_ParseBuffer.Clear(); // Reset parse buffer
                if (!Information.IsNothing(m_SocketClient))
                {
                    if (m_SocketClient.Connected == true)
                    {
                        m_SocketClient.Disconnect(false);
                    }

                    m_SocketClient = null;
                }

                m_sHostname = sHostname;
                _client = new TcpClient();
                m_SocketClient = _client.Client;
                _client.Connect(sHostname, iPort);
                m_oLastServerActivity = DateTime.Now;
                PrintText(Utility.GetTimeStamp() + " Connected to " + m_sHostname + ".");
                Recieve(_client);
                EventConnected?.Invoke();
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connect failed", ex.ErrorCode);
                EventConnectionLost?.Invoke();
            }
        }

        public void ConnectAndAuthenticate(string sHostname, int iPort)
        {
            try
            {
                m_RowBuffer.Clear(); // Reset row buffer
                m_ParseBuffer.Clear(); // Reset parse buffer
                if (!Information.IsNothing(m_SocketClient))
                {
                    if (m_SocketClient.Connected == true)
                    {
                        m_SocketClient.Disconnect(false);
                    }

                    m_SocketClient = null;
                }

                m_sHostname = sHostname;
                _client = new TcpClient();
                m_SocketClient = _client.Client;
                
                var hostEntryList = Dns.GetHostEntry(sHostname);
                m_IPEndPoint = new IPEndPoint(hostEntryList.AddressList.Where(i => i.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault(), iPort);
                _client.Connect(sHostname, iPort);
                m_oLastServerActivity = DateTime.Now;
                try
                {
                    sslStream = new SslStream(_client.GetStream(), true, new RemoteCertificateValidationCallback(Utility.ValidateServerCertificate), null);
                    try
                    {
                        sslStream.AuthenticateAsClient(m_sHostname, null, SslProtocols.Tls12, false);
                    }
                    catch (AuthenticationException e)
                    {
                        PrintError("Unable to Authenticate: " + e.Message);
                        _client.Close();
                    }
                    // Complete the connection
                    
                    PrintText(Utility.GetTimeStamp() + " Connected to " + m_sHostname + ".");
                    
                    EventConnected?.Invoke();
                }
                catch (SocketException ex)
                {
                    PrintSocketError("Connect failed", ex.ErrorCode);
                    EventConnectionLost?.Invoke();
                }
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connect failed", ex.ErrorCode);
                EventConnectionLost?.Invoke();
            }
        }
        public enum AuthState
        {
            Disconnected,
            Unauthenticated,
            ListeningForKey,
            KeyAuthenticated,
            Authenticated,
            AuthenticationFailed,
            InvalidResponse
        }
        private AuthState CurrentAuthState = AuthState.Unauthenticated;
        public AuthState Authenticate(string account, string password)
        {
            if (!_client.Connected || sslStream == null)
            {
                CurrentAuthState = AuthState.Disconnected;
                return CurrentAuthState; //not connected
            }
            else if (account == null || password == null)
            {
                CurrentAuthState = AuthState.Unauthenticated;
                return CurrentAuthState; //No credentials provided.
            }
            else
            {
                // Send K - Key Request
                byte[] message = Encoding.Default.GetBytes("K" + Environment.NewLine);
                sslStream.Write(message);
                sslStream.Flush();

                CurrentAuthState = AuthState.ListeningForKey;
                // Read Key response: should be 32 bytes
                byte[] buffer = new byte[MAX_PACKET_SIZE];
                int bytes = sslStream.Read(buffer, 0, buffer.Length);
                if (bytes != 32)
                {
                    sslStream.Close();
                    CurrentAuthState = AuthState.InvalidResponse;
                }

                // SslStreams require a byte array to write
                // BlockCopy is used to allow concacatantion, and avoid encoding issues from cyte array -> string -> byte array.
                message = new byte[account.Length + password.Length + 3];
                Buffer.BlockCopy(Encoding.Default.GetBytes("A\t" + account.ToUpper() + "\t"), 0, message, 0, account.Length + 3);
                Buffer.BlockCopy(Utility.EncryptText(buffer, password), 0, message, account.Length + 3, password.Length);
                sslStream.Write(message);
                sslStream.Flush();

                // null out password to not keep it in memory longer than necessary
                password = null;

                buffer = new byte[MAX_PACKET_SIZE];
                _ = sslStream.Read(buffer, 0, buffer.Length);

                if (Encoding.Default.GetString(buffer).Contains("\tKEY\t"))
                {
                    CurrentAuthState = AuthState.KeyAuthenticated;
                }
                else
                {
                    sslStream.Close();
                    CurrentAuthState = AuthState.AuthenticationFailed;
                }
            }
            return CurrentAuthState;
            

            
        }

        public string GetLoginKey(string instance, string character)
        {
                        // Sanity checks
            if (!IsConnected || sslStream == null)
            {
                return "E\tThe connection was lost.";
            }
            
            if (string.IsNullOrWhiteSpace(instance))
            {
                return "E\tThe game instance was not specified.";
            }

            if (CurrentAuthState == AuthState.AuthenticationFailed)
            {
                return "E\tAuthentication Failed.";
            }

            // Send G - Game Details Request
            byte[] message = Encoding.Default.GetBytes("G\t" + instance.ToUpper());
            sslStream.Write(message);
            sslStream.Flush();

            // Read response: 
            byte[] buffer = new byte[MAX_PACKET_SIZE];
            _ = sslStream.Read(buffer, 0, buffer.Length);

            //Validate Access - list of status responses:
            // Known good status:
            //  "FREE_TO_PLAY" "PAYING" "PREMIUM" "NORMAL"
            // Known bad status:
            //  "NEW_TO_GAME" "EXPIRED"
            // Unknown status:
            //  "BETA" "FREE" "INTERNAL" "NEED_BILL" "NO_ACCESS" "SHAREWARE" "TRIAL" "UNKNOWN"
            //Check for  match of known good status, and if no match, no access to requested instance
            if (Encoding.Default.GetString(buffer).TrimEnd('\0').ToUpper() == "PROBLEM")
            {
                sslStream.Close();
                CurrentAuthState = AuthState.Disconnected;
                return "E\tThere is a problem with your account. Please log in to the play.net website for more information.";
            }

            // send C - Character Slot Request
            message = Encoding.Default.GetBytes("C");
            sslStream.Write(message);
            sslStream.Flush();

            // Read response: 
            buffer = new byte[MAX_PACKET_SIZE];
            _ = sslStream.Read(buffer, 0, buffer.Length);

            string characterResponse = Encoding.Default.GetString(buffer).TrimEnd('\0').ToUpper();
            // Requesting character list with no character name given
            if (string.IsNullOrWhiteSpace(character))
            {
                sslStream.Close();
                CurrentAuthState = AuthState.Disconnected;
                return characterResponse;
            }
            
            // Looking for specific character to get login key for
            List<string> characterKeys = characterResponse.Split('\t').ToList<string>();
            string characterKey = string.Empty;
            string lastKey = string.Empty;
            foreach(string key in characterKeys)
            {
                if (key.ToUpper().Equals(character.ToUpper()))
                {
                    characterKey = lastKey;
                    break;
                }
                else
                {
                    lastKey = key;
                }
            }
            
            if (string.IsNullOrWhiteSpace(characterKey))
            {
                sslStream.Close();
                CurrentAuthState = AuthState.Disconnected;
                return "E\tThe specified character was not found: " + character + ".";
            }

            //send L - Login Key Request
            message = Encoding.Default.GetBytes("L\t" + characterKey + "\tSTORM");
            sslStream.Write(message);
            sslStream.Flush();

            //Read response: 
            buffer = new byte[MAX_PACKET_SIZE];
            CurrentAuthState = AuthState.Authenticated;
            _ = sslStream.Read(buffer, 0, buffer.Length);
            
            sslStream.Close();
            string loginKey = Encoding.Default.GetString(buffer);
            return loginKey;
        }

        public void Disconnect(bool ExitOnDisconnect = false)
        {
            Disconnect(m_SocketClient, ExitOnDisconnect);
        }

        public void Send(string sText)
        {
            Send(m_SocketClient, sText);
        }

        public void Send(byte[] bytes)
        {
            Send(m_SocketClient, bytes);
        }

        private void Disconnect(Socket ConnectedSocket, bool ExitOnDisconnect = false)
        {
            if (Information.IsNothing(ConnectedSocket))
            {
                return;
            }

            if (ConnectedSocket.Connected == true)
            {
                // PrintText("Disconnecting from: " & s.RemoteEndPoint.ToString())

                ConnectedSocket.BeginDisconnect(false, new AsyncCallback(DisconnectCallback), new object[] { ConnectedSocket, ExitOnDisconnect });
            }

            m_SocketClient = null;
        }

        private void DisconnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object
                Socket s = (Socket)(ar.AsyncState as object[])[0];
                bool ExitOnDisconnect = (bool)(ar.AsyncState as object[])[1];
                // Complete the connection
                s.EndDisconnect(ar);
                ParseData(System.Environment.NewLine); // Show lines not yet sent out
                PrintText(Utility.GetTimeStamp() + " Connection closed.");
                if (ExitOnDisconnect)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    EventDisconnected?.Invoke();
                }
                
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connection lost", ex.ErrorCode);
            }
        }

        private void Send(Socket s, string sText)
        {
            try
            {
                if (Information.IsNothing(s) == true)
                {
                    return;
                }

                if (s.Connected == false)
                {
                    return;
                }

                var ByteData = Encoding.Default.GetBytes(sText);
                s.BeginSend(ByteData, 0, ByteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), s);
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connection failure", ex.ErrorCode);
            }
        }

        private void Send(Socket s, byte[] ByteData)
        {
            try
            {
                if (Information.IsNothing(s) == true)
                {
                    return;
                }

                if (s.Connected == false)
                {
                    return;
                }

                s.BeginSend(ByteData, 0, ByteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), s);
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connection failure", ex.ErrorCode);
            }
        }
        
        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket s = (Socket)ar.AsyncState;
                int bytes = s.EndSend(ar);
                if (bytes > 0)
                {
                    EventDataSent?.Invoke();
                }
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connection failure", ex.ErrorCode);
            }
        }

        private class StateObject
        {
            // Client socket
            public TcpClient oSocketRef;
            // Size of recieve Buffer
            public const int iBufferSize = 10240;
            // Recieve Buffer
            public byte[] oBuffer = new byte[10241];
        }

        private void Recieve(TcpClient s)
        {
            try
            {
                var oState = new StateObject();
                oState.oSocketRef = s;
                s.Client.BeginReceive(oState.oBuffer, 0, StateObject.iBufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), oState);
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connection lost", ex.ErrorCode);
                EventConnectionLost?.Invoke();
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            m_oLastServerActivity = DateTime.Now;
            try
            {
                StateObject oState = (StateObject)ar.AsyncState;
                TcpClient s = oState.oSocketRef;
                if (s.Connected == true)
                {
                    int bytes = s.Client.EndReceive(ar);
                    if (bytes > 0)
                    {
                        if(CurrentAuthState == AuthState.ListeningForKey || CurrentAuthState == AuthState.KeyAuthenticated)
                        {
                            return;
                        }
                        // Append data
                        ParseData(Encoding.Default.GetString(oState.oBuffer, 0, bytes));
                        // Event to update Output
                        DataRecieveEnd();

                        // Get the rest of the data.
                        s.Client.BeginReceive(oState.oBuffer, 0, StateObject.iBufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), oState);
                    }
                    else
                    {
                        // Disconnect
                        Disconnect();
                        EventConnectionLost?.Invoke();
                    }
                }
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connection lost", ex.ErrorCode);
                EventConnectionLost?.Invoke();
            }
        }

        private void ParseData(string sText)
        {
            char lastchar = 'x';
            foreach (char c in sText)
            {
                if (c == '\r' || (c == '\n' && lastchar != '\r'))
                {
                    m_RowBuffer.Append(m_ParseBuffer);
                    m_RowBuffer.Append(System.Environment.NewLine);
                    ParseRow(m_RowBuffer); // Event for parse row
                    m_RowBuffer.Clear();
                    m_ParseBuffer.Clear();
                }
                else if (Conversions.ToString(c) != Constants.vbLf & c != '\a')
                {
                    m_ParseBuffer.Append(c);
                }
                lastchar = c;
            }

            // Broken Line (Print and save result to RowBuffer)
            if (m_ParseBuffer.Length > 0)
            {
                var buffer = m_ParseBuffer.ToString();
                ParsePartialRow(buffer);	// Event for partial parse row
                m_RowBuffer.Append(m_ParseBuffer);
                m_ParseBuffer.Clear();
            }
        }

        private void ParseRow(StringBuilder oText)
        {
            // For Trigger Events
            EventParseRow?.Invoke(oText);
        }

        private void ParsePartialRow(string sText)
        {
            // For Key Server & Handshake
            EventParsePartialRow?.Invoke(sText);
        }

        private void PrintText(string sText)
        {
            EventPrintText?.Invoke(sText + System.Environment.NewLine);
            EventDataRecieveEnd?.Invoke();
        }

        private void PrintError(string sText)
        {
            EventPrintError?.Invoke(sText + System.Environment.NewLine);
            EventDataRecieveEnd?.Invoke();
        }

        private void DataRecieveEnd()
        {
            EventDataRecieveEnd?.Invoke();
        }

        private void PrintSocketError(string text, int errorcode)
        {
            SocketErrorCodes sec = (SocketErrorCodes)errorcode;
            PrintError(Conversions.ToString(Utility.GetTimeStamp() + " " + text + ". (" + Interaction.IIf(Information.IsNothing(sec), "Unknown", sec.ToString()) + ")"));
        }
    }
}