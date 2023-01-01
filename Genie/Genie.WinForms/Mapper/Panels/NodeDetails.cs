using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using GenieClient.Mapper;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class NodeDetails
    {
        public NodeDetails()
        {
            m_ArcDetails = new ArcDetails();
            InitializeComponent();
        }

        public event NewNodeEventHandler NewNode;

        public delegate void NewNodeEventHandler();

        public event CopyNodeEventHandler CopyNode;

        public delegate void CopyNodeEventHandler();

        public event RemoveNodeEventHandler RemoveNode;

        public delegate void RemoveNodeEventHandler();

        public event AddNodeEventHandler AddNode;

        public delegate void AddNodeEventHandler(Node oNode);

        public event UpdateMapEventHandler UpdateMap;

        public delegate void UpdateMapEventHandler();

        public event ArcChangedEventHandler ArcChanged;

        public delegate void ArcChangedEventHandler();

        public event NewLabelEventHandler NewLabel;

        public delegate void NewLabelEventHandler();

        private int m_X = 0;
        private int m_Y = 0;
        private int m_Z = 0;
        private Node m_Node;

        public Node Node
        {
            get
            {
                return m_Node;
            }

            set
            {
                m_Node = value;
                m_ArcDetails.Node = m_Node;
                if (Information.IsNothing(m_Node)) // Update validation on clear
                {
                    ValidateBoxes();
                }
            }
        }

        private bool m_TextBoxTextBoxPositionValid = true;

        private void TextBoxPosition_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateBoxes();
        }

        public void ValidateBoxes()
        {
            string sText = TextBoxPosition.Text.Replace(Conversions.ToString(' '), "");
            if (sText.Length == 0)
            {
                m_TextBoxTextBoxPositionValid = false;
                return;
            }

            m_TextBoxTextBoxPositionValid = false;
            if (sText.Contains(","))
            {
                if (int.TryParse(sText.Substring(0, sText.IndexOf(",")), out m_X))
                {
                    sText = sText.Substring(sText.IndexOf(",") + 1);
                    if (sText.Contains(",")) // Z
                    {
                        if (int.TryParse(sText.Substring(0, sText.IndexOf(",")), out m_Y))
                        {
                            if (int.TryParse(sText.Substring(sText.IndexOf(",") + 1), out m_Z))
                            {
                                m_TextBoxTextBoxPositionValid = true;
                            }
                        }
                    }
                    else if (int.TryParse(sText, out m_Y)) // No Z is also OK. Assume 0
                    {
                        m_Z = 0;
                        m_TextBoxTextBoxPositionValid = true;
                    }
                }
            }

            if (m_TextBoxTextBoxPositionValid == false)
            {
                TextBoxPosition.BackColor = Color.Red;
            }
            else
            {
                TextBoxPosition.BackColor = SystemColors.Window;
            }
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateNode();
        }

        private void UpdateNode()
        {
            ValidateBoxes();
            if (m_TextBoxTextBoxPositionValid == false)
            {
                Interaction.Beep();
                TextBoxPosition.Focus();
            }
            else if (!Information.IsNothing(m_Node))
            {
                if (Information.IsNothing(m_Node.Position))
                {
                    m_Node.Position = new Point3D();
                }

                m_Node.Position.X = m_X;
                m_Node.Position.Y = m_Y;
                m_Node.Position.Z = m_Z;
                m_Node.Name = TextBoxRoomName.Text;
                var oDescs = new StringList();
                foreach (string s in TextBoxDescription.Text.Split('|'))
                    oDescs.Add(s);
                m_Node.Descriptions = oDescs;
                m_Node.Note = TextBoxNote.Text;
                m_Node.IsLabelFile = m_Node.Note.ToLower().Contains(".xml");
                m_Node.Color = ColorPicker1.Color;
                UpdateMap?.Invoke();
            }
            else // New Node
            {
                var oNode = new Node();
                oNode.Position = new Point3D();
                oNode.Position.X = m_X;
                oNode.Position.Y = m_Y;
                oNode.Position.Z = m_Z;
                oNode.Name = TextBoxRoomName.Text;
                var oDescs = new StringList();
                foreach (string s in TextBoxDescription.Text.Split('|'))
                    oDescs.Add(s);
                oNode.Descriptions = oDescs;
                oNode.Note = TextBoxNote.Text;
                oNode.IsLabelFile = oNode.Note.ToLower().Contains(".xml");
                oNode.Color = ColorPicker1.Color;
                AddNode?.Invoke(oNode);
            }
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            if (ToolStripButtonArcs.Checked == true)
            {
                m_ArcDetails.RemoveItem();
            }
            else
            {
                RemoveNode?.Invoke();
            }
        }

        private void ToolStripButtonCopy_Click(object sender, EventArgs e)
        {
            if (ToolStripButtonArcs.Checked == true)
            {
            }
            // m_ArcDetails.CopyItem()
            else
            {
                CopyNode?.Invoke();
            }
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            if (ToolStripButtonArcs.Checked == true)
            {
                m_ArcDetails.NewItem();
            }
            else
            {
                NewNode?.Invoke();
            }
        }

        private void ToolStripButtonArcs_Click(object sender, EventArgs e)
        {
            ToolStripButtonArcs.Checked = !ToolStripButtonArcs.Checked;
            PanelProperties.Visible = !ToolStripButtonArcs.Checked;
            m_ArcDetails.Visible = ToolStripButtonArcs.Checked;
        }

        public ArcDetails ArcDetails
        {
            get
            {
                return m_ArcDetails;
            }
        }

        private ArcDetails _m_ArcDetails;

        private ArcDetails m_ArcDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _m_ArcDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_m_ArcDetails != null)
                {
                    _m_ArcDetails.ArcChanged -= ArcDetails_ArcChanged;
                }

                _m_ArcDetails = value;
                if (_m_ArcDetails != null)
                {
                    _m_ArcDetails.ArcChanged += ArcDetails_ArcChanged;
                }
            }
        }

        private void NodeDetails_Load(object sender, EventArgs e)
        {
            m_ArcDetails.Dock = DockStyle.Fill;
            m_ArcDetails.Visible = false;
            Controls.Add(m_ArcDetails);
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            UpdateNode();
        }

        private void ArcDetails_ArcChanged()
        {
            ArcChanged?.Invoke();
        }

        private void ToolStripButtonAddLabel_Click(object sender, EventArgs e)
        {
            NewLabel?.Invoke();
        }
    }
}