using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class FormConfig : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        #pragma warning disable 0649
        private System.ComponentModel.IContainer components;
        #pragma warning restore 0649

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            _TableLayoutPanel1 = new TableLayoutPanel();
            _Cancel_Button = new Button();
            _Cancel_Button.Click += new EventHandler(Cancel_Button_Click);
            _OK_Button = new Button();
            _OK_Button.Click += new EventHandler(OK_Button_Click);
            _Panel1 = new Panel();
            _TabControlMain = new TabControl();
            _TabPageWindows = new TabPage();
            _TabControlWindows = new TabControl();
            _TabPage1 = new TabPage();
            _UcWindows1 = new UCWindows();
            _TabPage2 = new TabPage();
            _UcWindowSettings1 = new UCWindowSettings();
            _TabPageHighlights = new TabPage();
            _TabControl2 = new TabControl();
            _TabPageString = new TabPage();
            _UcHighlightStrings1 = new UCHighlightStrings();
            _TabPageNames = new TabPage();
            _UcName1 = new UCName();
            _TabPagePreset = new TabPage();
            _UcPreset1 = new UCPreset();
            _TabPageTriggers = new TabPage();
            _UcTriggers1 = new UCTriggers();
            _TabPageMacros = new TabPage();
            _UcMacros1 = new UCMacros();
            _TabPageAliases = new TabPage();
            _UcAliases1 = new UCAliases();
            _TabPageSubs = new TabPage();
            _UcSubs1 = new UCSubs();
            _TabPageIgnores = new TabPage();
            _UcIgnore1 = new UCIgnore();
            _TabPageVars = new TabPage();
            _UcVariables1 = new UCVariables();
            _TabPageVariables = new TabPage();
            _TableLayoutPanel1.SuspendLayout();
            _Panel1.SuspendLayout();
            _TabControlMain.SuspendLayout();
            _TabPageWindows.SuspendLayout();
            _TabControlWindows.SuspendLayout();
            _TabPage1.SuspendLayout();
            _TabPage2.SuspendLayout();
            _TabPageHighlights.SuspendLayout();
            _TabControl2.SuspendLayout();
            _TabPageString.SuspendLayout();
            _TabPageNames.SuspendLayout();
            _TabPagePreset.SuspendLayout();
            _TabPageTriggers.SuspendLayout();
            _TabPageMacros.SuspendLayout();
            _TabPageAliases.SuspendLayout();
            _TabPageSubs.SuspendLayout();
            _TabPageIgnores.SuspendLayout();
            _TabPageVars.SuspendLayout();
            SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            _TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _TableLayoutPanel1.ColumnCount = 2;
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20.0F));
            _TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20.0F));
            _TableLayoutPanel1.Controls.Add(_Cancel_Button, 0, 0);
            _TableLayoutPanel1.Controls.Add(_OK_Button, 0, 0);
            _TableLayoutPanel1.Location = new Point(508, 3);
            _TableLayoutPanel1.Name = "TableLayoutPanel1";
            _TableLayoutPanel1.RowCount = 1;
            _TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0F));
            _TableLayoutPanel1.Size = new Size(154, 29);
            _TableLayoutPanel1.TabIndex = 1;
            // 
            // Cancel_Button
            // 
            _Cancel_Button.Anchor = AnchorStyles.None;
            _Cancel_Button.DialogResult = DialogResult.Cancel;
            _Cancel_Button.Location = new Point(82, 3);
            _Cancel_Button.Name = "Cancel_Button";
            _Cancel_Button.Size = new Size(67, 23);
            _Cancel_Button.TabIndex = 1;
            _Cancel_Button.Text = "Cancel";
            // 
            // OK_Button
            // 
            _OK_Button.Anchor = AnchorStyles.None;
            _OK_Button.Location = new Point(5, 3);
            _OK_Button.Name = "OK_Button";
            _OK_Button.Size = new Size(67, 23);
            _OK_Button.TabIndex = 0;
            _OK_Button.Text = "OK";
            // 
            // Panel1
            // 
            _Panel1.Controls.Add(_TableLayoutPanel1);
            _Panel1.Dock = DockStyle.Bottom;
            _Panel1.Location = new Point(0, 480);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(665, 35);
            _Panel1.TabIndex = 2;
            // 
            // TabControlMain
            // 
            _TabControlMain.Controls.Add(_TabPageWindows);
            _TabControlMain.Controls.Add(_TabPageHighlights);
            _TabControlMain.Controls.Add(_TabPageTriggers);
            _TabControlMain.Controls.Add(_TabPageSubs);
            _TabControlMain.Controls.Add(_TabPageIgnores);
            _TabControlMain.Controls.Add(_TabPageAliases);
            _TabControlMain.Controls.Add(_TabPageMacros);
            _TabControlMain.Controls.Add(_TabPageVars);
            _TabControlMain.Dock = DockStyle.Fill;
            _TabControlMain.Location = new Point(0, 0);
            _TabControlMain.Name = "TabControlMain";
            _TabControlMain.SelectedIndex = 0;
            _TabControlMain.Size = new Size(665, 480);
            _TabControlMain.TabIndex = 3;
            // 
            // TabPageWindows
            // 
            _TabPageWindows.Controls.Add(_TabControlWindows);
            _TabPageWindows.Location = new Point(4, 22);
            _TabPageWindows.Name = "TabPageWindows";
            _TabPageWindows.Size = new Size(657, 454);
            _TabPageWindows.TabIndex = 8;
            _TabPageWindows.Text = "Layout";
            _TabPageWindows.UseVisualStyleBackColor = true;
            // 
            // TabControlWindows
            // 
            _TabControlWindows.Controls.Add(_TabPage1);
            _TabControlWindows.Controls.Add(_TabPage2);
            _TabControlWindows.Dock = DockStyle.Fill;
            _TabControlWindows.Location = new Point(0, 0);
            _TabControlWindows.Name = "TabControlWindows";
            _TabControlWindows.SelectedIndex = 0;
            _TabControlWindows.Size = new Size(657, 454);
            _TabControlWindows.TabIndex = 1;
            // 
            // TabPage1
            // 
            _TabPage1.Controls.Add(_UcWindows1);
            _TabPage1.Location = new Point(4, 22);
            _TabPage1.Name = "TabPage1";
            _TabPage1.Padding = new Padding(3);
            _TabPage1.Size = new Size(649, 428);
            _TabPage1.TabIndex = 0;
            _TabPage1.Text = "Windows";
            _TabPage1.UseVisualStyleBackColor = true;
            // 
            // UcWindows1
            // 
            _UcWindows1.Dock = DockStyle.Fill;
            _UcWindows1.FormParent = null;
            _UcWindows1.Location = new Point(3, 3);
            _UcWindows1.Name = "UcWindows1";
            _UcWindows1.Size = new Size(643, 422);
            _UcWindows1.TabIndex = 0;
            // 
            // TabPage2
            // 
            _TabPage2.Controls.Add(_UcWindowSettings1);
            _TabPage2.Location = new Point(4, 22);
            _TabPage2.Name = "TabPage2";
            _TabPage2.Padding = new Padding(3);
            _TabPage2.Size = new Size(649, 428);
            _TabPage2.TabIndex = 1;
            _TabPage2.Text = "Settings";
            _TabPage2.UseVisualStyleBackColor = true;
            // 
            // UcWindowSettings1
            // 
            _UcWindowSettings1.Dock = DockStyle.Fill;
            _UcWindowSettings1.FormParent = null;
            _UcWindowSettings1.Location = new Point(3, 3);
            _UcWindowSettings1.Name = "UcWindowSettings1";
            _UcWindowSettings1.Size = new Size(643, 422);
            _UcWindowSettings1.TabIndex = 0;
            // 
            // TabPageHighlights
            // 
            _TabPageHighlights.Controls.Add(_TabControl2);
            _TabPageHighlights.Location = new Point(4, 22);
            _TabPageHighlights.Name = "TabPageHighlights";
            _TabPageHighlights.Padding = new Padding(3);
            _TabPageHighlights.Size = new Size(657, 454);
            _TabPageHighlights.TabIndex = 1;
            _TabPageHighlights.Text = "Highlights";
            _TabPageHighlights.UseVisualStyleBackColor = true;
            // 
            // TabControl2
            // 
            _TabControl2.Controls.Add(_TabPageString);
            _TabControl2.Controls.Add(_TabPageNames);
            _TabControl2.Controls.Add(_TabPagePreset);
            _TabControl2.Dock = DockStyle.Fill;
            _TabControl2.Location = new Point(3, 3);
            _TabControl2.Name = "TabControl2";
            _TabControl2.SelectedIndex = 0;
            _TabControl2.Size = new Size(651, 448);
            _TabControl2.TabIndex = 0;
            // 
            // TabPageString
            // 
            _TabPageString.Controls.Add(_UcHighlightStrings1);
            _TabPageString.Location = new Point(4, 22);
            _TabPageString.Name = "TabPageString";
            _TabPageString.Size = new Size(643, 422);
            _TabPageString.TabIndex = 4;
            _TabPageString.Text = "Strings";
            _TabPageString.UseVisualStyleBackColor = true;
            // 
            // UcHighlightStrings1
            // 
            _UcHighlightStrings1.Dock = DockStyle.Fill;
            _UcHighlightStrings1.Globals = null;
            _UcHighlightStrings1.HighlightLineBeginsWith = null;
            _UcHighlightStrings1.HighlightList = null;
            _UcHighlightStrings1.HighlightRegExp = null;
            _UcHighlightStrings1.ItemChanged = false;
            _UcHighlightStrings1.Location = new Point(0, 0);
            _UcHighlightStrings1.Name = "UcHighlightStrings1";
            _UcHighlightStrings1.Size = new Size(643, 422);
            _UcHighlightStrings1.TabIndex = 2;
            // 
            // TabPageNames
            // 
            _TabPageNames.Controls.Add(_UcName1);
            _TabPageNames.Location = new Point(4, 22);
            _TabPageNames.Name = "TabPageNames";
            _TabPageNames.Size = new Size(643, 422);
            _TabPageNames.TabIndex = 2;
            _TabPageNames.Text = "Names";
            _TabPageNames.UseVisualStyleBackColor = true;
            // 
            // UcName1
            // 
            _UcName1.Dock = DockStyle.Fill;
            _UcName1.Location = new Point(0, 0);
            _UcName1.Name = "UcName1";
            _UcName1.NameList = null;
            _UcName1.Size = new Size(643, 422);
            _UcName1.TabIndex = 1;
            // 
            // TabPagePreset
            // 
            _TabPagePreset.Controls.Add(_UcPreset1);
            _TabPagePreset.Location = new Point(4, 22);
            _TabPagePreset.Name = "TabPagePreset";
            _TabPagePreset.Size = new Size(643, 422);
            _TabPagePreset.TabIndex = 3;
            _TabPagePreset.Text = "Presets";
            _TabPagePreset.UseVisualStyleBackColor = true;
            // 
            // UcPreset1
            // 
            _UcPreset1.Dock = DockStyle.Fill;
            _UcPreset1.FormParent = null;
            _UcPreset1.Location = new Point(0, 0);
            _UcPreset1.Name = "UcPreset1";
            _UcPreset1.PresetList = null;
            _UcPreset1.Size = new Size(643, 422);
            _UcPreset1.TabIndex = 3;
            // 
            // TabPageTriggers
            // 
            _TabPageTriggers.Controls.Add(_UcTriggers1);
            _TabPageTriggers.Location = new Point(4, 22);
            _TabPageTriggers.Name = "TabPageTriggers";
            _TabPageTriggers.Size = new Size(657, 454);
            _TabPageTriggers.TabIndex = 6;
            _TabPageTriggers.Text = "Triggers";
            _TabPageTriggers.UseVisualStyleBackColor = true;
            // 
            // UcTriggers1
            // 
            _UcTriggers1.Dock = DockStyle.Fill;
            _UcTriggers1.Location = new Point(0, 0);
            _UcTriggers1.Name = "UcTriggers1";
            _UcTriggers1.Size = new Size(657, 454);
            _UcTriggers1.TabIndex = 0;
            _UcTriggers1.TriggerList = null;
            // 
            // TabPageMacros
            // 
            _TabPageMacros.Controls.Add(_UcMacros1);
            _TabPageMacros.Location = new Point(4, 22);
            _TabPageMacros.Name = "TabPageMacros";
            _TabPageMacros.Size = new Size(657, 454);
            _TabPageMacros.TabIndex = 5;
            _TabPageMacros.Text = "Macros";
            _TabPageMacros.UseVisualStyleBackColor = true;
            // 
            // UcMacros1
            // 
            _UcMacros1.Dock = DockStyle.Fill;
            _UcMacros1.Location = new Point(0, 0);
            _UcMacros1.MacroList = null;
            _UcMacros1.Name = "UcMacros1";
            _UcMacros1.Size = new Size(657, 454);
            _UcMacros1.TabIndex = 0;
            // 
            // TabPageAliases
            // 
            _TabPageAliases.Controls.Add(_UcAliases1);
            _TabPageAliases.Location = new Point(4, 22);
            _TabPageAliases.Name = "TabPageAliases";
            _TabPageAliases.Size = new Size(657, 454);
            _TabPageAliases.TabIndex = 4;
            _TabPageAliases.Text = "Aliases";
            _TabPageAliases.UseVisualStyleBackColor = true;
            // 
            // UcAliases1
            // 
            _UcAliases1.AliasList = null;
            _UcAliases1.Dock = DockStyle.Fill;
            _UcAliases1.Location = new Point(0, 0);
            _UcAliases1.Name = "UcAliases1";
            _UcAliases1.Size = new Size(657, 454);
            _UcAliases1.TabIndex = 0;
            // 
            // TabPageSubs
            // 
            _TabPageSubs.Controls.Add(_UcSubs1);
            _TabPageSubs.Location = new Point(4, 22);
            _TabPageSubs.Name = "TabPageSubs";
            _TabPageSubs.Size = new Size(657, 454);
            _TabPageSubs.TabIndex = 2;
            _TabPageSubs.Text = "Substitutes";
            _TabPageSubs.UseVisualStyleBackColor = true;
            // 
            // UcSubs1
            // 
            _UcSubs1.Dock = DockStyle.Fill;
            _UcSubs1.Location = new Point(0, 0);
            _UcSubs1.Name = "UcSubs1";
            _UcSubs1.Size = new Size(657, 454);
            _UcSubs1.SubstituteList = null;
            _UcSubs1.TabIndex = 0;
            // 
            // TabPageIgnores
            // 
            _TabPageIgnores.Controls.Add(_UcIgnore1);
            _TabPageIgnores.Location = new Point(4, 22);
            _TabPageIgnores.Name = "TabPageIgnores";
            _TabPageIgnores.Size = new Size(657, 454);
            _TabPageIgnores.TabIndex = 3;
            _TabPageIgnores.Text = "Gags";
            _TabPageIgnores.UseVisualStyleBackColor = true;
            // 
            // UcIgnore1
            // 
            _UcIgnore1.Dock = DockStyle.Fill;
            _UcIgnore1.IgnoreList = null;
            _UcIgnore1.Location = new Point(0, 0);
            _UcIgnore1.Name = "UcIgnore1";
            _UcIgnore1.Size = new Size(657, 454);
            _UcIgnore1.TabIndex = 1;
            // 
            // TabPageVars
            // 
            _TabPageVars.Controls.Add(_UcVariables1);
            _TabPageVars.Location = new Point(4, 22);
            _TabPageVars.Name = "TabPageVars";
            _TabPageVars.Size = new Size(657, 454);
            _TabPageVars.TabIndex = 9;
            _TabPageVars.Text = "Variables";
            _TabPageVars.UseVisualStyleBackColor = true;
            // 
            // UcVariables1
            // 
            _UcVariables1.Dock = DockStyle.Fill;
            _UcVariables1.Location = new Point(0, 0);
            _UcVariables1.Name = "UcVariables1";
            _UcVariables1.Size = new Size(657, 454);
            _UcVariables1.TabIndex = 0;
            _UcVariables1.VariableList = null;
            // 
            // TabPageVariables
            // 
            _TabPageVariables.Location = new Point(4, 22);
            _TabPageVariables.Name = "TabPageVariables";
            _TabPageVariables.Size = new Size(654, 378);
            _TabPageVariables.TabIndex = 9;
            _TabPageVariables.Text = "Variables";
            _TabPageVariables.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 515);
            Controls.Add(_TabControlMain);
            Controls.Add(_Panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfig";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuration";
            TopMost = true;
            _TableLayoutPanel1.ResumeLayout(false);
            _Panel1.ResumeLayout(false);
            _TabControlMain.ResumeLayout(false);
            _TabPageWindows.ResumeLayout(false);
            _TabControlWindows.ResumeLayout(false);
            _TabPage1.ResumeLayout(false);
            _TabPage2.ResumeLayout(false);
            _TabPageHighlights.ResumeLayout(false);
            _TabControl2.ResumeLayout(false);
            _TabPageString.ResumeLayout(false);
            _TabPageNames.ResumeLayout(false);
            _TabPagePreset.ResumeLayout(false);
            _TabPageTriggers.ResumeLayout(false);
            _TabPageMacros.ResumeLayout(false);
            _TabPageAliases.ResumeLayout(false);
            _TabPageSubs.ResumeLayout(false);
            _TabPageIgnores.ResumeLayout(false);
            _TabPageVars.ResumeLayout(false);
            Load += new EventHandler(FormConfig_Load);
            ResumeLayout(false);
        }

        private TableLayoutPanel _TableLayoutPanel1;

        internal TableLayoutPanel TableLayoutPanel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TableLayoutPanel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TableLayoutPanel1 != null)
                {
                }

                _TableLayoutPanel1 = value;
                if (_TableLayoutPanel1 != null)
                {
                }
            }
        }

        private Button _Cancel_Button;

        internal Button Cancel_Button
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Cancel_Button;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Cancel_Button != null)
                {
                    _Cancel_Button.Click -= Cancel_Button_Click;
                }

                _Cancel_Button = value;
                if (_Cancel_Button != null)
                {
                    _Cancel_Button.Click += Cancel_Button_Click;
                }
            }
        }

        private Button _OK_Button;

        internal Button OK_Button
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OK_Button;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OK_Button != null)
                {
                    _OK_Button.Click -= OK_Button_Click;
                }

                _OK_Button = value;
                if (_OK_Button != null)
                {
                    _OK_Button.Click += OK_Button_Click;
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

        private TabControl _TabControlMain;

        internal TabControl TabControlMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControlMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControlMain != null)
                {
                }

                _TabControlMain = value;
                if (_TabControlMain != null)
                {
                }
            }
        }

        private TabPage _TabPageHighlights;

        internal TabPage TabPageHighlights
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageHighlights;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageHighlights != null)
                {
                }

                _TabPageHighlights = value;
                if (_TabPageHighlights != null)
                {
                }
            }
        }

        private TabPage _TabPageSubs;

        internal TabPage TabPageSubs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageSubs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageSubs != null)
                {
                }

                _TabPageSubs = value;
                if (_TabPageSubs != null)
                {
                }
            }
        }

        private TabPage _TabPageIgnores;

        internal TabPage TabPageIgnores
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageIgnores;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageIgnores != null)
                {
                }

                _TabPageIgnores = value;
                if (_TabPageIgnores != null)
                {
                }
            }
        }

        private TabPage _TabPageAliases;

        internal TabPage TabPageAliases
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageAliases;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageAliases != null)
                {
                }

                _TabPageAliases = value;
                if (_TabPageAliases != null)
                {
                }
            }
        }

        private TabPage _TabPageMacros;

        internal TabPage TabPageMacros
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageMacros;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageMacros != null)
                {
                }

                _TabPageMacros = value;
                if (_TabPageMacros != null)
                {
                }
            }
        }

        private TabPage _TabPageTriggers;

        internal TabPage TabPageTriggers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageTriggers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageTriggers != null)
                {
                }

                _TabPageTriggers = value;
                if (_TabPageTriggers != null)
                {
                }
            }
        }

        private TabControl _TabControl2;

        internal TabControl TabControl2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl2 != null)
                {
                }

                _TabControl2 = value;
                if (_TabControl2 != null)
                {
                }
            }
        }

        private TabPage _TabPageNames;

        internal TabPage TabPageNames
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageNames;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageNames != null)
                {
                }

                _TabPageNames = value;
                if (_TabPageNames != null)
                {
                }
            }
        }

        private TabPage _TabPageWindows;

        internal TabPage TabPageWindows
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageWindows;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageWindows != null)
                {
                }

                _TabPageWindows = value;
                if (_TabPageWindows != null)
                {
                }
            }
        }

        private TabPage _TabPageVariables;

        internal TabPage TabPageVariables
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageVariables;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageVariables != null)
                {
                }

                _TabPageVariables = value;
                if (_TabPageVariables != null)
                {
                }
            }
        }

        private UCWindows _UcWindows1;

        internal UCWindows UcWindows1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcWindows1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcWindows1 != null)
                {
                }

                _UcWindows1 = value;
                if (_UcWindows1 != null)
                {
                }
            }
        }

        private UCMacros _UcMacros1;

        internal UCMacros UcMacros1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcMacros1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcMacros1 != null)
                {
                }

                _UcMacros1 = value;
                if (_UcMacros1 != null)
                {
                }
            }
        }

        private UCAliases _UcAliases1;

        internal UCAliases UcAliases1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcAliases1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcAliases1 != null)
                {
                }

                _UcAliases1 = value;
                if (_UcAliases1 != null)
                {
                }
            }
        }

        private UCSubs _UcSubs1;

        internal UCSubs UcSubs1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcSubs1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcSubs1 != null)
                {
                }

                _UcSubs1 = value;
                if (_UcSubs1 != null)
                {
                }
            }
        }

        private UCTriggers _UcTriggers1;

        internal UCTriggers UcTriggers1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcTriggers1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcTriggers1 != null)
                {
                }

                _UcTriggers1 = value;
                if (_UcTriggers1 != null)
                {
                }
            }
        }

        private UCIgnore _UcIgnore1;

        internal UCIgnore UcIgnore1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcIgnore1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcIgnore1 != null)
                {
                }

                _UcIgnore1 = value;
                if (_UcIgnore1 != null)
                {
                }
            }
        }

        private TabPage _TabPageVars;

        internal TabPage TabPageVars
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageVars;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageVars != null)
                {
                }

                _TabPageVars = value;
                if (_TabPageVars != null)
                {
                }
            }
        }

        private UCVariables _UcVariables1;

        internal UCVariables UcVariables1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcVariables1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcVariables1 != null)
                {
                }

                _UcVariables1 = value;
                if (_UcVariables1 != null)
                {
                }
            }
        }

        private UCName _UcName1;

        internal UCName UcName1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcName1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcName1 != null)
                {
                }

                _UcName1 = value;
                if (_UcName1 != null)
                {
                }
            }
        }

        private TabPage _TabPagePreset;

        internal TabPage TabPagePreset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPagePreset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPagePreset != null)
                {
                }

                _TabPagePreset = value;
                if (_TabPagePreset != null)
                {
                }
            }
        }

        private UCPreset _UcPreset1;

        internal UCPreset UcPreset1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcPreset1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcPreset1 != null)
                {
                }

                _UcPreset1 = value;
                if (_UcPreset1 != null)
                {
                }
            }
        }

        private TabPage _TabPageString;

        internal TabPage TabPageString
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPageString;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPageString != null)
                {
                }

                _TabPageString = value;
                if (_TabPageString != null)
                {
                }
            }
        }

        private UCHighlightStrings _UcHighlightStrings1;

        internal UCHighlightStrings UcHighlightStrings1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcHighlightStrings1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcHighlightStrings1 != null)
                {
                }

                _UcHighlightStrings1 = value;
                if (_UcHighlightStrings1 != null)
                {
                }
            }
        }

        private TabControl _TabControlWindows;

        internal TabControl TabControlWindows
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControlWindows;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControlWindows != null)
                {
                }

                _TabControlWindows = value;
                if (_TabControlWindows != null)
                {
                }
            }
        }

        private TabPage _TabPage1;

        internal TabPage TabPage1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPage1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPage1 != null)
                {
                }

                _TabPage1 = value;
                if (_TabPage1 != null)
                {
                }
            }
        }

        private TabPage _TabPage2;

        internal TabPage TabPage2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPage2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPage2 != null)
                {
                }

                _TabPage2 = value;
                if (_TabPage2 != null)
                {
                }
            }
        }

        private UCWindowSettings _UcWindowSettings1;

        internal UCWindowSettings UcWindowSettings1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UcWindowSettings1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UcWindowSettings1 != null)
                {
                }

                _UcWindowSettings1 = value;
                if (_UcWindowSettings1 != null)
                {
                }
            }
        }
    }
}