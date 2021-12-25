using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class ComponentIconBar : UserControl
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
            _PictureBoxCompass = new PictureBox();
            _PictureBoxCompass.Paint += new PaintEventHandler(PictureBoxCompass_Paint);
            _ImageListIcons = new ImageList(components);
            _PictureBoxStatus = new PictureBox();
            _PictureBoxStunned = new PictureBox();
            _PictureBoxBleeding = new PictureBox();
            _PictureBoxInvisible = new PictureBox();
            _PictureBoxHidden = new PictureBox();
            _PictureBoxJoined = new PictureBox();
            _PictureBoxWebbed = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxCompass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxStunned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxBleeding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxInvisible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxHidden).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxJoined).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxWebbed).BeginInit();
            SuspendLayout();
            // 
            // PictureBoxCompass
            // 
            _PictureBoxCompass.Location = new Point(2, 0);
            _PictureBoxCompass.Name = "PictureBoxCompass";
            _PictureBoxCompass.Size = new Size(28, 32);
            _PictureBoxCompass.TabIndex = 0;
            _PictureBoxCompass.TabStop = false;
            // 
            // ImageListIcons
            // 
            _ImageListIcons.ColorDepth = ColorDepth.Depth8Bit;
            _ImageListIcons.ImageSize = new Size(28, 32);
            _ImageListIcons.TransparentColor = Color.Transparent;
            // 
            // PictureBoxStatus
            // 
            _PictureBoxStatus.Location = new Point(30, 0);
            _PictureBoxStatus.Name = "PictureBoxStatus";
            _PictureBoxStatus.Size = new Size(28, 32);
            _PictureBoxStatus.TabIndex = 1;
            _PictureBoxStatus.TabStop = false;
            // 
            // PictureBoxStunned
            // 
            _PictureBoxStunned.Location = new Point(58, 0);
            _PictureBoxStunned.Name = "PictureBoxStunned";
            _PictureBoxStunned.Size = new Size(28, 32);
            _PictureBoxStunned.TabIndex = 2;
            _PictureBoxStunned.TabStop = false;
            // 
            // PictureBoxBleeding
            // 
            _PictureBoxBleeding.Location = new Point(86, 0);
            _PictureBoxBleeding.Name = "PictureBoxBleeding";
            _PictureBoxBleeding.Size = new Size(28, 32);
            _PictureBoxBleeding.TabIndex = 3;
            _PictureBoxBleeding.TabStop = false;
            // 
            // PictureBoxInvisible
            // 
            _PictureBoxInvisible.Location = new Point(114, 0);
            _PictureBoxInvisible.Name = "PictureBoxInvisible";
            _PictureBoxInvisible.Size = new Size(28, 32);
            _PictureBoxInvisible.TabIndex = 4;
            _PictureBoxInvisible.TabStop = false;
            // 
            // PictureBoxHidden
            // 
            _PictureBoxHidden.Location = new Point(142, 0);
            _PictureBoxHidden.Name = "PictureBoxHidden";
            _PictureBoxHidden.Size = new Size(28, 32);
            _PictureBoxHidden.TabIndex = 5;
            _PictureBoxHidden.TabStop = false;
            // 
            // PictureBoxJoined
            // 
            _PictureBoxJoined.Location = new Point(170, 0);
            _PictureBoxJoined.Name = "PictureBoxJoined";
            _PictureBoxJoined.Size = new Size(28, 32);
            _PictureBoxJoined.TabIndex = 6;
            _PictureBoxJoined.TabStop = false;
            // 
            // PictureBoxWebbed
            // 
            _PictureBoxWebbed.Location = new Point(198, 0);
            _PictureBoxWebbed.Name = "PictureBoxWebbed";
            _PictureBoxWebbed.Size = new Size(28, 32);
            _PictureBoxWebbed.TabIndex = 7;
            _PictureBoxWebbed.TabStop = false;
            // 
            // ComponentIconBar
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(_PictureBoxWebbed);
            Controls.Add(_PictureBoxJoined);
            Controls.Add(_PictureBoxHidden);
            Controls.Add(_PictureBoxInvisible);
            Controls.Add(_PictureBoxBleeding);
            Controls.Add(_PictureBoxStunned);
            Controls.Add(_PictureBoxStatus);
            Controls.Add(_PictureBoxCompass);
            Margin = new Padding(0);
            Name = "ComponentIconBar";
            Size = new Size(229, 32);
            ((System.ComponentModel.ISupportInitialize)_PictureBoxCompass).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxStunned).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxBleeding).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxInvisible).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxHidden).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxJoined).EndInit();
            ((System.ComponentModel.ISupportInitialize)_PictureBoxWebbed).EndInit();
            Load += new EventHandler(ComponentIconBar_Load);
            ResumeLayout(false);
        }

        private PictureBox _PictureBoxCompass;

        internal PictureBox PictureBoxCompass
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxCompass;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxCompass != null)
                {
                    _PictureBoxCompass.Paint -= PictureBoxCompass_Paint;
                }

                _PictureBoxCompass = value;
                if (_PictureBoxCompass != null)
                {
                    _PictureBoxCompass.Paint += PictureBoxCompass_Paint;
                }
            }
        }

        private ImageList _ImageListIcons;

        internal ImageList ImageListIcons
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ImageListIcons;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ImageListIcons != null)
                {
                }

                _ImageListIcons = value;
                if (_ImageListIcons != null)
                {
                }
            }
        }

        private PictureBox _PictureBoxStatus;

        internal PictureBox PictureBoxStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxStatus != null)
                {
                }

                _PictureBoxStatus = value;
                if (_PictureBoxStatus != null)
                {
                }
            }
        }

        private PictureBox _PictureBoxStunned;

        internal PictureBox PictureBoxStunned
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxStunned;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxStunned != null)
                {
                }

                _PictureBoxStunned = value;
                if (_PictureBoxStunned != null)
                {
                }
            }
        }

        private PictureBox _PictureBoxBleeding;

        internal PictureBox PictureBoxBleeding
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxBleeding;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxBleeding != null)
                {
                }

                _PictureBoxBleeding = value;
                if (_PictureBoxBleeding != null)
                {
                }
            }
        }

        private PictureBox _PictureBoxInvisible;

        internal PictureBox PictureBoxInvisible
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxInvisible;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxInvisible != null)
                {
                }

                _PictureBoxInvisible = value;
                if (_PictureBoxInvisible != null)
                {
                }
            }
        }

        private PictureBox _PictureBoxHidden;

        internal PictureBox PictureBoxHidden
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxHidden;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxHidden != null)
                {
                }

                _PictureBoxHidden = value;
                if (_PictureBoxHidden != null)
                {
                }
            }
        }

        private PictureBox _PictureBoxJoined;

        internal PictureBox PictureBoxJoined
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxJoined;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxJoined != null)
                {
                }

                _PictureBoxJoined = value;
                if (_PictureBoxJoined != null)
                {
                }
            }
        }

        private PictureBox _PictureBoxWebbed;

        internal PictureBox PictureBoxWebbed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PictureBoxWebbed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PictureBoxWebbed != null)
                {
                }

                _PictureBoxWebbed = value;
                if (_PictureBoxWebbed != null)
                {
                }
            }
        }
    }
}