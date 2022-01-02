using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic;

namespace GenieClient.Genie
{
    public class CommandQueue
    {
        public Queue EventList = new Queue();
        private object m_oThreadLock = new object(); // Thread safety
        private DateTime m_oNextTime;

        public class Queue : Collections.ArrayList
        {
            public class EventItem
            {
                public double dDelay;
                public string sAction;
                public bool bWaitForRoundtime;

                public EventItem(double dInDelay, bool bInWaitForRoundtime, string sInAction)
                {
                    dDelay = dInDelay;
                    sAction = sInAction;
                    bWaitForRoundtime = bInWaitForRoundtime;
                }
            }

            public int Add(double dDelay, bool bWaitForRoundtime, string sAction)
            {
                object argvalue = new EventItem(dDelay, bWaitForRoundtime, sAction);
                Add(argvalue);
                return default;
            }
        }

        public int AddToQueue(double dDelay, bool bWaitForRoundtime, string sAction)
        {
            if (Monitor.TryEnter(m_oThreadLock, 250))
            {
                try
                {
                    EventList.Add(dDelay, bWaitForRoundtime, sAction);
                    if (EventList.Count == 1) // Only item in list. Set the timer!
                    {
                        SetNextTime(dDelay);
                    }
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

        public void Clear()
        {
            if (Monitor.TryEnter(m_oThreadLock, 250))
            {
                try
                {
                    EventList.Clear();
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
        }

        // Called on regular intervals to see if our Queue has anything ready to be checked out
        public string Poll(bool bInRoundtime)
        {
            string sReturn = string.Empty;
            if (Monitor.TryEnter(m_oThreadLock))
            {
                try
                {
                    if (EventList.Count > 0)
                    {
                        if (Information.IsNothing(m_oNextTime))
                        {
                            throw new Exception("Queue time is NULL!");
                        }

                        if (DateTime.Now >= m_oNextTime)
                        {
                            Queue.EventItem ei = (Queue.EventItem)EventList.get_Item(0);
                            if (!(bInRoundtime == true & ei.bWaitForRoundtime == true))
                            {
                                sReturn = ei.sAction;
                                Debug.WriteLine("Now: " + DateTime.Now);
                                Debug.WriteLine("Send: " + sReturn);
                                double i1 = ei.dDelay;
                                EventList.RemoveAt(0);
                                if (EventList.Count > 0)
                                {
                                    SetNextTime(((Queue.EventItem)EventList.get_Item(0)).dDelay);
                                }
                            }
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

        private void SetNextTime(double dDelay)
        {
            if (EventList.Count > 0)
            {
                m_oNextTime = DateTime.Now.AddSeconds(dDelay);
                Debug.WriteLine("Now: " + DateTime.Now);
                Debug.WriteLine("Set Delay: " + dDelay.ToString());
                Debug.WriteLine("Set Next: " + m_oNextTime.ToString());
            }
            else
            {
                m_oNextTime = default;
            }
        }
    }
}