using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public class LegacyPluginHost : GeniePlugin.Interfaces.IHost
    {
        public event EventEchoTextEventHandler EventEchoText;

        public delegate void EventEchoTextEventHandler(string sText, Color oColor, Color oBgColor);

        public event EventSendTextEventHandler EventSendText;

        public delegate void EventSendTextEventHandler(string sText, string sPlugin);

        public event EventVariableChangedEventHandler EventVariableChanged;

        public delegate void EventVariableChangedEventHandler(string sVariable);

        private Genie.Globals m_oGlobals;
        private Form m_oParent;

        public void EchoText(string Text)
        {
            EventEchoText?.Invoke(Text + System.Environment.NewLine, Color.Cyan, Color.Transparent);
        }

        public void SendText(string Text)
        {
            EventSendText?.Invoke(Text, "Plugin");
        }

        public string get_Variable(string Var)
        {
            if ((Var ?? "") == "GenieKey")
            {
                return m_oGlobals.GenieKey;
            }
            else if ((Var ?? "") == "GenieAccount")
            {
                return m_oGlobals.GenieAccount;
            }
            else if ((Var ?? "") == "CommandChar")
            {
                return Conversions.ToString(m_oGlobals.AppSettings.ClientSettings.SpecialCharacters.Parse);
            }
            else if ((Var ?? "") == "PluginPath")
            {
                return System.IO.Path.Combine(LocalDirectory.Path, "Plugins");
            }
            else if ((Var ?? "") == "ScriptPath")
            {
                return System.IO.Path.Combine(LocalDirectory.Path, "Scripts");
            }
            else if (!Information.IsNothing(m_oGlobals))
            {
                if (!Information.IsNothing(m_oGlobals.VariableList[Var]))
                {
                    return Conversions.ToString(m_oGlobals.VariableList[Var]);
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public void set_Variable(string Var, string value)
        {
            if (!Information.IsNothing(m_oGlobals))
            {
                m_oGlobals.VariableList.Add(Var, value, Genie.Globals.Variables.VariableType.Temporary);
                EventVariableChanged?.Invoke("$" + Var);
            }
        }

        public bool get_IsVerified(string key)
        {
            if (Information.IsNothing(m_oGlobals))
                return false;
            return m_oGlobals.PluginVerifiedKeyList.ContainsKey(key);
        }

        public bool get_IsPremium(string key)
        {
            if (Information.IsNothing(m_oGlobals))
                return false;
            string argsText = Utility.GenerateAccountHash(key);
            string premKey = Utility.EncryptString(m_oGlobals.GenieKey, argsText);
            return m_oGlobals.PluginPremiumKeyList.ContainsKey(premKey);
        }

        public LegacyPluginHost(Form Form, ref Genie.Globals Globals)
        {
            m_oParent = Form;
            m_oGlobals = Globals;
        }

        public Form ParentForm
        {
            get
            {
                return m_oParent;
            }
        }

        private string m_sPluginKey;

        public string PluginKey
        {
            get
            {
                return m_sPluginKey;
            }

            set
            {
                m_sPluginKey = value;
            }
        }

        public int InterfaceVersion
        {
            get
            {
                return 4;
            }
        }
    }
}