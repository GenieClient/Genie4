using System;
using System.Collections;
using System.Threading;

namespace GenieClient.Genie.Collections
{
    public class ArrayList : System.Collections.ArrayList
    {
        private ReaderWriterLock m_oRWLock = new ReaderWriterLock();
        private const int m_iDefaultTimeout = 250;

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

        public ArrayList() : base()
        {
        }

        public ArrayList(IComparer comparer) : base((ICollection)comparer)
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

        public new int Add(object value)
        {
            if (AcquireWriterLock(m_iDefaultTimeout))
            {
                try
                {
                    return base.Add(value);
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

            return -1;
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

        // If m_oRWLock.IsReaderLockHeld Then
        // Dim cookie As LockCookie = UpgradeToWriterLock(m_iDefaultTimeout)
        // If Not IsNothing(cookie) Then
        // Try
        // MyBase.RemoveAt(index)
        // Finally
        // DowngradeToReaderLock(cookie)
        // End Try
        // Else
        // Throw New Exception("Unable to upgrade to writer lock.")
        // End If
        // Else

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

        public new object get_Item(int index)
        {
            return base[index];
        }

        public new void set_Item(int index, object value)
        {
            if (AcquireWriterLock(m_iDefaultTimeout))
            {
                try
                {
                    base[index] = value;
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

        public new void Sort()
        {
            if (AcquireWriterLock(m_iDefaultTimeout))
            {
                try
                {
                    base.Sort();
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

        public new void Sort(IComparer ic)
        {
            if (AcquireWriterLock(m_iDefaultTimeout))
            {
                try
                {
                    base.Sort(ic);
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