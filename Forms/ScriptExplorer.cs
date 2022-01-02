using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class ScriptExplorer
    {
        public ScriptExplorer()
        {
            InitializeComponent();
        }

        public event EventRunScriptEventHandler EventRunScript;

        public delegate void EventRunScriptEventHandler(string sText);

        private void ScriptExplorer_Load(object sender, EventArgs e)
        {
            // Set up the UI
            LoadTree();
        }

        private Genie.Globals m_oGlobals;

        public Genie.Globals Globals
        {
            get
            {
                return m_oGlobals;
            }

            set
            {
                m_oGlobals = value;
            }
        }

        private void LoadTree()
        {
            string sLocation = m_oGlobals.Config.ScriptDir;
            if (Information.IsNothing(m_oGlobals))
            {
                return;
            }

            if (!sLocation.EndsWith(@"\"))
            {
                sLocation += @"\";
            }

            var diDirectory = new DirectoryInfo(sLocation);
            TreeView.Nodes.Clear();
            foreach (DirectoryInfo di in diDirectory.GetDirectories())
            {
                var tnDir = new TreeNode(di.Name, 0, 1);
                tnDir.Tag = "Directory";
                TreeView.Nodes.Add(tnDir);
                AddDirectories(tnDir, sLocation);
            }

            foreach (FileInfo dif in diDirectory.GetFiles())
            {
                // Create a child node for every item, passing in the file
                // name and the images its node will use
                var tnFile = new TreeNode(dif.Name, 2, 2);
                tnFile.Tag = "File";
                // Add the new child node to the parent node
                TreeView.Nodes.Add(tnFile);
            }
        }

        private void AddDirectories(TreeNode tn, string sScriptDir)
        {
            tn.Nodes.Clear();
            string strPath = sScriptDir + tn.FullPath;
            var diDirectory = new DirectoryInfo(strPath);
            DirectoryInfo[] adiDirectories;
            try
            {
                // Get an array of all sub-directories as DirectoryInfo objects
                adiDirectories = diDirectory.GetDirectories();
            }
#pragma warning disable CS0168
            catch (Exception exp)
#pragma warning restore CS0168
            {
                return;
            }

            foreach (DirectoryInfo di in adiDirectories)
            {
                // Create a child node for every sub-directory, passing in the directory
                // name and the images its node will use
                var tnDir = new TreeNode(di.Name, 0, 1);
                tnDir.Tag = "Directory";
                // Add the new child node to the parent node
                tn.Nodes.Add(tnDir);
                AddDirectories(tnDir, sScriptDir);
            }

            AddFiles(tn, sScriptDir);
        }

        private void AddFiles(TreeNode tn, string sScriptDir)
        {
            string strPath = sScriptDir + tn.FullPath;
            var diDirectory = new DirectoryInfo(strPath);
            FileInfo[] adiFiles;
            try
            {
                // Get an array of all files as FileInfo objects
                adiFiles = diDirectory.GetFiles();
            }
#pragma warning disable CS0168
            catch (Exception exp)
#pragma warning restore CS0168
            {
                return;
            }

            foreach (FileInfo di in adiFiles)
            {
                // Create a child node for every item, passing in the file
                // name and the images its node will use
                var tnFile = new TreeNode(di.Name, 2, 2);
                tnFile.Tag = "File";
                // Add the new child node to the parent node
                tn.Nodes.Add(tnFile);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close this form
            Close();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!Information.IsNothing(TreeView.SelectedNode))
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TreeView.SelectedNode.Tag, "File", false)))
                {
                    ToolStripButtonEdit.Enabled = true;
                    ToolStripButtonRun.Enabled = true;
                    ToolStripButtonRemove.Enabled = true;
                }
                else
                {
                    ToolStripButtonEdit.Enabled = false;
                    ToolStripButtonRun.Enabled = false;
                    ToolStripButtonRemove.Enabled = false;
                }
            }
        }

        private void ToolStripButtonRun_Click(object sender, EventArgs e)
        {
            if (Information.IsNothing(TreeView.SelectedNode))
                return;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TreeView.SelectedNode.Tag, "File", false)))
            {
                EventRunScript?.Invoke("." + TreeView.SelectedNode.FullPath);
            }
        }

        private void ToolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TreeView.SelectedNode.Tag, "File", false)))
            {
                string sLocation = m_oGlobals.Config.ScriptDir;
                if (!sLocation.EndsWith(@"\"))
                {
                    sLocation += @"\";
                }

                Interaction.Shell("\"" + m_oGlobals.Config.sEditor + "\" \"" + sLocation + TreeView.SelectedNode.FullPath + "\"", AppWinStyle.NormalFocus, false);
            }
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TreeView.SelectedNode.Tag, "File", false)))
            {
                if (Interaction.MsgBox("Are you sure you want to delete " + TreeView.SelectedNode.FullPath + "?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                {
                    string sLocation = m_oGlobals.Config.ScriptDir;
                    if (!sLocation.EndsWith(@"\"))
                    {
                        sLocation += @"\";
                    }

                    Utility.DeleteFile(sLocation + TreeView.SelectedNode.FullPath);
                    TreeView.SelectedNode.Remove();
                }
            }
        }

        private void ToolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            string sLocation = m_oGlobals.Config.ScriptDir;
            if (!sLocation.EndsWith(@"\"))
            {
                sLocation += @"\";
            }

            string sPath = string.Empty;
            TreeNode oParent = null;
            if (!Information.IsNothing(TreeView.SelectedNode))
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TreeView.SelectedNode.Tag, "File", false)))
                {
                    if (!Information.IsNothing(TreeView.SelectedNode.Parent))
                    {
                        sPath = TreeView.SelectedNode.Parent.FullPath;
                        oParent = TreeView.SelectedNode.Parent;
                    }
                }
                else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TreeView.SelectedNode.Tag, "Directory", false)))
                {
                    sPath = TreeView.SelectedNode.FullPath;
                    oParent = TreeView.SelectedNode;
                }
            }

            sLocation += sPath;
            if (!sLocation.EndsWith(@"\"))
            {
                sLocation += @"\";
            }

            if (My.MyProject.Forms.DialogScriptName.ShowDialog(Parent) == DialogResult.OK)
            {
                var tnFile = new TreeNode(My.MyProject.Forms.DialogScriptName.ScriptName, 2, 2);
                tnFile.Tag = "File";
                // Add the new child node to the parent node
                if (!Information.IsNothing(oParent))
                {
                    oParent.Nodes.Add(tnFile);
                }
                else
                {
                    TreeView.Nodes.Add(tnFile);
                }

                Interaction.Shell("\"" + m_oGlobals.Config.sEditor + "\" \"" + sLocation + My.MyProject.Forms.DialogScriptName.ScriptName + "\"", AppWinStyle.NormalFocus, false);
            }

            My.MyProject.Forms.DialogScriptName.ScriptName = string.Empty;
        }

        private void TreeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (Information.IsNothing(TreeView.SelectedNode))
                    return;
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(TreeView.SelectedNode.Tag, "File", false)))
                {
                    EventRunScript?.Invoke("." + TreeView.SelectedNode.FullPath);
                }
            }
        }
    }
}