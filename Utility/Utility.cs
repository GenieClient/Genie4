using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;




namespace GenieClient
{
    public class Utility
    {
        public static string GetTimeStamp()
        {
            return "[" + Strings.FormatDateTime(DateAndTime.Now, DateFormat.ShortTime) + "]";
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        public static bool ExecuteProcess(string sFileName, string sArguments, bool closeProcess = true)
        {
            var myProcess = new Process();
            var myProcessStartInfo = new ProcessStartInfo(sFileName);
            myProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcessStartInfo.CreateNoWindow = true;
            myProcessStartInfo.UseShellExecute = true;
            myProcessStartInfo.RedirectStandardOutput = false;
            myProcessStartInfo.Arguments = sArguments;
            myProcess.StartInfo = myProcessStartInfo;
            FileInfo monitor = new FileInfo(sFileName);
            do
            {
                Thread.Sleep(10);
            } while (FileIsLocked(monitor));
            myProcess.Start();
            // var myStreamReader = myProcess.StandardOutput;
            // Read the standard output of the spawned process.
            if (closeProcess)
            {
                while (myProcess.HasExited == false)
                    Thread.Sleep(10);
                myProcess.Close();
            }
            return default;
        }

        private static bool FileIsLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        public static bool ValidateRegExp(string sRegExp)
        {
            try
            {
                var re = new Regex(sRegExp);
                return true;
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                return false;
            }
        }

        public static byte[] EncryptText(string sKey, string sText)
        {
            byte[] byteBuffer = new byte[sText.Length];
            for(int i = 0; i < sText.Length; i++)
            {
                byteBuffer[i] = (byte)((sKey[i] ^ sText[i] - 32) + 32);
            }
            return byteBuffer;
        }

        public static byte[] EncryptText(byte[] bKey, string sText)
        {
            byte[] byteBuffer = new byte[sText.Length];
            for (int i = 0; i < sText.Length; i++)
            {
                byteBuffer[i] = (byte)(((sText[i] - 32) ^ bKey[i]) + 32);
            }
            return byteBuffer;
        }

        public static bool ValidateServerCertificate(object sender, X509Certificate server_certificate, X509Chain chain, SslPolicyErrors reportedSSLPolicyErrors)
        {
            X509Certificate auth_cert = new X509Certificate(Encoding.Default.GetBytes("-----BEGIN CERTIFICATE-----\nMIIFUDCCAzigAwIBAgIJAP1LKTzYRs74MA0GCSqGSIb3DQEBCwUAMDwxCzAJBgNV\nBAYTAlVTMREwDwYDVQQIDAhNaXNzb3VyaTEaMBgGA1UECgwRU2ltdXRyb25pY3Mg\nQ29ycC4wIBcNMTgwNzE2MjIzNjMyWhgPMzAxNzExMTYyMjM2MzJaMDwxCzAJBgNV\nBAYTAlVTMREwDwYDVQQIDAhNaXNzb3VyaTEaMBgGA1UECgwRU2ltdXRyb25pY3Mg\nQ29ycC4wggIiMA0GCSqGSIb3DQEBAQUAA4ICDwAwggIKAoICAQD3IDOqTKtc+RmW\nZkv3isBPtqKD8rcTyjWFLzIazYnN7ZGmRMGtBTFATx4ugy1WiLih9pUOo84W5M7i\nMwZlbzxQAUPiRfX3U7xowe5LuzDHSxqWzylkkgmkdCX9K8JoN4FnuIWUMuMji7f/\ncY7eL/Flob6pFMD9U7NZDvVpYH05Fnn0LAsaK0DKtPcms5+EWNh+uYgTjZbaVMyY\nAPTEN8Rh0NpR8CWNqErM6kbt+4NBqzKMIrJEfSSgQHhkXK+r37O+d3rpmgyFFJPl\nfFHlwxEKutdhd5z0MWV/Fj+hc2p0pExy6yDJNYDgI+iMas5aYowtOgHx2sX+pGkc\nCYgBkAyhAmhCja0Nl/TEbOgksnSvwGLWufc+TF89CZMGI7UmRdez/YKc0DR/zhjF\nAPsMur8wJOtps9ZueYqTqJ9SvwRoRT8Nlz0q/891t7P97rZ/+9C1AVJFtuIp3zM4\nGusqdxRqAsgVrgZmsY7FPti8dNTDcv1ZUiFt/FfHGEyJXbt7oYDr1CDAX17KRcc3\nFK9XaChz4VNlLGCYbCjMdPIqTP4M4xdma2bBMza4Nmr1qioDO27wa9zBiSe3Mskg\ntUm1cBmZ7eDfGprmMzg4FKY3WEBHQQINyuh9UNfqIijgAiPw4GN7jCpV3YH3mPRP\nHKlRSkfq8DxD5SXVV0+DyRslzLuDEQIDAQABo1MwUTAdBgNVHQ4EFgQUFNOI3jnn\nfZpGE12nVsE9QTgX2IQwHwYDVR0jBBgwFoAUFNOI3jnnfZpGE12nVsE9QTgX2IQw\nDwYDVR0TAQH/BAUwAwEB/zANBgkqhkiG9w0BAQsFAAOCAgEAPh0dOcZ4F2hQzwwr\nigLaY1p3fnjuGxnESwCPxJ3X+HVNclBh4Z3ndoonKunA+7CSxR9R4+ls/8RMmmr2\nQymzWYHTNbpe1dX+NgZGRTKiZEjqr8O0P02YEiLEUwG3YoWBSuka83LEDb+cB9AT\nUz90i1FMhGy9h+nBtP0r+mToQOnoKREmSoN03ucPVauionxAb7EqGlKciIyu4UE5\nuFY0kr5FqCIINtVIozyN2Xn/ATu6W5BlqET/PWapRa0230Pa6e3EKXVvjLxcMa2x\nyv+Pi/UQmMtpZXBu5qeYOPdppJs5WM33Q9PsCH7zGHziTbX85bhXIy1Y5TaGGjGK\nZZ/Je3zBn1JbyP+lC/DhRBpVwAbHqFCudxdSG4qcLR4r2hmTO8+LShXONmoH6XbR\nYwlb9aBrEYSr1cTrBnsFm07Bw3Ou9qXLfcF2nyT37U+DU8B9dcTll+Q1OPgYVbqG\nVfW7ZYQvvxb7EbXPcYedjGn1ZTGwJ5HRhJB0wNcH6wJIqw3y85hsqGFyw4zPOnDV\nZx2fEiycV6+6T8OIk2cwhZDcI0BI1iqKkRUdMLnVV/e3M9jERis1ValbeDVV+/8b\nLk71vz0A0lktJcULiMHWrym3IL7NTjuoZBJD8jgHETi4UEa0IB+Z7/Qr8F+UIygn\nAfksN019Wv0yPmHgubaJB2AT4ic=\n-----END CERTIFICATE-----"));

            //SIMU uses self signed cert, if these are equal, OK.
            if (auth_cert.Equals(server_certificate))
                return true;

            // Assuming they switch at some point to CA Signed this code should be used
            //if (reportedSSLPolicyErrors == SslPolicyErrors.None)
            //    return true;

            Console.WriteLine("Certificate error: {0}", reportedSSLPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
        public static string GenerateAccountHash(string sText)
        {
            string argsText = GenerateHashSHA256(sText);
            return GenerateHashSHA512(argsText);
        }

        public static string GenerateKeyHash(string sText)
        {
            string argsText = GenerateHashSHA512(sText);
            return GenerateHashSHA256(argsText);
        }

        public static string GenerateHashSHA512(string sText)
        {
            if (sText.Length == 0)
                return string.Empty;
            Crypto.EncryptionAlgorithm = Crypto.Algorithm.SHA512;
            Crypto.Encoding = Crypto.EncodingType.HEX;
            if (Crypto.GenerateHash(sText))
            {
                return Crypto.Content;
            }
            else
            {
                throw new Exception(Crypto.CryptoException.Message);
            }
            // Crypto.Clear();
        }

        public static string GenerateHashSHA256(string sText)
        {
            if (sText.Length == 0)
                return string.Empty;
            Crypto.EncryptionAlgorithm = Crypto.Algorithm.SHA256;
            Crypto.Encoding = Crypto.EncodingType.HEX;
            if (Crypto.GenerateHash(sText))
            {
                return Crypto.Content;
            }
            else
            {
                throw new Exception(Crypto.CryptoException.Message);
            }

            // Crypto.Clear();
        }

        public static string EncryptString(string sPassword, string sText)
        {
            if (sText.Length == 0)
                return string.Empty;
            Crypto.EncryptionAlgorithm = Crypto.Algorithm.Rijndael;
            Crypto.Encoding = Crypto.EncodingType.HEX;
            Crypto.Key = sPassword;
            if (Crypto.EncryptString(sText))
            {
                return Crypto.Content;
            }
            else
            {
                throw new Exception(Crypto.CryptoException.Message);
            }

            // Crypto.Clear();
        }

        public static string DecryptString(string sPassword, string sText)
        {
            if (sText.Length == 0)
                return string.Empty;
            Crypto.EncryptionAlgorithm = Crypto.Algorithm.Rijndael;
            Crypto.Encoding = Crypto.EncodingType.HEX;
            Crypto.Key = sPassword;
            Crypto.Content = sText;
            if (Crypto.DecryptString())
            {
                return Crypto.Content;
            }
            else
            {
                throw new Exception(Crypto.CryptoException.Message);
            }

            // Crypto.Clear();
        }

        public static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max + 1);
        }

        public static string TranslateHTMLChar(string sText)
        {
            switch (sText)
            {
                case "&quot;":
                    {
                        return "\"";
                    }

                case "&amp;":
                    {
                        return "&";
                    }

                case "&lt;":
                    {
                        return "<";
                    }

                case "&gt;":
                    {
                        return ">";
                    }

                case "&nbsp;":
                    {
                        return " ";
                    }

                default:
                    {
                        Debug.Print("Found unknown HTML character \"" + sText + "\"" + System.Environment.NewLine);
                        return "";
                    }
            }
        }

        public static int GetTimeDiffInSeconds(DateTime oDateStart, DateTime oDateEnd)
        {
            if (Information.IsNothing(oDateStart) | Information.IsNothing(oDateEnd))
            {
                return 0;
            }

            var span = oDateEnd - oDateStart;
            return Conversions.ToInteger(span.TotalSeconds);
        }

        public static double GetTimeDiffInMilliseconds(DateTime oDateStart, DateTime oDateEnd)
        {
            if (Information.IsNothing(oDateStart) | Information.IsNothing(oDateEnd))
            {
                return 0;
            }

            var span = oDateEnd - oDateStart;
            return span.TotalMilliseconds;
        }

        public static string ArrayToString(Genie.Collections.ArrayList oList)
        {
            string sReturnText = string.Empty;
            foreach (string sText in oList)
                sReturnText += sText + " ";
            return sReturnText.Trim();
        }

        public static int BooleanToInteger(bool b)
        {
            if (b == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // Copy of the above to confuse hackers
        public static string GenerateAccountHashSecond(string sText)
        {
            string argsText = GenerateHashSHA256(sText);
            return GenerateHashSHA512(argsText);
        }

        public static Genie.Collections.ArrayList ParseArgs(string sText, bool bTreatUnderscoreAsSpace = false)
        {
            var oList = new Genie.Collections.ArrayList();
            try
            {
                bool bInsideString = false;
                var cInsideStringChar = default(char);
                int iBracketDepth = 0;
                bool bEscapeChar = false;
                char ch;
                int l = 0;
                int sp = 0;
                for (int cp = 0, loopTo = sText.Length - 1; cp <= loopTo; cp++)
                {
                    ch = sText[cp];
                    if (bEscapeChar == true)
                    {
                        bEscapeChar = false;
                    }
                    else if (bInsideString == true)
                    {
                        if (ch == cInsideStringChar)
                        {
                            bInsideString = false;
                        }
                    }
                    else if (ch == '"') // Or ch = "'"c
                    {
                        bInsideString = true;
                        cInsideStringChar = ch;
                    }
                    else if (ch == '{')
                    {
                        if (iBracketDepth == 0)
                        {
                            l = cp - sp;
                            if (l > 0)
                            {
                                string argsText2 = sText.Substring(sp, l);
                                AddArrayItem(oList, argsText2, Conversions.ToBoolean(Interaction.IIf(oList.Count > 0, bTreatUnderscoreAsSpace, false)));
                            }

                            sp = cp;
                        }

                        iBracketDepth += 1;
                    }
                    else if (ch == '}')
                    {
                        iBracketDepth -= 1;
                        if (iBracketDepth == 0)
                        {
                            l = cp - sp;
                            if (l > 0)
                            {
                                string argsText1 = sText.Substring(sp + 1, l - 1);
                                AddArrayItem(oList, argsText1, Conversions.ToBoolean(Interaction.IIf(oList.Count > 0, bTreatUnderscoreAsSpace, false)));
                            }
                            else
                            {
                                var tempVar = string.Empty;
                                AddArrayItem(oList, tempVar);
                            }

                            sp = cp + 1;
                        }
                    }
                    else if (ch == ' ')
                    {
                        if (iBracketDepth == 0)
                        {
                            l = cp - sp;
                            if (l > 0)
                            {
                                string argsText = sText.Substring(sp, l);
                                AddArrayItem(oList, argsText, Conversions.ToBoolean(Interaction.IIf(oList.Count > 0, bTreatUnderscoreAsSpace, false)));
                            }

                            sp = cp + 1;
                        }
                    }
                    else if (ch == '\\')
                    {
                        bEscapeChar = true;
                    }
                }

                l = sText.Length - sp;
                if (l > 0)
                {
                    string argsText3 = sText.Substring(sp, l);
                    AddArrayItem(oList, argsText3, Conversions.ToBoolean(Interaction.IIf(oList.Count > 0, bTreatUnderscoreAsSpace, false)));
                }
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                throw new Exception("Invalid string in Parse Arguments: " + sText);
            }

            return oList;
        }

        public static void AddArrayItem(Genie.Collections.ArrayList oList, string sText, bool bTreatUnderscoreAsSpace = false)
        {
            if (sText.StartsWith("\""))
            {
                if (sText.EndsWith("\""))
                {
                    sText = sText.Substring(1, sText.Length - 2);
                }
            }

            if (sText.StartsWith("'"))
            {
                if (sText.EndsWith("'"))
                {
                    sText = sText.Substring(1, sText.Length - 2);
                }
            }

            if (bTreatUnderscoreAsSpace && sText.Contains("_"))
            {
                sText = sText.Replace("_", " ");
            }

            oList.Add(sText);
        }

        public static bool MoveFile(string sSourceFileName, string sDestFileName)
        {
            try
            {
                File.Move(sSourceFileName, sDestFileName);
            }
            #pragma warning disable CS0168
            catch (IOException ex)
            #pragma warning restore CS0168
            {
                // The destination file already exists.
                return false;
            }
            #pragma warning disable CS0168
            catch (UnauthorizedAccessException ex)
            #pragma warning restore CS0168
            {
                // The caller does not have the required permission. 
                return false;
            }

            return true;
        }

        public static bool DeleteFile(string sourceFileName)
        {
            try
            {
                File.Delete(sourceFileName);
            }
            #pragma warning disable CS0168
            catch (IOException ex)
            #pragma warning restore CS0168
            {
                return false;
            }
            #pragma warning disable CS0168
            catch (UnauthorizedAccessException ex)
            #pragma warning restore CS0168
            {
                // The caller does not have the required permission. 
                return false;
            }

            return true;
        }

        public static bool CreateDirectory(string sourceDirectoryName)
        {
            try
            {
                if (!Directory.Exists(sourceDirectoryName))
                {
                    Directory.CreateDirectory(sourceDirectoryName);
                }
            }
            #pragma warning disable CS0168
            catch (IOException ex)
            #pragma warning restore CS0168
            {
                return false;
            }
            #pragma warning disable CS0168
            catch (UnauthorizedAccessException ex)
            #pragma warning restore CS0168
            {
                // The caller does not have the required permission. 
                return false;
            }

            return true;
        }

        public static bool StringToBoolean(string sValue)
        {
            if (sValue.Equals("True") || sValue.Equals("False"))
            {
                return Convert.ToBoolean(sValue);
            }
            else if (sValue.Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double StringToDouble(string sValue)
        {
            try
            {
                if (Information.IsNothing(sValue))
                {
                    return -1;
                }

                double d = double.Parse(sValue, new System.Globalization.CultureInfo("en-US"));
                return d;
            }
            #pragma warning disable CS0168
            catch (FormatException ex)
            #pragma warning restore CS0168
            {
                return -1;
            }
            #pragma warning disable CS0168
            catch (OverflowException ex)
            #pragma warning restore CS0168
            {
                return -1;
            }
            #pragma warning disable CS0168
            catch (InvalidCastException ex)
            #pragma warning restore CS0168
            {
                return -1;
            }
        }

        public static int StringToInteger(string sValue)
        {
            try
            {
                if (Information.IsNothing(sValue))
                {
                    return -1;
                }

                int i = int.Parse(sValue, new System.Globalization.CultureInfo("en-US"));
                if (i > 0)
                {
                    return i;
                }
                else
                {
                    return -1;
                }
            }
            #pragma warning disable CS0168
            catch (FormatException ex)
            #pragma warning restore CS0168
            {
                return -1;
            }
            #pragma warning disable CS0168
            catch (OverflowException ex)
            #pragma warning restore CS0168
            {
                return -1;
            }
            #pragma warning disable CS0168
            catch (InvalidCastException ex)
            #pragma warning restore CS0168
            {
                return -1;
            }
        }

        public static double EvalDoubleTime(string sDoubleString, double dDefaultPause = 1000)
        {
            if (sDoubleString.Trim().Length > 0)
            {
                double d = StringToDouble(sDoubleString);
                if (d > 0)
                {
                    return d * 1000;
                }
                else
                {
                    return dDefaultPause;
                }
            }
            else
            {
                return dDefaultPause;
            }
        }

        /// <summary>
    /// exception-safe retrieval of LastWriteTime for this assembly.
    /// </summary>
    /// <returns>File.GetLastWriteTime, or DateTime.MaxValue if exception was encountered.</returns>
        private static DateTime AssemblyLastWriteTime(System.Reflection.Assembly a)
        {
            try
            {
                return File.GetLastWriteTime(a.Location);
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                return DateTime.MaxValue;
            }
        }

        public static DateTime AssemblyBuildDate(System.Reflection.Assembly a)
        {
            var AssemblyVersion = a.GetName().Version;
            DateTime dt;
            dt = Conversions.ToDate("01/01/2000").AddDays(AssemblyVersion.Build).AddSeconds(AssemblyVersion.Revision * 2);

            if (TimeZone.IsDaylightSavingTime(dt, TimeZone.CurrentTimeZone.GetDaylightChanges(dt.Year)))
            {
                dt = dt.AddHours(1);
            }

            if (dt > DateTime.Now | AssemblyVersion.Build < 730 | AssemblyVersion.Revision == 0)
            {
                return default;
            }
            else
            {
                return dt;
            }
        }

        public static string ArrayToString(Genie.Collections.ArrayList oList, int iStartIndex)
        {
            // This is for small strings. For large strings we would use StringBuilder
            string sReturnText = string.Empty;
            for (int I = iStartIndex, loopTo = oList.Count - 1; I <= loopTo; I++)
            {
                sReturnText += oList[I].ToString();
                if (oList[I].ToString().Trim().Length > 0)
                {
                    sReturnText += " ";
                }
            }

            return sReturnText.Trim();
        }

        public static Genie.Collections.ArrayList SafeSplit(string sInput, char cSplitChar)
        {
            var oList = new Genie.Collections.ArrayList();
            bool bInsideString = false;
            var cInsideStringChar = default(char);
            int iBracketDepth = 0;
            bool bPreviousWasEscapeChar = false;
            char ch;
            int l = 0;
            int sp = 0;
            for (int cp = 0, loopTo = sInput.Length - 1; cp <= loopTo; cp++)
            {
                ch = sInput[cp];
                if (bInsideString == true)
                {
                    if (ch == cInsideStringChar)
                    {
                        bInsideString = false;
                    }
                }
                else if (ch == '"' & bPreviousWasEscapeChar == false) // (ch = """"c Or ch = "'"c)
                {
                    bInsideString = true;
                    cInsideStringChar = ch;
                }
                else if (ch == '{' & bPreviousWasEscapeChar == false)
                {
                    iBracketDepth += 1;
                }
                else if (ch == '}' & bPreviousWasEscapeChar == false)
                {
                    iBracketDepth -= 1;
                }
                else if (ch == cSplitChar & bPreviousWasEscapeChar == false)
                {
                    if (iBracketDepth == 0)
                    {
                        l = cp - sp;
                        if (l > 0)
                        {
                            oList.Add(sInput.Substring(sp, l));
                            sp = cp + 1; // +1 So we don't get the split char
                        }
                    }
                }

                if (ch == '\\')
                {
                    bPreviousWasEscapeChar = !bPreviousWasEscapeChar;
                }
                else
                {
                    bPreviousWasEscapeChar = false;
                }
            }

            l = sInput.Length - sp;
            if (l > 0)
            {
                oList.Add(sInput.Substring(sp));
            }

            return oList;
        }

        public static string TrimStart(string line)
        {
            return line.TrimStart(Conversions.ToChar(Constants.vbCr), Conversions.ToChar(Constants.vbLf));
        }

        public static string TrimEnd(string line)
        {
            return line.TrimEnd(Conversions.ToChar(Constants.vbCr), Conversions.ToChar(Constants.vbLf));
        }

        public static string Trim(string line)
        {
            string argline = TrimEnd(line);
            return TrimStart(argline);
        }

        // Temporary for moving over from old dir structure...
        public static void MoveLayoutFiles()
        {
            try
            {
                string sFile;
                sFile = FileSystem.Dir(LocalDirectory.Path + @"\Config\*.layout");
                while (!string.IsNullOrEmpty(sFile))
                {
                    MoveFile(LocalDirectory.Path + @"\Config\" + sFile, LocalDirectory.Path + @"\Config\Layout\" + sFile);
                    sFile = FileSystem.Dir();
                }
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
            }
        }

        public static double MathCalc(double dValue, string sExpression)
        {
            string argsValue = GetArgumentString(sExpression);
            double dNumber = StringToDouble(argsValue);
            if (dNumber < 0)
            {
                dNumber = 0;
            }

            var switchExpr = GetKeywordString(sExpression).ToLower();
            switch (switchExpr)
            {
                case "add":
                case "+":
                    {
                        dValue = dValue + dNumber;
                        break;
                    }

                case "sub":
                case "substract":
                case "subtract":
                case "-":
                    {
                        dValue = dValue - dNumber;
                        break;
                    }

                case "set":
                case "=":
                    {
                        dValue = dNumber;
                        break;
                    }

                case "multiply":
                case "*":
                    {
                        dValue = dValue * dNumber;
                        break;
                    }

                case "divide":
                case "/":
                    {
                        dValue = dValue / dNumber;
                        break;
                    }

                case "mod":
                case "modulus":
                case "%":
                    {
                        if (dValue != 0)
                        {
                            dValue = dValue % dNumber;
                        }
                        else
                        {
                            dValue = 0;
                        }

                        break;
                    }

                default:
                    {
                        throw new Exception("Invalid #MATH expression: " + sExpression);
                    }
            }

            return dValue;
        }

        public static string GetKeywordString(string strRow)
        {
            strRow = strRow.Trim();
            int I = strRow.IndexOf(' ');
            if (I > -1)
            {
                return strRow.Substring(0, I);
            }
            else
            {
                return strRow;
            }
        }

        public static string GetArgumentString(string strRow)
        {
            strRow = strRow.Trim();
            int I = strRow.IndexOf(' ');
            if (I > -1)
            {
                return strRow.Substring(I + 1);
            }
            else
            {
                return string.Empty;
            }
        }

        public static int Count(string text, string match)
        {
            int c = 0;
            int i;
            i = text.IndexOf(match);
            while (i > -1)
            {
                if (i > -1)
                {
                    i = text.IndexOf(match, i + match.Length);
                    c += 1;
                }
            }

            return c;
        }
    }
}