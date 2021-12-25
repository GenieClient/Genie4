using System;
using System.Drawing;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public partial class LabelDetails
    {
        public LabelDetails()
        {
            InitializeComponent();
        }

        public event NewLabelEventHandler NewLabel;

        public delegate void NewLabelEventHandler();

        public event CopyLabelEventHandler CopyLabel;

        public delegate void CopyLabelEventHandler();

        public event RemoveLabelEventHandler RemoveLabel;

        public delegate void RemoveLabelEventHandler();

        public event AddLabelEventHandler AddLabel;

        public delegate void AddLabelEventHandler(Mapper.Label oLabel);

        public event UpdateMapEventHandler UpdateMap;

        public delegate void UpdateMapEventHandler();

        private int m_X = 0;
        private int m_Y = 0;
        private int m_Z = 0;
        private Mapper.Label m_Label;

        public Mapper.Label Label
        {
            get
            {
                return m_Label;
            }

            set
            {
                m_Label = value;
                if (Information.IsNothing(m_Label)) // Update validation on clear
                {
                    ValidateBoxes();
                    ButtonApply.Text = "Create";
                }
                else
                {
                    TextBoxPosition.Text = m_Label.Position.X.ToString() + ", " + m_Label.Position.Y.ToString() + ", " + m_Label.Position.Z.ToString();
                    TextBoxText.Text = m_Label.Text;
                    ButtonApply.Text = "Apply";
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
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            ValidateBoxes();
            if (m_TextBoxTextBoxPositionValid == false)
            {
                Interaction.Beep();
                TextBoxPosition.Focus();
            }
            else if (!Information.IsNothing(m_Label))
            {
                if (Information.IsNothing(m_Label.Position))
                {
                    m_Label.Position = new Mapper.Point3D();
                }

                m_Label.Position.X = m_X;
                m_Label.Position.Y = m_Y;
                m_Label.Position.Z = m_Z;
                m_Label.Text = TextBoxText.Text;
                UpdateMap?.Invoke();
            }
            else // New Node
            {
                var oLabel = new Mapper.Label();
                oLabel.Position = new Mapper.Point3D();
                oLabel.Position.X = m_X;
                oLabel.Position.Y = m_Y;
                oLabel.Position.Z = m_Z;
                m_Label.Text = TextBoxText.Text;
                AddLabel?.Invoke(oLabel);
            }
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            RemoveLabel?.Invoke();
        }

        private void ToolStripButtonCopy_Click(object sender, EventArgs e)
        {
            CopyLabel?.Invoke();
        }

        private void ToolStripButtonNew_Click(object sender, EventArgs e)
        {
            NewLabel?.Invoke();
        }

        private void ButtonApply_Click(object sender, EventArgs e)
        {
            UpdateLabel();
        }
    }
}