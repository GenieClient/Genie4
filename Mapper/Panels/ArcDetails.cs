using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class ArcDetails
    {
        public ArcDetails()
        {
            InitializeComponent();
        }

        public event ArcChangedEventHandler ArcChanged;

        public delegate void ArcChangedEventHandler();

        private Mapper.Node m_Node;

        public Mapper.Node Node
        {
            get
            {
                return m_Node;
            }

            set
            {
                m_Node = value;
                ListWasUnselected();
                ResetList();
                UpdateArcs();
            }
        }

        private void ArcDetails_Load(object sender, EventArgs e)
        {
            var enumType = typeof(Mapper.Direction);
            var names = Enum.GetNames(enumType);
            int i;
            var loopTo = names.Length - 1;
            for (i = 0; i <= loopTo; i++)
                ComboBoxDirection.Items.Add(names[i]);
            ComboBoxDirection.SelectedItem = "None";
        }

        private void ResetList()
        {
            ListViewBase.Clear();
            ListViewBase.Columns.Add("Direction", 150, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("DestinationID", 150, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Name", 190, HorizontalAlignment.Left);
            ListViewBase.Columns.Add("Hidden", 10, HorizontalAlignment.Left);
        }

        private void UpdateArcs()
        {
            if (!Information.IsNothing(m_Node))
            {
                foreach (Mapper.Arc a in m_Node.Arcs)
                {
                    var li = ListViewBase.Items.Add(a.Direction.ToString());
                    li.Tag = a.Move;
                    li.SubItems.Add(a.DestinationID.ToString());
                    li.SubItems.Add(a.Move);
                    li.SubItems.Add(a.HideArc.ToString());
                }
            }
        }

        private bool m_bSelectedChanged = false;

        private void ListViewBase_KeyUp(object sender, KeyEventArgs e)
        {
            if (m_bSelectedChanged == false)
            {
                return;
            }

            UpdateGroupBox();
            m_bSelectedChanged = false;
        }

        private void ListViewBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_bSelectedChanged == false)
            {
                return;
            }

            UpdateGroupBox();
            m_bSelectedChanged = false;
        }

        private void ListViewBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_bSelectedChanged = true;
        }

        private void UpdateGroupBox()
        {
            if (ListViewBase.SelectedItems.Count == 1)
            {
                ComboBoxDirection.SelectedItem = ListViewBase.SelectedItems[0].Text;
                TextBoxToNodeID.Text = ListViewBase.SelectedItems[0].SubItems[1].Text;
                TextBoxName.Text = ListViewBase.SelectedItems[0].SubItems[2].Text;
                string sHidden = ListViewBase.SelectedItems[0].SubItems[3].Text.ToLower();
                if ((sHidden ?? "") == "true" | (sHidden ?? "") == "1")
                {
                    CheckBoxHideArc.Checked = true;
                }
                else
                {
                    CheckBoxHideArc.Checked = false;
                }
                // ButtonApply.Enabled = True
                ButtonApply.Text = "Apply";
            }
            else
            {
                ListWasUnselected();
            }
        }

        private void ListWasUnselected()
        {
            ComboBoxDirection.SelectedItem = "None";
            TextBoxToNodeID.Text = "0";
            TextBoxName.Text = "";
            CheckBoxHideArc.Checked = false;
            // ButtonApply.Enabled = False
            ButtonApply.Text = "Create";
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            Mapper.Direction dirvalue = (Mapper.Direction)Enum.Parse(typeof(Mapper.Direction), (string)ComboBoxDirection.SelectedItem);
            if (ListViewBase.SelectedItems.Count == 1)
            {
                if (!Information.IsNothing(m_Node))
                {
                    foreach (Mapper.Arc a in m_Node.Arcs)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(a.Move, ListViewBase.SelectedItems[0].Tag, false)))
                        {
                            a.Direction = dirvalue;
                            if (TextBoxName.Text.Length > 0)
                            {
                                a.Move = TextBoxName.Text;
                            }
                            else
                            {
                                a.Move = string.Empty;
                            }

                            int iNodeID = 0;
                            if (int.TryParse(TextBoxToNodeID.Text, out iNodeID))
                            {
                                Mapper.Node argdest = null;
                                a.SetDestination(argdest);
                                a.DestinationID = iNodeID;
                            }

                            a.HideArc = CheckBoxHideArc.Checked;
                            ListViewBase.SelectedItems[0].Text = dirvalue.ToString();
                            ListViewBase.SelectedItems[0].Tag = a.Move;
                            ListViewBase.SelectedItems[0].SubItems[1].Text = a.DestinationID.ToString();
                            ListViewBase.SelectedItems[0].SubItems[2].Text = a.Move;
                            ListViewBase.SelectedItems[0].SubItems[3].Text = a.HideArc.ToString();
                            break;
                        }
                    }
                }
            }
            else if (ListViewBase.SelectedItems.Count == 0) // New
            {
                var li = ListViewBase.Items.Add(dirvalue.ToString());
                var a = new Mapper.Arc();
                a.Direction = dirvalue;
                if (TextBoxName.Text.Length > 0)
                {
                    a.Move = TextBoxName.Text;
                }

                int iNodeID = 0;
                if (int.TryParse(TextBoxToNodeID.Text, out iNodeID))
                {
                    Mapper.Node argdest1 = null;
                    a.SetDestination(argdest1);
                    a.DestinationID = iNodeID;
                }

                a.HideArc = CheckBoxHideArc.Checked;
                m_Node.AddArc(a);
                li.Tag = a.Move;
                li.SubItems.Add(a.DestinationID.ToString());
                li.SubItems.Add(a.Move);
                li.SubItems.Add(a.HideArc.ToString());
                li.Selected = true;
            }

            ArcChanged?.Invoke();
        }

        public void RemoveItem()
        {
            if (ListViewBase.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Do NOT remove a cardinal direction. These exits need to match the room in the game. Instead set destination to 0 to clear the link." + System.Environment.NewLine + "If you still want to delete this arc please click YES.", "AutoMapper", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = 0;
                    int iMatch = 0;
                    foreach (Mapper.Arc a in m_Node.Arcs)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(a.Move, ListViewBase.SelectedItems[0].Tag, false)))
                        {
                            iMatch = i;
                            break;
                        }

                        i += 1;
                    }

                    if (iMatch >= 0)
                    {
                        m_Node.Arcs.RemoveAt(iMatch);
                    }

                    ListViewBase.Items.Remove(ListViewBase.SelectedItems[0]);
                    ListWasUnselected();
                }
            }
        }

        public void NewItem()
        {
            ListViewBase.SelectedItems.Clear();
        }
    }
}