using System;
using Microsoft.VisualBasic;

namespace GenieClient
{
    public partial class FormConfig
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyChanges()
        {
            // MsgBox("Applying changes")
            if (UcWindows1.ItemChanged)
            {
                if (Interaction.MsgBox("Current window item has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcWindows1.ApplyChanges();
                }
            }

            if (UcAliases1.ItemChanged)
            {
                if (Interaction.MsgBox("Current alias has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcAliases1.ApplyChanges();
                }
            }

            if (UcSubs1.ItemChanged)
            {
                if (Interaction.MsgBox("Current substitute has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcSubs1.ApplyChanges();
                }
            }

            if (UcMacros1.ItemChanged)
            {
                if (Interaction.MsgBox("Current macro has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcMacros1.ApplyChanges();
                }
            }

            if (UcTriggers1.ItemChanged)
            {
                if (Interaction.MsgBox("Current trigger has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcTriggers1.ApplyChanges();
                }
            }

            if (UcIgnore1.ItemChanged)
            {
                if (Interaction.MsgBox("Current ignore/gag has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcIgnore1.ApplyChanges();
                }
            }

            if (UcVariables1.ItemChanged)
            {
                if (Interaction.MsgBox("Current variable has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcVariables1.ApplyChanges();
                }
            }

            if (UcPreset1.ItemChanged)
            {
                if (Interaction.MsgBox("Current preset has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcPreset1.ApplyChanges();
                }
            }

            if (UcName1.ItemChanged)
            {
                if (Interaction.MsgBox("Current name has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcName1.ApplyChanges();
                }
            }

            if (UcHighlightStrings1.ItemChanged)
            {
                if (Interaction.MsgBox("Current highlight has been changed. Apply changes?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    UcHighlightStrings1.ApplyChanges();
                }
            }

            // If TypeOf Me.ParentForm Is FormMain Then
            // CType(Me.ParentForm, FormMain).SaveXMLConfig()
            // End If

            UcMacros1.SaveToFile();
            UcAliases1.SaveToFile();
            UcSubs1.SaveToFile();
            UcTriggers1.SaveToFile();
            UcIgnore1.SaveToFile();
            UcVariables1.SaveToFile();
            UcPreset1.SaveToFile();
            UcName1.SaveToFile();
            UcHighlightStrings1.SaveToFile();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            if (ParentForm is FormMain)
            {
                FormMain oFormMain = (FormMain)ParentForm;
                UcWindows1.FormParent = oFormMain;
                UcPreset1.FormParent = oFormMain;
                UcWindowSettings1.FormParent = oFormMain;
                UcWindowSettings1.RefreshSettings();
                UcMacros1.MacroList = oFormMain.m_oGlobals.MacroList;
                UcAliases1.AliasList = oFormMain.m_oGlobals.AliasList;
                UcSubs1.Globals = oFormMain.m_oGlobals;
                UcSubs1.SubstituteList = oFormMain.m_oGlobals.SubstituteList;
                UcTriggers1.Globals = oFormMain.m_oGlobals;
                UcTriggers1.TriggerList = oFormMain.m_oGlobals.TriggerList;
                UcIgnore1.Globals = oFormMain.m_oGlobals;
                UcIgnore1.IgnoreList = oFormMain.m_oGlobals.GagList;
                UcVariables1.VariableList = oFormMain.m_oGlobals.VariableList;
                UcPreset1.PresetList = oFormMain.m_oGlobals.PresetList;
                UcName1.NameList = oFormMain.m_oGlobals.NameList;
                UcName1.Globals = oFormMain.m_oGlobals;													   
                UcHighlightStrings1.Globals = oFormMain.m_oGlobals;
                UcHighlightStrings1.HighlightList = oFormMain.m_oGlobals.HighlightList;
                UcHighlightStrings1.HighlightLineBeginsWith = oFormMain.m_oGlobals.HighlightBeginsWithList;
                UcHighlightStrings1.HighlightRegExp = oFormMain.m_oGlobals.HighlightRegExpList;
                UcPreset1.ColorDialogPicker.CustomColors = oFormMain.m_oGlobals.Config.PickerColors;
                UcName1.ColorDialogPicker.CustomColors = oFormMain.m_oGlobals.Config.PickerColors;
                UcHighlightStrings1.ColorDialogPicker.CustomColors = oFormMain.m_oGlobals.Config.PickerColors;
                UcHighlightStrings1.ItemChanged = false;
                UcWindows1.PopulateList();
            }
        }
    }
}