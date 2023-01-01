using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic;

namespace GenieClient.Genie
{
    public class CommandQueue
    {
        public struct CommandRestrictions 
        {
            public bool WaitForRoundtime = false;
            public bool WaitForStunned = false;
            public bool WaitForWebbed = false;
            public CommandRestrictions() { }
        }

        public Queue EventList = new Queue();
        private object m_oThreadLock = new object(); // Thread safety
        private DateTime m_oNextTime;

        public class Queue : Collections.ArrayList
        {
            public class EventItem
            {
                public double Delay;
                public string Action;
                public CommandRestrictions Restrictions;

                public EventItem(double InDelay, string InAction, CommandRestrictions InRestrictions)
                {
                    Delay = InDelay;
                    Action = InAction;
                    Restrictions = InRestrictions;
                }

                public bool IsRestricted(bool InRoundtime, bool IsWebbed, bool IsStunned)
                {
                    if (Restrictions.WaitForRoundtime && InRoundtime) return true;
                    if (Restrictions.WaitForStunned && IsStunned) return true;
                    if (Restrictions.WaitForWebbed && IsWebbed) return true;
                    return false;
                }
            }

            public int Add(double dDelay, bool bWaitForRoundtime, string sAction, bool WaitForWebbed, bool WaitForStunned)
            {
                CommandRestrictions restrictions = new CommandRestrictions();
                restrictions.WaitForRoundtime = bWaitForRoundtime;
                restrictions.WaitForWebbed = WaitForWebbed; 
                restrictions.WaitForStunned = WaitForStunned;
                object argvalue = new EventItem(dDelay, sAction, restrictions);
                Add(argvalue);
                return default;
            }
            public int Add(double Delay, string Action, CommandRestrictions Restrictions)
            {
                object argvalue = new EventItem(Delay, Action, Restrictions);
                Add(argvalue);
                return default;
            }
        }


        public int AddToQueue(double Delay, string Action, bool WaitForRoundtime, bool WaitForWebbed, bool WaitForStunned)
        {
            if (Monitor.TryEnter(m_oThreadLock, 250))
            {
                try
                {
                    CommandRestrictions restrictions = new CommandRestrictions 
                    { 
                        WaitForRoundtime = WaitForRoundtime, 
                        WaitForStunned = WaitForStunned, 
                        WaitForWebbed = WaitForWebbed 
                    };
                    EventList.Add(Delay, Action, restrictions);
                    if (EventList.Count == 1) // Only item in list. Set the timer!
                    {
                        SetNextTime(Delay);
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
        public string Poll(bool InRoundtime, bool IsWebbed, bool IsStunned)
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
                            if (!ei.IsRestricted(InRoundtime, IsWebbed, IsStunned))
                            {
                                sReturn = ei.Action;
                                Debug.WriteLine("Now: " + DateTime.Now);
                                Debug.WriteLine("Send: " + sReturn);
                                double i1 = ei.Delay;
                                EventList.RemoveAt(0);
                                if (EventList.Count > 0)
                                {
                                    SetNextTime(((Queue.EventItem)EventList.get_Item(0)).Delay);
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