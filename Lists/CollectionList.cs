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
                
                return m_RWLock.TryEnterWriteLock(500);
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
                if (m_RWLock.IsWriteLockHeld) return false;
                return m_RWLock.TryEnterReadLock(500);
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
                m_RWLock.ExitWriteLock();
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
                m_RWLock.ExitReadLock();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}