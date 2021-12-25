using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class ComponentRoundtime : UserControl
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
            _PanelRT = new Panel();
            _PanelRT.Paint += new PaintEventHandler(PanelRT_Paint);
            _LabelRT = new Label();
            _TimerRT = new Timer(components);
            _TimerRT.Tick += new EventHandler(TimerRT_Tick);
            _PanelRT.SuspendLayout();
            SuspendLayout();
            // 
            // PanelRT
            // 
            _PanelRT.Controls.Add(_LabelRT);
            _PanelRT.Dock = DockStyle.Fill;
            _PanelRT.Location = new Point(0, 0);
            _PanelRT.Name = "PanelRT";
            _PanelRT.Size = new Size(127, 33);
            _PanelRT.TabIndex = 0;
            // 
            // LabelRT
            // 
            _LabelRT.BackColor = Color.Transparent;
            _LabelRT.Dock = DockStyle.Fill;
            _LabelRT.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _LabelRT.ForeColor = Color.White;
            _LabelRT.Location = new Point(0, 0);
            _LabelRT.Name = "LabelRT";
            _LabelRT.Size = new Size(127, 33);
            _LabelRT.TabIndex = 0;
            _LabelRT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TimerRT
            // 
            _TimerRT.Interval = 1000;
            // 
            // ComponentRoundtime
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(_PanelRT);
            Name = "ComponentRoundtime";
            Size = new Size(127, 33);
            _PanelRT.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel _PanelRT;

        internal Panel PanelRT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PanelRT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PanelRT != null)
                {
                    _PanelRT.Paint -= PanelRT_Paint;
                }

                _PanelRT = value;
                if (_PanelRT != null)
                {
                    _PanelRT.Paint += PanelRT_Paint;
                }
            }
        }

        private Label _LabelRT;

        internal Label LabelRT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LabelRT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LabelRT != null)
                {
                }

                _LabelRT = value;
                if (_LabelRT != null)
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
                    _TimerRT.Tick -= TimerRT_Tick;
                }

                _TimerRT = value;
                if (_TimerRT != null)
                {
                    _TimerRT.Tick += TimerRT_Tick;
                }
            }
        }
    }
}