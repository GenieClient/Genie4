using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GenieClient
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ComponentBars : UserControl
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
            components = new System.ComponentModel.Container();
            _PanelBar = new Panel();
            _PanelBar.Paint += new PaintEventHandler(PanelBar_Paint);
            _LabelValue = new Label();
            _TimerRT = new Timer(components);
            _PanelBar.SuspendLayout();
            SuspendLayout();
            // 
            // PanelBar
            // 
            _PanelBar.Controls.Add(_LabelValue);
            _PanelBar.Dock = DockStyle.Fill;
            _PanelBar.Location = new Point(0, 0);
            _PanelBar.Margin = new Padding(0);
            _PanelBar.Name = "PanelBar";
            _PanelBar.Size = new Size(162, 20);
            _PanelBar.TabIndex = 0;
            // 
            // LabelValue
            // 
            _LabelValue.BackColor = Color.Transparent;
            _LabelValue.Dock = DockStyle.Fill;
            _LabelValue.ForeColor = Color.White;
            _LabelValue.Location = new Point(0, 0);
            _LabelValue.Name = "LabelValue";
            _LabelValue.Size = new Size(162, 20);
            _LabelValue.TabIndex = 0;
            _LabelValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TimerRT
            // 
            _TimerRT.Interval = 1000;
            // 
            // ComponentBars
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(_PanelBar);
            Margin = new Padding(0);
            Name = "ComponentBars";
            Size = new Size(162, 20);
            _PanelBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel _PanelBar;

        internal Panel PanelBar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelBar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelBar != null)
                {
                    _PanelBar.Paint -= PanelBar_Paint;
                }

                _PanelBar = value;
                if (_PanelBar != null)
                {
                    _PanelBar.Paint += PanelBar_Paint;
                }
            }
        }

        private Label _LabelValue;

        internal Label LabelValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelValue != null)
                {
                }

                _LabelValue = value;
                if (_LabelValue != null)
                {
                }
            }
        }

        private Timer _TimerRT;

        internal Timer TimerRT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TimerRT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TimerRT != null)
                {
                }

                _TimerRT = value;
                if (_TimerRT != null)
                {
                }
            }
        }
    }
}