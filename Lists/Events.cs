using System;
using System.Collections;
using System.Threading;

namespace GenieClient.Genie
{
    public class Events
    {
        public Queue EventList = new Queue();
        private object m_oThreadLock = new object(); // Thread safety

        public class Queue : Collections.ArrayList
        {
            public class EventItem
            {
                public DateTime oDate;
                public string sAction;

                public EventItem(DateTime oInDate, string sInAction)
                {
                    oDate = oInDate;
                    sAction = sInAction;
                }
            }

            public class EventComparer : IComparer
            {
                public int Compare(object x, object y)
                {
                    return Comparer.Default.Compare(((EventItem)x).oDate, ((EventItem)y).oDate);
                }
            }

            public int Add(double dSeconds, string sAction)
            {
                object argvalue = new EventItem(DateTime.Now.AddMilliseconds(Utility.EvalDoubleTime(dSeconds.ToString(), 0)), sAction);
                Add(argvalue);
                IComparer argic = new EventComparer();
                Sort(argic);
                return default;
            }
        }

        public int AddToQueue(double dSeconds, string sAction)
        {
            if (Monitor.TryEnter(m_oThreadLock, 250))
            {
                try
                {
                    EventList.Add(dSeconds, sAction);
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
            }
            else
            {
                throw new Exception("Unable to aquire commandqueue thread lock.");
            }

            return default;
        }

        // Called on regular intervals to see if our Queue has anything ready to be checked out
        public string Poll()
        {
            string sReturn = string.Empty;
            if (Monitor.TryEnter(m_oThreadLock))
            {
                try
                {
                    if (EventList.Count > 0)
                    {
                        if (DateTime.Now >= ((Queue.EventItem)EventList.get_Item(0)).oDate)
                        {
                            sReturn = ((Queue.EventItem)EventList.get_Item(0)).sAction;
                            EventList.RemoveAt(0);
                        }
                    }
                }
                finally
                {
                    Monitor.Exit(m_oThreadLock);
                }
                // Else
                // Throw New Exception("Unable to aquire commandqueue thread lock.")
            }

            return sReturn;
        }
    }
}