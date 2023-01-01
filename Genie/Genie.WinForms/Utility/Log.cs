using System;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;

namespace GenieClient.Genie
{
    public class Log
    {
        private object m_oThreadLock = new object(); // Thread safety. Only write from one thread at a time.
        public string LogDirectory = "Logs";

        public bool LogText(string sText, string sCharacterName, string sInstanceName)
        {
            if (Monitor.TryEnter(m_oThreadLock, 100))
            {
                try
                {
                    if (sCharacterName.Length == 0)
                    {
                        return default;
                    }

                    string sDirectory = LogDirectory;
                    if (!LogDirectory.Contains(@"\"))
                    {
                        sDirectory = Path.Combine(LocalDirectory.Path, LogDirectory);
                    }

                    string sFileName = Path.Combine(sDirectory, sCharacterName + sInstanceName + "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                    if (File.Exists(sFileName) == false)
                    {
                        sText = "*** LOG CREATED AT " + DateTime.Now.ToString() + " ***" + System.Environment.NewLine + System.Environment.NewLine + sText;
                    }

                    var oStreamWriter = new StreamWriter(sFileName, true);
                    oStreamWriter.Write(sText);
                    oStreamWriter.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    GenieError.Error("LogText", ex.Message, ex.ToString());
                    return false;
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // Throw New Exception("Unable to aquire log thread lock.")
            }

            return default;
        }

        public bool LogLine(string sText, string sFileName = "default.log")
        {
            if (Monitor.TryEnter(m_oThreadLock, 100))
            {
                try
                {
                    if (!sFileName.Contains(@"\"))
                    {
                        string sDirectory = LogDirectory;
                        if (!LogDirectory.Contains(@"\"))
                        {
                            sDirectory = Path.Combine(LocalDirectory.Path, LogDirectory);
                        }

                        sFileName = Path.Combine(sDirectory, sFileName);
                    }

                    var oStreamWriter = new StreamWriter(sFileName, true);
                    oStreamWriter.WriteLine(sText);
                    oStreamWriter.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    GenieError.Error("LogLine", ex.Message, ex.ToString());
                    return false;
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                // Throw New Exception("Unable to aquire log thread lock.")
            }

            return default;
        }
    }
}