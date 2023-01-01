using System;
using System.Collections;
using System.Threading;

namespace GenieClient.Genie.Collections
{
    public class SortedList : System.Collections.SortedList
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
                return m_oRWLock.TryEnterWriteLock(500);
            }
            catch
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
                return m_oRWLock.TryEnterReadLock(500);
            }
            catch 
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
            catch
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
            catch 
            {
                return false;
            }
        }

        public SortedList() : base()
        {
        }

        public SortedList(IComparer comparer) : base(comparer)
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