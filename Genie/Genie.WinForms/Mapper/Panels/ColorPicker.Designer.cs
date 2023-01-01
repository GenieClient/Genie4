using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GenieClient
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ColorPicker : UserControl
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
        #pragma warning disable 0649
        private System.ComponentModel.IContainer components;
        #pragma warning restore 0649

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _LabelColor = new Label();
            _ButtonColor = new Button();
            _ButtonColor.Click += new EventHandler(ButtonColor_Click);
            _ColorDialogPicker = new ColorDialog();
            SuspendLayout();
            // 
            // LabelColor
            // 
            _LabelColor.BackColor = Color.White;
            _LabelColor.BorderStyle = BorderStyle.FixedSingle;
            _LabelColor.ForeColor = Color.Black;
            _LabelColor.Location = new Point(0, 0);
            _LabelColor.Name = "LabelColor";
            _LabelColor.Size = new Size(75, 21);
            _LabelColor.TabIndex = 13;
            _LabelColor.Text = "White";
            _LabelColor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonColor
            // 
            _ButtonColor.Image = My.Resources.Resources.applications_graphics;
            _ButtonColor.ImageAlign = ContentAlignment.BottomCenter;
            _ButtonColor.Location = new Point(78, 0);
            _ButtonColor.Name = "ButtonColor";
            _ButtonColor.Size = new Size(21, 21);
            _ButtonColor.TabIndex = 12;
            _ButtonColor.UseVisualStyleBackColor = true;
            // 
            // ColorDialogPicker
            // 
            _ColorDialogPicker.FullOpen = true;
            // 
            // ColorPicker
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_LabelColor);
            Controls.Add(_ButtonColor);
            Name = "ColorPicker";
            Size = new Size(100, 21);
            ResumeLayout(false);
        }

        private Label _LabelColor;

        internal Label LabelColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelColor != null)
                {
                }

                _LabelColor = value;
                if (_LabelColor != null)
                {
                }
            }
        }

        private Button _ButtonColor;

        internal Button ButtonColor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonColor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonColor != null)
                {
                    _ButtonColor.Click -= ButtonColor_Click;
                }

                _ButtonColor = value;
                if (_ButtonColor != null)
                {
                    _ButtonColor.Click += ButtonColor_Click;
                }
            }
        }

        private ColorDialog _ColorDialogPicker;

        internal ColorDialog ColorDialogPicker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ColorDialogPicker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ColorDialogPicker != null)
                {
                }

                _ColorDialogPicker = value;
                if (_ColorDialogPicker != null)
                {
                }
            }
        }
    }
}