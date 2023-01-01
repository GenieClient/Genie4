using System;
using System.Xml;
using Microsoft.VisualBasic;

namespace GenieClient.Genie
{
    public class XMLConfig
    {
        private XmlDocument xmlDoc;
        private string myConfigFile = string.Empty;
        private bool myHasData = false;

        public XMLConfig()
        {
            xmlDoc = new XmlDocument();
        }

        public string ConfigFile
        {
            get
            {
                return myConfigFile;
            }
        }

        public bool HasData
        {
            get
            {
                return myHasData;
            }
        }

        public bool LoadFile(string filename)
        {
            if (Information.IsNothing(filename) || System.IO.File.Exists(filename) == false)
            {
                return false;
            }

            if (xmlDoc is null)
            {
                xmlDoc = new XmlDocument();
            }

            if (filename.Length > 0 && !(xmlDoc is null))
            {
                myConfigFile = filename;
                try
                {
                    xmlDoc.Load(filename);
                    myHasData = true;
                    return true;
                }
                catch
                {
                    myHasData = false;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool LoadXml(string xmldata)
        {
            if (xmlDoc is null)
            {
                xmlDoc = new XmlDocument();
            }

            if (xmldata.Length > 0 && !(xmlDoc is null))
            {
                try
                {
                    xmlDoc.LoadXml(xmldata);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void CloseFile()
        {
            if (!(xmlDoc is null))
            {
                xmlDoc = null;
            }

            myConfigFile = "";
        }

        public string GetValue(string path, string attribute, string DefaultValue)
        {
            string ro = GetValueObject(path, attribute);
            if (!Information.IsNothing(ro))
            {
                try
                {
                    // can this throw?
                    return Convert.ToString(ro);
                }
                catch { }
            }
            return DefaultValue;
        }

        public bool GetValue(string path, string attribute, bool DefaultValue)
        {
            string ro = GetValueObject(path, attribute);
            if (ro != null && ro.Length > 0 && (ro.Equals("True") || ro.Equals("False")))
            {
                return Convert.ToBoolean(ro);
            }
            return DefaultValue;
        }

        public int GetValue(string path, string attribute, int DefaultValue)
        {
            string ro = GetValueObject(path, attribute);
            if (ro != null && ro.Length > 0)
            {
                try
                {
                    return Convert.ToInt32(ro);
                }
                catch { }
            }
            // If value doesn't exist or is invalid, return default:
            return DefaultValue;
        }

        public double GetValue(string path, string attribute, double DefaultValue)
        {
            string ro = GetValueObject(path, attribute);
            if (ro != null && ro.Length > 0)
            {
                try
                {
                    return Convert.ToDouble(ro);
                }
                catch { }
            }
            return DefaultValue;
        }

        public float GetValueSingle(string path, string attribute, float DefaultValue)
        {
            string ro = GetValueObject(path, attribute);
            if (ro != null && ro.Length > 0)
            {
                try
                {
                    return Convert.ToSingle(ro);
                }
                catch { }
            }
            return DefaultValue;
        }

        public DateTime GetValue(string path, string attribute, DateTime DefaultValue)
        {
            string ro = GetValueObject(path, attribute);
            if (ro != null && ro.Length > 0)
            {
                try
                {
                    return Convert.ToDateTime(ro);
                }
                catch { }
            }
            return DefaultValue;
        }

        private string GetValueObject(string path, string attribute)
        {
            string node;
            string key;
            int i;
            i = path.LastIndexOf("/");
            if (i < 0)
            {
                return null;
            }

            node = path.Substring(0, i);
            key = path.Substring(i + 1);
            if (xmlDoc is null)
            {
                throw new ArgumentNullException("getvalue", "No config to read from.");
            }

            try
            {
                var xmlNode = xmlDoc.SelectSingleNode(node);
                if (!(xmlNode is null))
                {
                    XmlElement targetElem = (XmlElement)xmlNode.SelectSingleNode(key);
                    if (!(targetElem is null) && targetElem.HasAttribute(attribute) != false)
                        return targetElem.GetAttribute(attribute);
                }
            }
            catch
            { }
            return null;
        }

        public bool SetValue(string path, string attribute, string val)
        {
            string node;
            string key;
            int i;
            i = path.LastIndexOf("/");
            if (i == 0)
            {
                return false;
            }

            node = path.Substring(0, i);
            key = path.Substring(i + 1);
            if (xmlDoc is null)
            {
                throw new ArgumentNullException("setvalue", "No config to set value to.");
            }

            try
            {
                var xmlNode = xmlDoc.SelectSingleNode(node);
                if (xmlNode is null)
                {
                    return false;
                }

                XmlElement targetElem = (XmlElement)xmlNode.SelectSingleNode(key);
                if (!(targetElem is null))
                {
                    targetElem.SetAttribute(attribute, val);
                }
                else
                {
                    var entry = xmlDoc.CreateElement(key);
                    entry.SetAttribute(attribute, val);
                    xmlNode.AppendChild(entry);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveElement(string key)
        {
            if (xmlDoc is null)
            {
                return false;
            }

            try
            {
                XmlElement targetElem = (XmlElement)xmlDoc.SelectSingleNode(key);
                if (targetElem is null)
                {
                    return false;
                }

                var node = targetElem.ParentNode;
                node.RemoveChild(targetElem);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveToFile()
        {
            if (myConfigFile.Length > 0)
            {
                return SaveToFile(myConfigFile);
            }
            else
            {
                return false;
            }
        }

        public bool SaveToFile(string filename)
        {
            if (xmlDoc is null)
            {
                return false;
            }

            try
            {
                var writer = new XmlTextWriter(filename, null);
                writer.Formatting = Formatting.Indented;
                xmlDoc.WriteTo(writer);
                writer.Flush();
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}