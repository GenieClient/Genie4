using System;

namespace GenieClient
{
    public static class GenieError
    {
        public static void Error(string section, string message, string description = null)
        {
            EventGenieError?.Invoke(section, message, description);
        }

        public static event EventGenieErrorEventHandler EventGenieError;

        public delegate void EventGenieErrorEventHandler(string section, string message, string description);

        public static event EventGeniePluginErrorEventHandler EventGeniePluginError;

        public delegate void EventGeniePluginErrorEventHandler(GeniePlugin.Interfaces.IPlugin plugin, string section, Exception ex);

        public static void GeniePluginError(GeniePlugin.Interfaces.IPlugin plugin, string section, Exception ex)
        {
            EventGeniePluginError?.Invoke(plugin, section, ex);
        }
    }
}