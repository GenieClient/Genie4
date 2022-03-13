using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    internal class PluginServices
    {
        public struct AvailablePlugin
        {
            public string AssemblyPath;
            public string ClassName;
            public string Key;
            public string Interface;
        }
        
        public static class Interfaces
        {
            public const string Legacy = "GeniePlugin.Interfaces.IPlugin";
            public const string Modern = "GeniePlugin.Plugins.IPlugin";
        }

        public static AvailablePlugin[] FindPlugins(string strPath)
        {
            var Plugins = new Genie.Collections.ArrayList();
            string[] strDLLs;
            int intIndex;
            Assembly objDLL;

            // Go through all DLLs in the directory, attempting to load them
            strDLLs = Directory.GetFileSystemEntries(strPath, "*.dll");
            var loopTo = strDLLs.Length - 1;
            for (intIndex = 0; intIndex <= loopTo; intIndex++)
            {
                try
                {
                    string argsText = GetMD5HashFromFile(strDLLs[intIndex]);
                    object strKey = Utility.GenerateKeyHash(argsText);
                    var readAllBytes = File.ReadAllBytes(strDLLs[intIndex]);
                    objDLL = Assembly.Load(readAllBytes);
                    ExamineAssembly(objDLL, strDLLs[intIndex], Conversions.ToString(strKey), Plugins);
                }
#pragma warning disable CS0168
                catch (Exception e)
#pragma warning restore CS0168
                {
                    // Error loading DLL, we don't need to do anything special
                }
            }

            // Return all plugins found
            var Results = new AvailablePlugin[Plugins.Count];
            if (Plugins.Count != 0)
            {
                Plugins.CopyTo(Results);
                return Results;
            }
            else
            {
                return null;
            }
        }

        public static AvailablePlugin FindPlugin(string strFile, string strInterface)
        {
            if (!File.Exists(strFile))
            {
                return default;
            }

            Assembly objDLL;
            string argsText = GetMD5HashFromFile(strFile);
            object strKey = Utility.GenerateKeyHash(argsText);
            var readAllBytes = File.ReadAllBytes(strFile);
            objDLL = Assembly.Load(readAllBytes);
            var Plugins = new Genie.Collections.ArrayList();
            ExamineAssembly(objDLL, strFile, Conversions.ToString(strKey), Plugins);
            if (Plugins.Count != 0)
            {
                return (AvailablePlugin)Plugins[0];
            }
            else
            {
                return default;
            }
        }

        public static string GetMD5HashFromFile(string fileName)
        {
            var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            MD5 md5 = new MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(file);
            file.Close();
            var sb = new StringBuilder();
            for (int i = 0, loopTo = retVal.Length - 1; i <= loopTo; i++)
                sb.Append(retVal[i].ToString("x2"));
            return sb.ToString();
        }

        private static void ExamineAssembly(Assembly objDLL, string AssemblyPath, string strKey, Genie.Collections.ArrayList Plugins)
        {
            Type objInterface;
            AvailablePlugin Plugin;

            // Loop through each type in the DLL
            foreach (Type objType in objDLL.GetTypes())
            {
                // Only look at public types
                if (objType.IsPublic == true)
                {
                    // Ignore abstract classes
                    if (!((objType.Attributes & TypeAttributes.Abstract) == TypeAttributes.Abstract))
                    {

                        // See if this type implements our legacy interface

                        objInterface = objType.GetInterface(Interfaces.Legacy, true);
                        if (objInterface is null)
                        {
                            objInterface = objType.GetInterface(Interfaces.Modern, true);
                        }
                        if (!(objInterface is null))
                        {
                            // It does
                            Plugin = new AvailablePlugin();
                            // Plugin.AssemblyPath = objDLL.Location
                            Plugin.AssemblyPath = AssemblyPath;
                            Plugin.ClassName = objType.FullName;
                            Plugin.Key = strKey;
                            Plugin.Interface = objInterface.FullName;
                            Plugins.Add(Plugin);
                        }
                    }
                }
            }
        }

        public static object CreateInstance(AvailablePlugin Plugin)
        {
            Assembly objDLL;
            object objPlugin;
            try
            {
                // Load dll
                var readAllBytes = File.ReadAllBytes(Plugin.AssemblyPath);
                objDLL = Assembly.Load(readAllBytes);

                // Create and return class instance
                objPlugin = objDLL.CreateInstance(Plugin.ClassName);
            }
#pragma warning disable CS0168
            catch (Exception e)
#pragma warning restore CS0168
            {
                return null;
            }

            return objPlugin;
        }
    }
}