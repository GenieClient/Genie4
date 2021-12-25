using System;
using System.Collections;
using System.Threading;

namespace GenieClient.Genie.Collections
{
    public class SortedList : System.Collections.SortedList
    {
        private const int m_iDefaultTimeout = 5;
        private ReaderWriterLock m_oRWLock = new ReaderWriterLock();

        public bool AcquireWriterLock(int millisecondsTimeout = 0)
        {
            try
            {
                m_oRWLock.AcquireWriterLock(millisecondsTimeout);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AcquireReaderLock(int millisecondsTimeout = 0)
        {
            try
            {
                m_oRWLock.AcquireReaderLock(millisecondsTimeout);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LockCookie UpgradeToWriterLock(int millisecondsTimeout = 0)
        {
            try
            {
                return m_oRWLock.UpgradeToWriterLock(millisecondsTimeout);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public bool DowngradeToReaderLock(LockCookie cookie)
        {
            try
            {
                m_oRWLock.DowngradeFromWriterLock(ref cookie);
                return true;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public bool ReleaseWriterLock()
        {
            try
            {
                m_oRWLock.ReleaseWriterLock();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ReleaseReaderLock()
        {
            try
            {
                m_oRWLock.ReleaseReaderLock();
                return true;
            }
            catch (Exception ex)
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
            if (AcquireWriterLock(m_iDefaultTimeout))
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
            if (AcquireWriterLock(m_iDefaultTimeout))
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
            if (AcquireWriterLock(m_iDefaultTimeout))
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
            if (AcquireWriterLock(m_iDefaultTimeout))
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
                if (AcquireWriterLock(m_iDefaultTimeout))
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