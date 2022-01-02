using Microsoft.VisualBasic;

namespace GenieClient.Genie.Script
{
    public class Trace
    {
        private int m_CurrentIndex = -1;
        private int m_TraceSize = 20;
        private string[] m_TraceList = new string[20];

        public Trace()
        {
        }

        public Trace(int iTraceSize)
        {
            Size = iTraceSize;
        }

        public void Lock()
        {
            System.Threading.Monitor.Enter(this);
        }

        public void Unlock()
        {
            System.Threading.Monitor.Exit(this);
        }

        public int Index
        {
            get
            {
                return m_CurrentIndex;
            }
        }

        public int Size
        {
            get
            {
                return m_TraceSize;
            }

            set
            {
                try
                {
                    Lock();
                    m_TraceSize = value;
                    m_CurrentIndex = 0;
                    m_TraceList = new string[m_TraceSize];
                }
                finally
                {
                    Unlock();
                }
            }
        }

        public void Clear()
        {
            m_TraceList = new string[m_TraceSize]; // Redim clears it
        }

        public string get_Item(int index)
        {
            if (index < 0 & index >= m_TraceSize)
            {
                return string.Empty;
            }

            if (Information.IsNothing(m_TraceList[index]))
            {
                return string.Empty;
            }

            return m_TraceList[index];
        }

        public int Add(string value, string sFileName = "", int iFileRow = 0)
        {
            try
            {
                Lock();
                m_CurrentIndex += 1;
                if (m_CurrentIndex >= m_TraceSize)
                {
                    m_CurrentIndex = 0;
                }

                if (sFileName.Length > 0 & iFileRow > 0)
                {
                    value += " " + sFileName + "(" + iFileRow.ToString() + ")";
                }
                else if (sFileName.Length > 0)
                {
                    value += " " + sFileName;
                }
                else if (iFileRow > 0)
                {
                    value += " (" + iFileRow.ToString() + ")";
                }

                m_TraceList[m_CurrentIndex] = value;
            }
            finally
            {
                Unlock();
            }

            return default;
        }

        public new string ToString()
        {
            string s = string.Empty;
            for (int I = m_CurrentIndex + 1, loopTo = m_TraceSize - 1; I <= loopTo; I++)
            {
                if (!Information.IsNothing(m_TraceList[I]) && m_TraceList[I].Length > 0)
                {
                    s += Constants.vbTab + m_TraceList[I] + System.Environment.NewLine;
                }
            }

            for (int I = 0, loopTo1 = m_CurrentIndex; I <= loopTo1; I++)
            {
                if (!Information.IsNothing(m_TraceList[I]) && m_TraceList[I].Length > 0)
                {
                    s += Constants.vbTab + m_TraceList[I] + System.Environment.NewLine;
                }
            }

            return s;
        }

        // Public Shadows Function ToString() As String
        // Dim s As String = String.Empty

        // For I As Integer = m_CurrentIndex To 0 Step -1
        // If Not IsNothing(m_TraceList(I)) AndAlso m_TraceList(I).Length > 0 Then
        // s &= m_TraceList(I) & "*" & vbNewLine
        // End If
        // Next

        // For I As Integer = m_TraceSize - 1 To m_CurrentIndex + 1 Step -1
        // If Not IsNothing(m_TraceList(I)) AndAlso m_TraceList(I).Length > 0 Then
        // s &= m_TraceList(I) & vbNewLine
        // End If
        // Next

        // Return s
        // End Function

    }
}