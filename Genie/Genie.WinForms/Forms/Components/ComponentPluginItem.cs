using System;
using GeniePlugin.Interfaces;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class ComponentPluginItem
    {
        public ComponentPluginItem()
        {
            InitializeComponent();
        }

        public event PluginButtonReloadEventHandler PluginButtonReload;

        public delegate void PluginButtonReloadEventHandler(ComponentPluginItem sender);

        public event PluginButtonUnloadEventHandler PluginButtonUnload;

        public delegate void PluginButtonUnloadEventHandler(ComponentPluginItem sender);

        public event PluginButtonEnableEventHandler PluginButtonEnable;

        public delegate void PluginButtonEnableEventHandler(ComponentPluginItem sender);

        public event PluginButtonDisableEventHandler PluginButtonDisable;

        public delegate void PluginButtonDisableEventHandler(ComponentPluginItem sender);

        public event PluginButtonDeleteEventHandler PluginButtonDelete;

        public delegate void PluginButtonDeleteEventHandler(ComponentPluginItem sender);

        private IPlugin _Plugin;

        public IPlugin Plugin
        {
            get
            {
                return _Plugin;
            }

            set
            {
                _Plugin = value;
                UpdatePanel();
            }
        }

        private void UpdatePanel()
        {
            Label1.Text = _Plugin.Name;
            Label2.Text = _Plugin.Version;
            Label3.Text = _Plugin.Description;
            if (_Plugin.Enabled)
            {
                ButtonEnable.Text = "Disable";
            }
            else
            {
                ButtonEnable.Text = "Enable";
            }
        }

        private void ButtonUnload_Click(object sender, EventArgs e)
        {
            PluginButtonUnload?.Invoke(this);
        }

        private void ButtonEnable_Click(object sender, EventArgs e)
        {
            if ((ButtonEnable.Text ?? "") == "Enable")
            {
                ButtonEnable.Text = "Disable";
                PluginButtonEnable?.Invoke(this);
            }
            else
            {
                ButtonEnable.Text = "Enable";
                PluginButtonDisable?.Invoke(this);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Interaction.MsgBox("This will permanently delete: " + Plugin.Name + System.Environment.NewLine + "Are you sure this is what you want to do?", MsgBoxStyle.YesNo, "Warning") == MsgBoxResult.Yes)
            {
                PluginButtonDelete?.Invoke(this);
            }
        }

        private void ButtonReload_Click(object sender, EventArgs e)
        {
            PluginButtonReload?.Invoke(this);
        }
    }
}