using System.Threading;

namespace GenieClient.Genie
{
    public class ScriptList : Collections.CollectionList
    {

        #region Threading
        private ReaderWriterLockSlim m_oRWLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        public new bool AcquireWriterLock()
        {
            try
            {
                if (m_oRWLock.IsWriteLockHeld | m_oRWLock.IsReadLockHeld)
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

        public new bool AcquireReaderLock()
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

        public new bool ReleaseWriterLock()
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

        public new bool ReleaseReaderLock()
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
#endregion

        public GenieClient.Script this[int Index]
        {
            get
            {
                return (GenieClient.Script)List[Index];
            }

            set
            {
                List[Index] = value;
            }
        }

        public int Add(GenieClient.Script Item)
        {
            return List.Add(Item);
        }

        public void Remove(GenieClient.Script Item)
        {
            List.Remove(Item);
        }
    }
}