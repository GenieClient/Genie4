using System;

namespace GenieClient
{
    /// <summary>
    /// Windows-specific plugin error handling extension.
    /// </summary>
    public static partial class GenieError
    {
        // Legacy plugin error handling (GeniePlugin.Interfaces from Interfaces.dll)
        public static event EventGenieLegacyPluginErrorEventHandler EventGenieLegacyPluginError;

        public delegate void EventGenieLegacyPluginErrorEventHandler(GeniePlugin.Interfaces.IPlugin plugin, string section, Exception ex);

        public static void GeniePluginError(GeniePlugin.Interfaces.IPlugin plugin, string section, Exception ex)
        {
            EventGenieLegacyPluginError?.Invoke(plugin, section, ex);
        }

        // Newer plugin error handling (GeniePlugin.Plugins from Plugins.vbproj)
        public static event EventGeniePluginErrorEventHandler EventGeniePluginError;

        public delegate void EventGeniePluginErrorEventHandler(GeniePlugin.Plugins.IPlugin plugin, string section, Exception ex);

        public static void GeniePluginError(GeniePlugin.Plugins.IPlugin plugin, string section, Exception ex)
        {
            EventGeniePluginError?.Invoke(plugin, section, ex);
        }
    }
}

