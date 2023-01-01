using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    [DesignerGenerated()]
    public partial class ScriptExplorer : Form
    {

        // Form overrides dispose to clean up the component list.
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

        private ToolStripContainer _ToolStripContainer;

        internal ToolStripContainer ToolStripContainer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripContainer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripContainer != null)
                {
                }

                _ToolStripContainer = value;
                if (_ToolStripContainer != null)
                {
                }
            }
        }

        private ImageList _TreeNodeImageList;

        internal ImageList TreeNodeImageList
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TreeNodeImageList;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TreeNodeImageList != null)
                {
                }

                _TreeNodeImageList = value;
                if (_TreeNodeImageList != null)
                {
                }
            }
        }

        private ToolTip _ToolTip;

        internal ToolTip ToolTip
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolTip;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolTip != null)
                {
                }

                _ToolTip = value;
                if (_ToolTip != null)
                {
                }
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptExplorer));
            _TreeNodeImageList = new ImageList(components);
            _ToolTip = new ToolTip(components);
            _ToolStripContainer = new ToolStripContainer();
            _TreeView = new TreeView();
            _TreeView.AfterSelect += new TreeViewEventHandler(TreeView_AfterSelect);
            _TreeView.KeyUp += new KeyEventHandler(TreeView_KeyUp);
            _ToolStrip = new ToolStrip();
            _ToolStripButtonRefresh = new ToolStripButton();
            _ToolStripButtonRefresh.Click += new EventHandler(ToolStripButtonRefresh_Click);
            _ToolStripSeparator1 = new ToolStripSeparator();
            _ToolStripButtonNew = new ToolStripButton();
            _ToolStripButtonNew.Click += new EventHandler(ToolStripButtonNew_Click);
            _ToolStripSeparator2 = new ToolStripSeparator();
            _ToolStripButtonRun = new ToolStripButton();
            _ToolStripButtonRun.Click += new EventHandler(ToolStripButtonRun_Click);
            _ToolStripButtonEdit = new ToolStripButton();
            _ToolStripButtonEdit.Click += new EventHandler(ToolStripButtonEdit_Click);
            _ToolStripButtonRemove = new ToolStripButton();
            _ToolStripButtonRemove.Click += new EventHandler(ToolStripButtonRemove_Click);
            _ToolStripContainer.ContentPanel.SuspendLayout();
            _ToolStripContainer.TopToolStripPanel.SuspendLayout();
            _ToolStripContainer.SuspendLayout();
            _ToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // TreeNodeImageList
            // 
            _TreeNodeImageList.ImageStream = (ImageListStreamer)resources.GetObject("TreeNodeImageList.ImageStream");
            _TreeNodeImageList.TransparentColor = Color.Transparent;
            _TreeNodeImageList.Images.SetKeyName(0, "ClosedFolder");
            _TreeNodeImageList.Images.SetKeyName(1, "OpenFolder");
            _TreeNodeImageList.Images.SetKeyName(2, "text-x-script.png");
            _TreeNodeImageList.Images.SetKeyName(3, "ClosedFolderAlt");
            _TreeNodeImageList.Images.SetKeyName(4, "OpenFolderAlt");
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            _ToolStripContainer.ContentPanel.Controls.Add(_TreeView);
            _ToolStripContainer.ContentPanel.Size = new Size(503, 408);
            _ToolStripContainer.Dock = DockStyle.Fill;
            _ToolStripContainer.Location = new Point(0, 0);
            _ToolStripContainer.Name = "ToolStripContainer";
            _ToolStripContainer.Size = new Size(503, 433);
            _ToolStripContainer.TabIndex = 7;
            _ToolStripContainer.Text = "ToolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            _ToolStripContainer.TopToolStripPanel.Controls.Add(_ToolStrip);
            // 
            // TreeView
            // 
            _TreeView.Dock = DockStyle.Fill;
            _TreeView.HideSelection = false;
            _TreeView.ImageIndex = 0;
            _TreeView.ImageList = _TreeNodeImageList;
            _TreeView.Location = new Point(0, 0);
            _TreeView.Name = "TreeView";
            _TreeView.SelectedImageIndex = 1;
            _TreeView.Size = new Size(503, 408);
            _TreeView.TabIndex = 4;
            // 
            // ToolStrip
            // 
            _ToolStrip.Dock = DockStyle.None;
            _ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            _ToolStrip.Items.AddRange(new ToolStripItem[] { _ToolStripButtonRefresh, _ToolStripSeparator1, _ToolStripButtonNew, _ToolStripSeparator2, _ToolStripButtonRun, _ToolStripButtonEdit, _ToolStripButtonRemove });
            _ToolStrip.Location = new Point(3, 0);
            _ToolStrip.Name = "ToolStrip";
            _ToolStrip.Size = new Size(419, 25);
            _ToolStrip.TabIndex = 4;
            _ToolStrip.Text = "ToolStrip1";
            // 
            // ToolStripButtonRefresh
            // 
            _ToolStripButtonRefresh.Image = My.Resources.Resources.view_refresh;
            _ToolStripButtonRefresh.ImageAlign = ContentAlignment.MiddleLeft;
            _ToolStripButtonRefresh.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRefresh.Name = "ToolStripButtonRefresh";
            _ToolStripButtonRefresh.Size = new Size(66, 22);
            _ToolStripButtonRefresh.Text = "Refresh";
            _ToolStripButtonRefresh.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "ToolStripSeparator1";
            _ToolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolStripButtonNew
            // 
            _ToolStripButtonNew.Image = My.Resources.Resources.document_new;
            _ToolStripButtonNew.ImageAlign = ContentAlignment.MiddleLeft;
            _ToolStripButtonNew.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonNew.Name = "ToolStripButtonNew";
            _ToolStripButtonNew.Size = new Size(84, 22);
            _ToolStripButtonNew.Text = "New Script";
            _ToolStripButtonNew.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStripSeparator2
            // 
            _ToolStripSeparator2.Name = "ToolStripSeparator2";
            _ToolStripSeparator2.Size = new Size(6, 25);
            // 
            // ToolStripButtonRun
            // 
            _ToolStripButtonRun.Enabled = false;
            _ToolStripButtonRun.Image = My.Resources.Resources.text_x_script;
            _ToolStripButtonRun.ImageAlign = ContentAlignment.MiddleLeft;
            _ToolStripButtonRun.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRun.Name = "ToolStripButtonRun";
            _ToolStripButtonRun.Size = new Size(81, 22);
            _ToolStripButtonRun.Text = "Run Script";
            _ToolStripButtonRun.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStripButtonEdit
            // 
            _ToolStripButtonEdit.Enabled = false;
            _ToolStripButtonEdit.Image = My.Resources.Resources.accessories_text_editor;
            _ToolStripButtonEdit.ImageAlign = ContentAlignment.MiddleLeft;
            _ToolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonEdit.Name = "ToolStripButtonEdit";
            _ToolStripButtonEdit.Size = new Size(80, 22);
            _ToolStripButtonEdit.Text = "Edit Script";
            _ToolStripButtonEdit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolStripButtonRemove
            // 
            _ToolStripButtonRemove.Enabled = false;
            _ToolStripButtonRemove.Image = My.Resources.Resources.edit_clear;
            _ToolStripButtonRemove.ImageAlign = ContentAlignment.MiddleLeft;
            _ToolStripButtonRemove.ImageTransparentColor = Color.Magenta;
            _ToolStripButtonRemove.Name = "ToolStripButtonRemove";
            _ToolStripButtonRemove.Size = new Size(93, 22);
            _ToolStripButtonRemove.Text = "Delete Script";
            _ToolStripButtonRemove.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ScriptExplorer
            // 
            AutoScaleDimensions = new SizeF(6.0F, 13.0F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 433);
            Controls.Add(_ToolStripContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScriptExplorer";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Script Explorer";
            TopMost = true;
            _ToolStripContainer.ContentPanel.ResumeLayout(false);
            _ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            _ToolStripContainer.TopToolStripPanel.PerformLayout();
            _ToolStripContainer.ResumeLayout(false);
            _ToolStripContainer.PerformLayout();
            _ToolStrip.ResumeLayout(false);
            _ToolStrip.PerformLayout();
            Load += new EventHandler(ScriptExplorer_Load);
            ResumeLayout(false);
        }

        private TreeView _TreeView;

        internal TreeView TreeView
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TreeView;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TreeView != null)
                {
                    _TreeView.AfterSelect -= TreeView_AfterSelect;
                    _TreeView.KeyUp -= TreeView_KeyUp;
                }

                _TreeView = value;
                if (_TreeView != null)
                {
                    _TreeView.AfterSelect += TreeView_AfterSelect;
                    _TreeView.KeyUp += TreeView_KeyUp;
                }
            }
        }

        private ToolStrip _ToolStrip;

        internal ToolStrip ToolStrip
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStrip;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStrip != null)
                {
                }

                _ToolStrip = value;
                if (_ToolStrip != null)
                {
                }
            }
        }

        private ToolStripButton _ToolStripButtonNew;

        internal ToolStripButton ToolStripButtonNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonNew != null)
                {
                    _ToolStripButtonNew.Click -= ToolStripButtonNew_Click;
                }

                _ToolStripButtonNew = value;
                if (_ToolStripButtonNew != null)
                {
                    _ToolStripButtonNew.Click += ToolStripButtonNew_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonRemove;

        internal ToolStripButton ToolStripButtonRemove
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonRemove;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonRemove != null)
                {
                    _ToolStripButtonRemove.Click -= ToolStripButtonRemove_Click;
                }

                _ToolStripButtonRemove = value;
                if (_ToolStripButtonRemove != null)
                {
                    _ToolStripButtonRemove.Click += ToolStripButtonRemove_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonRun;

        internal ToolStripButton ToolStripButtonRun
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonRun;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonRun != null)
                {
                    _ToolStripButtonRun.Click -= ToolStripButtonRun_Click;
                }

                _ToolStripButtonRun = value;
                if (_ToolStripButtonRun != null)
                {
                    _ToolStripButtonRun.Click += ToolStripButtonRun_Click;
                }
            }
        }

        private ToolStripButton _ToolStripButtonEdit;

        internal ToolStripButton ToolStripButtonEdit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripButtonEdit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripButtonEdit != null)
                {
                    _ToolStripButtonEdit.Click -= ToolStripButtonEdit_Click;
                }

                _ToolStripButtonEdit = value;
                if (_ToolStripButtonEdit != null)
                {
                    _ToolStripButtonEdit.Click += ToolStripButtonEdit_Click;
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

        private ToolStripSeparator _ToolStripSeparator2;

        internal ToolStripSeparator ToolStripSeparator2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripSeparator2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ToolStripSeparator2 != null)
                {
                }

                _ToolStripSeparator2 = value;
                if (_ToolStripSeparator2 != null)
                {
                }
            }
        }
    }
}