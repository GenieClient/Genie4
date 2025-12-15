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
        public static void Error(string section, string message, string description = null)
        {
            EventGenieError?.Invoke(section, message, description);
        }

        public static event EventGenieErrorEventHandler EventGenieError;

        public delegate void EventGenieErrorEventHandler(string section, string message, string description);
    }
}