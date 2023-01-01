using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GenieClient
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class UCWindowSettings : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
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
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _ToolStripMenu = new ToolStrip();
            _ToolStripButtonRefresh = new ToolStripButton();
            _ToolStripButtonRefresh.Click += new EventHandler(ToolStripButtonRefresh_Click);
            _ToolStripSeparator1 = new ToolStripSeparator();
            _ToolStripButtonLoad = new ToolStripButton();
            _ToolStripButtonLoad.Click += new EventHandler(ToolStripButtonLoad_Click);
            _ToolStripButtonSave = new ToolStripButton();
            _ToolStripButtonSave.Click += new EventHandler(ToolStripButtonSave_Click);
            _ButtonMonoFont = new Button();
            _ButtonMonoFont.Click += new EventHandler(ButtonMonoFont_Click);
            _LabelFont = new Label();
            _TextBoxMonoFont = new TextBox();
            _ButtonApply = new Button();
            _ButtonApply.Click += new EventHandler(ButtonApply_Click);
            _FontDialogPicker = new FontDialog();
            _ButtonInputFont = new Button();
            _ButtonInputFont.Click += new EventHandler(ButtonInputFont_Click);
            _LabelInput = new Label();
            _TextBoxInputFont = new TextBox();
            _ToolStripMenu.SuspendLayout();
            SuspendLayout();
            // 
            // ToolStripMenu
            // 
            _ToolStripMenu.AllowMerge = false;
            _ToolStripMenu.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStripMenu.Items.AddRange(new ToolStripItem[] { _ToolStripButtonRefresh, _ToolStripSeparator1, _ToolStripButtonLoad, _ToolStripButtonSave });
            _ToolStripMenu.Location = new Point(0, 0);
            _ToolStripMenu.Name = "ToolStripMenu";
            _ToolStripMenu.Size = new Size(698, 25);
            _ToolStripMenu.TabIndex = 6;
            // 
            // ToolStripButtonRefresh
            // 
            _ToolStripButtonRefresh.Image = My.Resources.Resources.view_refresh;
            _ToolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRefresh.Name = "ToolStripButtonRefresh";
            _ToolStripButtonRefresh.Size = new Size(65, 22);
            _ToolStripButtonRefresh.Text = "Refresh";
            // 
            // ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripButtonLoad
            // 
            _ToolStripButtonLoad.Image = My.Resources.Resources.document_open;
            _ToolStripButtonLoad.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonLoad.Name = "ToolStripButtonLoad";
            _ToolStripButtonLoad.Size = new Size(50, 22);
            _ToolStripButtonLoad.Text = "Load";
            // 
            // ToolStripButtonSave
            // 
            _ToolStripButtonSave.Image = My.Resources.Resources.document_save;
            _ToolStripButtonSave.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonSave.Name = "ToolStripButtonSave";
            _ToolStripButtonSave.Size = new Size(51, 22);
            _ToolStripButtonSave.Text = "Save";
            // 
            // ButtonMonoFont
            // 
            _ButtonMonoFont.Image = My.Resources.Resources.font_x_generic;
            _ButtonMonoFont.ImageAlign = ContentAlignment.BottomLeft;
            _ButtonMonoFont.Location = new Point(173, 39);
            _ButtonMonoFont.Name = "ButtonMonoFont";
            _ButtonMonoFont.Size = new Size(75, 23);
            _ButtonMonoFont.TabIndex = 14;
            _ButtonMonoFont.Text = "Font";
            _ButtonMonoFont.UseVisualStyleBackColor = true;
            // 
            // LabelFont
            // 
            _LabelFont.AutoSize = true;
            _LabelFont.Location = new Point(3, 25);
            _LabelFont.Name = "LabelFont";
            _LabelFont.Size = new Size(58, 13);
            _LabelFont.TabIndex = 13;
            _LabelFont.Text = "Mono Font";
            // 
            // TextBoxMonoFont
            // 
            _TextBoxMonoFont.Location = new Point(3, 41);
            _TextBoxMonoFont.Name = "TextBoxMonoFont";
            _TextBoxMonoFont.ReadOnly = true;
            _TextBoxMonoFont.Size = new Size(168, 20);
            _TextBoxMonoFont.TabIndex = 12;
            // 
            // ButtonApply
            // 
            _ButtonApply.Location = new Point(3, 106);
            _ButtonApply.Name = "ButtonApply";
            _ButtonApply.Size = new Size(75, 23);
            _ButtonApply.TabIndex = 15;
            _ButtonApply.Text = "Apply";
            _ButtonApply.UseVisualStyleBackColor = true;
            // 
            // FontDialogPicker
            // 
            _FontDialogPicker.FontMustExist = true;
            _FontDialogPicker.ShowEffects = false;
            // 
            // ButtonInputFont
            // 
            _ButtonInputFont.Image = My.Resources.Resources.font_x_generic;
            _ButtonInputFont.ImageAlign = ContentAlignment.BottomLeft;
            _ButtonInputFont.Location = new Point(173, 78);
            _ButtonInputFont.Name = "ButtonInputFont";
            _ButtonInputFont.Size = new Size(75, 23);
            _ButtonInputFont.TabIndex = 18;
            _ButtonInputFont.Text = "Font";
            _ButtonInputFont.UseVisualStyleBackColor = true;
            // 
            // LabelInput
            // 
            _LabelInput.AutoSize = true;
            _LabelInput.Location = new Point(3, 64);
            _LabelInput.Name = "LabelInput";
            _LabelInput.Size = new Size(58, 13);
            _LabelInput.TabIndex = 17;
            _LabelInput.Text = "Mono Font";
            // 
            // TextBoxInputFont
            // 
            _TextBoxInputFont.Location = new Point(3, 80);
            _TextBoxInputFont.Name = "TextBoxInputFont";
            _TextBoxInputFont.ReadOnly = true;
            _TextBoxInputFont.Size = new Size(168, 20);
            _TextBoxInputFont.TabIndex = 16;
            // 
            // UCWindowSettings
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_ButtonInputFont);
            Controls.Add(_LabelInput);
            Controls.Add(_TextBoxInputFont);
            Controls.Add(_ButtonApply);
            Controls.Add(_ButtonMonoFont);
            Controls.Add(_LabelFont);
            Controls.Add(_TextBoxMonoFont);
            Controls.Add(_ToolStripMenu);
            Name = "UCWindowSettings";
            Size = new Size(698, 446);
            _ToolStripMenu.ResumeLayout(false);
            _ToolStripMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStrip _ToolStripMenu;

        internal ToolStrip ToolStripMenu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripMenu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripMenu != null)
                {
                }

                _ToolStripMenu = value;
                if (_ToolStripMenu != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonRefresh;

        internal ToolStripButton ToolStripButtonRefresh
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonRefresh;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonRefresh != null)
                {
                    _ToolStripButtonRefresh.Click -= ToolStripButtonRefresh_Click;
                }

                _ToolStripButtonRefresh = value;
                if (_ToolStripButtonRefresh != null)
                {
                    _ToolStripButtonRefresh.Click += ToolStripButtonRefresh_Click;
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator1;

        internal ToolStripSeparator ToolStripSeparator1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator1 != null)
                {
                }

                _ToolStripSeparator1 = value;
                if (_ToolStripSeparator1 != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonLoad;

        internal ToolStripButton ToolStripButtonLoad
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonLoad;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonLoad != null)
                {
                    _ToolStripButtonLoad.Click -= ToolStripButtonLoad_Click;
                }

                _ToolStripButtonLoad = value;
                if (_ToolStripButtonLoad != null)
                {
                    _ToolStripButtonLoad.Click += ToolStripButtonLoad_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonSave;

        internal ToolStripButton ToolStripButtonSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonSave != null)
                {
                    _ToolStripButtonSave.Click -= ToolStripButtonSave_Click;
                }

                _ToolStripButtonSave = value;
                if (_ToolStripButtonSave != null)
                {
                    _ToolStripButtonSave.Click += ToolStripButtonSave_Click;
                }
            }
        }

        private Button _ButtonMonoFont;

        internal Button ButtonMonoFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonMonoFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonMonoFont != null)
                {
                    _ButtonMonoFont.Click -= ButtonMonoFont_Click;
                }

                _ButtonMonoFont = value;
                if (_ButtonMonoFont != null)
                {
                    _ButtonMonoFont.Click += ButtonMonoFont_Click;
                }
            }
        }

        private Label _LabelFont;

        internal Label LabelFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelFont != null)
                {
                }

                _LabelFont = value;
                if (_LabelFont != null)
                {
                }
            }
        }

        private TextBox _TextBoxMonoFont;

        internal TextBox TextBoxMonoFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxMonoFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxMonoFont != null)
                {
                }

                _TextBoxMonoFont = value;
                if (_TextBoxMonoFont != null)
                {
                }
            }
        }

        private Button _ButtonApply;

        internal Button ButtonApply
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonApply;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonApply != null)
                {
                    _ButtonApply.Click -= ButtonApply_Click;
                }

                _ButtonApply = value;
                if (_ButtonApply != null)
                {
                    _ButtonApply.Click += ButtonApply_Click;
                }
            }
        }

        private FontDialog _FontDialogPicker;

        internal FontDialog FontDialogPicker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _FontDialogPicker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_FontDialogPicker != null)
                {
                }

                _FontDialogPicker = value;
                if (_FontDialogPicker != null)
                {
                }
            }
        }

        private Button _ButtonInputFont;

        internal Button ButtonInputFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonInputFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonInputFont != null)
                {
                    _ButtonInputFont.Click -= ButtonInputFont_Click;
                }

                _ButtonInputFont = value;
                if (_ButtonInputFont != null)
                {
                    _ButtonInputFont.Click += ButtonInputFont_Click;
                }
            }
        }

        private Label _LabelInput;

        internal Label LabelInput
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelInput;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelInput != null)
                {
                }

                _LabelInput = value;
                if (_LabelInput != null)
                {
                }
            }
        }

        private TextBox _TextBoxInputFont;

        internal TextBox TextBoxInputFont
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextBoxInputFont;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextBoxInputFont != null)
                {
                }

                _TextBoxInputFont = value;
                if (_TextBoxInputFont != null)
                {
                }
            }
        }
    }
}