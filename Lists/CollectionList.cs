using System;
using System.Collections;
using System.Threading;

namespace GenieClient.Genie.Collections
{
    public class CollectionList : CollectionBase
    {
        private ReaderWriterLock m_RWLock = new ReaderWriterLock();

        public bool AcquireWriterLock(int millisecondsTimeout = 0)
        {
            try
            {
                if (m_RWLock.IsWriterLockHeld | m_RWLock.IsReaderLockHeld)
                    return false;
                m_RWLock.AcquireWriterLock(millisecondsTimeout);
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
                if (m_RWLock.IsWriterLockHeld)
                    return false;
                m_RWLock.AcquireReaderLock(millisecondsTimeout);
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
                if (m_RWLock.IsWriterLockHeld)
                    return default;
                return m_RWLock.UpgradeToWriterLock(millisecondsTimeout);
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
                m_RWLock.DowngradeFromWriterLock(ref cookie);
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
                m_RWLock.ReleaseWriterLock();
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
                m_RWLock.ReleaseReaderLock();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}