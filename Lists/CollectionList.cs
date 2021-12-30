using System;
using System.Collections;
using System.Threading;

namespace GenieClient.Genie.Collections
{
    public class CollectionList : CollectionBase
    {
        private ReaderWriterLockSlim m_RWLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        public bool AcquireWriterLock()
        {
            try
            {
                if (m_RWLock.IsWriteLockHeld | m_RWLock.IsReadLockHeld)
                {
                    return false;
                }
                m_RWLock.EnterWriteLock();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AcquireReaderLock()
        {
            try
            {
                m_RWLock.EnterReadLock();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ReleaseWriterLock()
        {
            try
            {
                m_RWLock.ExitWriteLock();
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
                m_RWLock.ExitReadLock();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}