using System;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenieClient.Genie;

namespace GenieClient.Forms
{
    public partial class FormMapperSettings : Form
    {
        private Globals _globals;
        private static string[] _classes = ["racial", "rp", "arrive", "combat", "joust"];
        private static string[] _globalVariables = ["caravan", "mapwalk", "searchwalk", "drag", "verbose", "automapper.iceroadcollect", "automapper.cyclic", ];
        Globals.Variables.Variable typeahead = new Globals.Variables.Variable("automapper.typeahead", "0", Globals.Variables.VariableType.Temporary);

        public event EventVariableChangedEventHandler EventVariableChanged;
        public delegate void EventVariableChangedEventHandler(string sVariable);
        public event EventClassChangeEventHandler EventClassChange;
        public delegate void EventClassChangeEventHandler();

        public FormMapperSettings(ref Globals globals)
        {
            this.InitializeComponent();
            _globals = globals;
            foreach (string mapperClass in _classes)
            {
                if (!CheckedListClasses.Items.Contains(mapperClass)) CheckedListClasses.Items.Add(mapperClass, GetCheckedStateClass(mapperClass));
            }
            foreach (string mapperGlobalVariable in _globalVariables)
            {
                if (!CheckedListVariables.Items.Contains(mapperGlobalVariable))
                {
                    int i = CheckedListVariables.Items.Add(mapperGlobalVariable, GetCheckedStateVariable(mapperGlobalVariable));
                }
            }
        }

        public async void Recolor()
        {
            BackColor = _globals.PresetList["ui.menu"].BgColor;
            CheckedListClasses.BackColor = _globals.PresetList["ui.menu"].BgColor;
            CheckedListVariables.BackColor = _globals.PresetList["ui.menu"].BgColor;
            ForeColor = _globals.PresetList["ui.menu"].FgColor;
            CheckedListClasses.ForeColor = _globals.PresetList["ui.menu"].FgColor;
            CheckedListVariables.ForeColor = _globals.PresetList["ui.menu"].FgColor;
        }

        public async void VariableChanged(string variable)
        {
            if (variable == "automapper.typeahead")
            {
                Globals.Variables.Variable tvar = _globals.VariableList.get_GetVariable("automapper.typeahead");
                if (tvar != null) typeahead.sValue = tvar.sValue;
                TextboxTypeahead.Text = tvar.sValue;
            }
            else if (CheckedListVariables.Items.Contains(variable))
            {
                CheckedListVariables.ItemCheck -= CheckedListVariables_ItemCheck;
                CheckedListVariables.SetItemChecked(CheckedListVariables.Items.IndexOf(variable), GetCheckedStateVariable(variable));
                CheckedListVariables.ItemCheck += CheckedListVariables_ItemCheck;
            }
        }

        public async void ToggleClass(string className, bool checkedState)
        {
            int i = CheckedListClasses.Items.IndexOf(className);
            if (i >= 0)
            {
                CheckedListClasses.ItemCheck -= CheckedListClasses_ItemCheck;
                CheckedListClasses.SetItemChecked(i, checkedState);
                CheckedListClasses.ItemCheck += CheckedListClasses_ItemCheck;
            }
        }
        private async void FormMapperSettings_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Recolor();
                RefreshClasses();
                RefreshVariables();
                GetCurrentTypeahead();
            }
        }

        private void RefreshClasses()
        {

            for (int i = 0; i < CheckedListClasses.Items.Count; i++)
            {
                CheckedListClasses.SetItemChecked(i, _globals.ClassList.GetValue(CheckedListClasses.Items[i].ToString()));
            }
            return;
        }

        private void RefreshVariables()
        {

            for (int i = 0; i < CheckedListVariables.Items.Count; i++)
            {
                Globals.Variables.Variable retrievedVariable = _globals.VariableList.get_GetVariable(CheckedListVariables.Items[i].ToString());
                CheckedListVariables.SetItemChecked(i, retrievedVariable != null && retrievedVariable.sValue == "1");
            }
            return;
        }

        private void FormMapperSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void ButtonSetTypeahead_Click(object sender, EventArgs e)
        {
            typeahead.sValue = TextboxTypeahead.Text;
            UpdateVariable(typeahead);
        }

        private void UpdateVariable(Globals.Variables.Variable var)
        {
            _globals.VariableList.set_GetVariable(var.sKey, var);
            EventVariableChanged?.Invoke("$" + var.sKey);
        }

        private bool GetCheckedStateVariable(string variableName)
        {
            Globals.Variables.Variable tvar = _globals.VariableList.get_GetVariable("automapper.typeahead");
            return tvar != null && tvar.sValue == "1";
        }

        private bool GetCheckedStateClass(string className)
        {
            return _globals.ClassList.GetValue(className);
        }

        private void GetCurrentTypeahead()
        {
            Globals.Variables.Variable savedTypeahead = _globals.VariableList.get_GetVariable("automapper.typeahead");
            if (savedTypeahead != null)
            {
                typeahead.sValue = savedTypeahead.sValue;
            }
            TextboxTypeahead.Text = typeahead.sValue;

        }

        private void CheckedListVariables_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int i = (sender as CheckedListBox).SelectedIndex;
            if (i >= 0)
            {
                string key = CheckedListVariables.Items[i].ToString();
                bool isChecked = e.NewValue == CheckState.Checked;
                Globals.Variables.Variable var = new Globals.Variables.Variable(key, isChecked ? "1" : "0", Globals.Variables.VariableType.Temporary);
                if(key == "drag")
                {
                    string target = isChecked ? Mes
                    
                }
                UpdateVariable(var);
            }
        }

        private void CheckedListClasses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int i = (sender as CheckedListBox).SelectedIndex;
            if (i >= 0)
            {
                string key = CheckedListClasses.Items[i].ToString();
                bool isChecked = e.NewValue == CheckState.Checked;
                _globals.ClassList.Add(key, isChecked ? "True" : "False");
                EventClassChange?.Invoke();
            }
        }
        
    }
}
