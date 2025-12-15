using System;

namespace GenieClient
{
    /// <summary>
    /// Central error handling for the Genie client.
    /// Base class provides general error events. Plugin-specific error handling
    /// is extended in the Windows project via partial class.
    /// </summary>
    public static partial class GenieError
    {
        [ThreadStatic]
        private static bool _isHandlingError;

        public static void Error(string section, string message, string description = null)
        {
            // Prevent infinite recursion if an error handler raises another error
            if (_isHandlingError) return;
            
            try
            {
                _isHandlingError = true;
                EventGenieError?.Invoke(section, message, description);
            }
            finally
            {
                _isHandlingError = false;
            }
        }

        public static event EventGenieErrorEventHandler EventGenieError;

        public delegate void EventGenieErrorEventHandler(string section, string message, string description);
    }
}