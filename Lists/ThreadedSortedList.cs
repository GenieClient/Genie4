using System;
using System.Collections;
using System.Threading;

namespace GenieClient.Genie.Collections
{
    public class ThreadedSortedList : System.Collections.SortedList
    {
        private ReaderWriterLockSlim m_oRWLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        public bool AcquireWriterLock()
        {
            try
            {
                if(m_oRWLock.IsWriteLockHeld | m_oRWLock.IsReadLockHeld)
                {
                    return false;
                }
                m_oRWLock.EnterWriteLock();
                return true;
            }
#pragma warning disable CS0168
            catch (Exception ex)
#pragma warning restore CS0168
            {
                return false;
            }
        }
        public bool AcquireReaderLock()
        {
            try
            {
                if (m_oRWLock.IsWriteLockHeld)
                {
                    return false;
                }
                m_oRWLock.EnterReadLock();
                return true;
            }
#pragma warning disable CS0168
            catch (Exception ex)
#pragma warning restore CS0168
            {
                return false;
            }
        }

        public bool ReleaseWriterLock()
        {
            try
            {
                m_oRWLock.ExitWriteLock();
                return true;
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                return false;
            }
        }

        public bool ReleaseReaderLock()
        {
            try
            {
                m_oRWLock.ExitReadLock();
                return true;
            }
            #pragma warning disable CS0168
            catch (Exception ex)
            #pragma warning restore CS0168
            {
                return false;
            }
        }

        public ThreadedSortedList() : base()
        {
        }

        public ThreadedSortedList(IComparer comparer) : base(comparer)
        {
        }

        public new void Clear()
        {
            if (AcquireWriterLock())
            {
                try
                {
                    base.Clear();
                }
                finally
                {
                    ReleaseWriterLock();
                }
            }
            else
            {
                throw new Exception("Unable to aquire writer lock.");
            }
        }

        public new void Add(object key, object value)
        {
            if (AcquireWriterLock())
            {
                try
                {
                    base.Add(key, value);
                }
                finally
                {
                    ReleaseWriterLock();
                }
            }
            else
            {
                throw new Exception("Unable to aquire writer lock.");
            }
        }

        public new void Remove(object key)
        {
            if (AcquireWriterLock())
            {
                try
                {
                    base.Remove(key);
                }
                finally
                {
                    ReleaseWriterLock();
                }
            }
            else
            {
                throw new Exception("Unable to aquire writer lock.");
            }
        }

        public new void RemoveAt(int index)
        {
            if (AcquireWriterLock())
            {
                try
                {
                    base.RemoveAt(index);
                }
                finally
                {
                    ReleaseWriterLock();
                }
            }
            else
            {
                throw new Exception("Unable to aquire writer lock.");
            }
        }

        public new object this[object key]
        {
            get
            {
                return base[key];
            }

            set
            {
                if (AcquireWriterLock())
                {
                    try
                    {
                        base[key] = value;
                    }
                    finally
                    {
                        ReleaseWriterLock();
                    }
                }
                else
                {
                    throw new Exception("Unable to aquire writer lock.");
                }
            }
        }
    }
}