using System;
using System.Net;
using System.Net.Sockets;
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
                    return m_SocketClient.Connected;
                }
            }
        }

        private string m_sHostname = string.Empty;

        public void Connect(string sHostname, int iPort)
        {
            try
            {
                // PrintText("Connecting to: " & sHostname & ":" & iPort.ToString())

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
                m_SocketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                m_IPEndPoint = new IPEndPoint(Dns.GetHostEntry(sHostname).AddressList[0], iPort);
                m_SocketClient.BeginConnect(m_IPEndPoint, new AsyncCallback(ConnectCallback), m_SocketClient);
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connect failed", ex.ErrorCode);
                EventConnectionLost?.Invoke();
            }
        }

        public void Disconnect()
        {
            Disconnect(m_SocketClient);
        }

        public void Send(string sText)
        {
            Send(m_SocketClient, sText);
        }

        public void Send(byte[] bytes)
        {
            Send(m_SocketClient, bytes);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            m_oLastServerActivity = DateTime.Now;
            try
            {
                // Retrieve the socket from the state object
                Socket s = (Socket)ar.AsyncState;

                // Complete the connection
                s.EndConnect(ar);
                PrintText(Utility.GetTimeStamp() + " Connected to " + m_sHostname + ".");
                Recieve(s);
                EventConnected?.Invoke();
            }
            catch (SocketException ex)
            {
                PrintSocketError("Connect failed", ex.ErrorCode);
                EventConnectionLost?.Invoke();
            }
        }

        private void Disconnect(Socket s)
        {
            if (Information.IsNothing(s))
            {
                return;
            }

            if (s.Connected == true)
            {
                // PrintText("Disconnecting from: " & s.RemoteEndPoint.ToString())

                s.BeginDisconnect(false, new AsyncCallback(DisconnectCallback), s);
            }

            m_SocketClient = null;
        }

        private void DisconnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object
                Socket s = (Socket)ar.AsyncState;

                // Complete the connection
                s.EndDisconnect(ar);
                ParseData(Constants.vbNewLine); // Show lines not yet sent out
                PrintText(Utility.GetTimeStamp() + " Connection closed.");
                EventDisconnected?.Invoke();
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
            public Socket oSocketRef;
            // Size of recieve Buffer
            public const int iBufferSize = 10240;
            // Recieve Buffer
            public byte[] oBuffer = new byte[10241];
        }

        private void Recieve(Socket s)
        {
            try
            {
                var oState = new StateObject();
                oState.oSocketRef = s;
                s.BeginReceive(oState.oBuffer, 0, StateObject.iBufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), oState);
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
                var s = oState.oSocketRef;
                if (s.Connected == true)
                {
                    int bytes = s.EndReceive(ar);
                    if (bytes > 0)
                    {
                        // Append data
                        ParseData(Encoding.Default.GetString(oState.oBuffer, 0, bytes));
                        // Event to update Output
                        DataRecieveEnd();

                        // Get the rest of the data.
                        s.BeginReceive(oState.oBuffer, 0, StateObject.iBufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallback), oState);
                    }
                    else
                    {
                        // Disconnect
                        Disconnect(s);
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
            foreach (char c in sText)
            {
                if (Conversions.ToString(c) == Constants.vbCr)
                {
                    m_RowBuffer.Append(m_ParseBuffer);
                    m_RowBuffer.Append(Constants.vbNewLine);
                    ParseRow(m_RowBuffer); // Event for parse row
                    m_RowBuffer.Clear();
                    m_ParseBuffer.Clear();
                }
                else if (Conversions.ToString(c) != Constants.vbLf & c != '\a')
                {
                    m_ParseBuffer.Append(c);
                }
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
            EventPrintText?.Invoke(sText + Constants.vbNewLine);
            EventDataRecieveEnd?.Invoke();
        }

        private void PrintError(string sText)
        {
            EventPrintError?.Invoke(sText + Constants.vbNewLine);
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