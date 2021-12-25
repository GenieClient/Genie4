using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class ComponentPluginItem : UserControl
    {

        // UserControl overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentPluginItem));
            _Label1 = new Label();
            _ButtonEnable = new Button();
            _ButtonEnable.Click += new EventHandler(ButtonEnable_Click);
            _ButtonUnload = new Button();
            _ButtonUnload.Click += new EventHandler(ButtonUnload_Click);
            _ButtonDelete = new Button();
            _ButtonDelete.Click += new EventHandler(ButtonDelete_Click);
            _Label2 = new Label();
            _Label3 = new Label();
            _ButtonReload = new Button();
            _ButtonReload.Click += new EventHandler(ButtonReload_Click);
            SuspendLayout();
            // 
            // Label1
            // 
            _Label1.AutoSize = true;
            _Label1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(4, 4);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(45, 13);
            _Label1.TabIndex = 0;
            _Label1.Text = "Label1";
            // 
            // ButtonEnable
            // 
            _ButtonEnable.Location = new Point(7, 81);
            _ButtonEnable.Name = "ButtonEnable";
            _ButtonEnable.Size = new Size(75, 23);
            _ButtonEnable.TabIndex = 1;
            _ButtonEnable.Text = "Disable";
            _ButtonEnable.UseVisualStyleBackColor = true;
            // 
            // ButtonUnload
            // 
            _ButtonUnload.Location = new Point(169, 81);
            _ButtonUnload.Name = "ButtonUnload";
            _ButtonUnload.Size = new Size(75, 23);
            _ButtonUnload.TabIndex = 2;
            _ButtonUnload.Text = "Unload";
            _ButtonUnload.UseVisualStyleBackColor = true;
            // 
            // ButtonDelete
            // 
            _ButtonDelete.Location = new Point(250, 81);
            _ButtonDelete.Name = "ButtonDelete";
            _ButtonDelete.Size = new Size(75, 23);
            _ButtonDelete.TabIndex = 3;
            _ButtonDelete.Text = "Delete";
            _ButtonDelete.UseVisualStyleBackColor = true;
            _ButtonDelete.Visible = false;
            // 
            // Label2
            // 
            _Label2.AutoSize = true;
            _Label2.Location = new Point(4, 19);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(39, 13);
            _Label2.TabIndex = 4;
            _Label2.Text = "Label2";
            // 
            // Label3
            // 
            _Label3.Location = new Point(4, 35);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(341, 42);
            _Label3.TabIndex = 5;
            _Label3.Text = resources.GetString("Label3.Text");
            // 
            // ButtonReload
            // 
            _ButtonReload.Location = new Point(88, 81);
            _ButtonReload.Name = "ButtonReload";
            _ButtonReload.Size = new Size(75, 23);
            _ButtonReload.TabIndex = 6;
            _ButtonReload.Text = "Reload";
            _ButtonReload.UseVisualStyleBackColor = true;
            // 
            // ComponentPluginItem
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(_ButtonReload);
            Controls.Add(_Label3);
            Controls.Add(_Label2);
            Controls.Add(_ButtonDelete);
            Controls.Add(_ButtonUnload);
            Controls.Add(_ButtonEnable);
            Controls.Add(_Label1);
            MinimumSize = new Size(350, 2);
            Name = "ComponentPluginItem";
            Size = new Size(348, 110);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private Button _ButtonEnable;

        internal Button ButtonEnable
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonEnable;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonEnable != null)
                {
                    _ButtonEnable.Click -= ButtonEnable_Click;
                }

                _ButtonEnable = value;
                if (_ButtonEnable != null)
                {
                    _ButtonEnable.Click += ButtonEnable_Click;
                }
            }
        }

        private Button _ButtonUnload;

        internal Button ButtonUnload
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonUnload;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonUnload != null)
                {
                    _ButtonUnload.Click -= ButtonUnload_Click;
                }

                _ButtonUnload = value;
                if (_ButtonUnload != null)
                {
                    _ButtonUnload.Click += ButtonUnload_Click;
                }
            }
        }

        private Button _ButtonDelete;

        internal Button ButtonDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonDelete != null)
                {
                    _ButtonDelete.Click -= ButtonDelete_Click;
                }

                _ButtonDelete = value;
                if (_ButtonDelete != null)
                {
                    _ButtonDelete.Click += ButtonDelete_Click;
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private Button _ButtonReload;

        internal Button ButtonReload
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ButtonReload;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ButtonReload != null)
                {
                    _ButtonReload.Click -= ButtonReload_Click;
                }

                _ButtonReload = value;
                if (_ButtonReload != null)
                {
                    _ButtonReload.Click += ButtonReload_Click;
                }
            }
        }
    }
}