using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace GenieClient
{
    public class ComponentTextBox : TextBox
    {
        public ComponentTextBox()
        {
            this.KeyDown += TextBoxInput_KeyDown;
            this.KeyPress += TextBoxInput_KeyPress;
        }

        public event SendTextEventHandler SendText;

        public delegate void SendTextEventHandler(string text);

        public event PageUpEventHandler PageUp;

        public delegate void PageUpEventHandler();

        public event PageDownEventHandler PageDown;

        public delegate void PageDownEventHandler();

        private Genie.Collections.ArrayList HistoryArray = new Genie.Collections.ArrayList();
        private int HistoryPos = -1;
        private int HistorySize = 20;
        private int HistoryMinLenght = 3;
        private bool m_KeepInput = false;

        public bool KeepInput
        {
            get
            {
                return m_KeepInput;
            }

            set
            {
                m_KeepInput = value;
            }
        }

        public void SetHistorySize(int size)
        {
            HistorySize = size;
        }

        public void SetHistoryMinLength(int size)
        {
            HistoryMinLenght = size;
        }

        private void InsertHistory(string text)
        {
            if (text.Length < HistoryMinLenght)
            {
                return; // Don't save short commands
            }

            if (HistoryArray.Count > 0)
            {
                if (string.Compare(text, Conversions.ToString(HistoryArray[0])) == 0)
                {
                    return; // Same as last command
                }
            }

            if (HistoryArray.Count >= HistorySize)
            {
                HistoryArray.RemoveAt(HistoryArray.Count - 1);
            }

            HistoryArray.Insert(0, text);
        }

        private void KeyUpHistory()
        {
            if (HistoryPos == -1) // Beginning
            {
                if (HistoryArray.Count == 0)
                {
                    return;
                }

                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(HistoryArray[0], Text, false)))
                {
                    Tag = Text;
                    HistoryPos = 0;
                    Text = Conversions.ToString(HistoryArray[0]);
                }
                else if (HistoryArray.Count >= 0) // Skip (0) since text is same
                {
                    Tag = Text;
                    HistoryPos = 1;
                    Text = Conversions.ToString(HistoryArray[1]);
                }
            }
            else if (HistoryPos < HistoryArray.Count - 1) // Within range
            {
                HistoryPos = HistoryPos + 1;
                Text = Conversions.ToString(HistoryArray[HistoryPos]);
            }

            SelectionLength = 0;
            SelectionStart = Text.Length;
        }

        private void KeyDownHistory()
        {
            if (HistoryArray.Count == 0)
            {
                return;
            }

            if (HistoryPos == 0)
            {
                if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(HistoryArray[0], Tag, false)))
                {
                    Text = Conversions.ToString(Tag);
                }

                HistoryPos = -1;
            }
            else if (HistoryPos > 0)
            {
                HistoryPos = HistoryPos - 1;
                Text = Conversions.ToString(HistoryArray[HistoryPos]);
            }
            else // On Request from Fatal (Down Clears)
            {
                Clear();
            }

            SelectionLength = 0;
            SelectionStart = Text.Length;
        }

        private void KeyControlEnter()
        {
            if (HistoryArray.Count > 0)
            {
                Text = Conversions.ToString(HistoryArray[0]);
            }

            SelectionLength = 0;
            SelectionStart = Text.Length;
        }

        private bool KeyHandled = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText() == true)
                {
                    if (Clipboard.GetText().Length > 100)
                    {
                        if (Interaction.MsgBox("Clipboard size is rather large (" + Clipboard.GetText().Length + ")" + System.Environment.NewLine + "Are you sure you want to paste it to input box?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
                        {
                            Paste(Clipboard.GetText().Replace(Constants.vbCr, " ").Replace(Constants.vbLf, "").TrimEnd());
                        }
                    }
                    else
                    {
                        Paste(Clipboard.GetText().Replace(Constants.vbCr, " ").Replace(Constants.vbLf, "").TrimEnd());
                    }
                }

                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        // Private Sub ComponentTextBox_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        // MsgBox(Me.FontHeight)
        // Me.Height = Me.FontHeight + 4
        // End Sub

        public new int FontHeight
        {
            get
            {
                return base.FontHeight;
            }
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            var switchExpr = e.KeyCode;
            switch (switchExpr)
            {
                case Keys.Return:
                    {
                        if (e.Modifiers == Keys.Control)
                        {
                            KeyControlEnter();
                        }

                        SendText?.Invoke(Text);
                        InsertHistory(Text);
                        HistoryPos = -1;
                        if (m_KeepInput == false)
                        {
                            Clear();
                        }
                        else
                        {
                            SelectAll();
                        }

                        KeyHandled = true;
                        break;
                    }

                case Keys.Up:
                    {
                        KeyUpHistory();
                        e.Handled = true;
                        break;
                    }

                case Keys.Down:
                    {
                        KeyDownHistory();
                        e.Handled = true;
                        break;
                    }

                case Keys.PageUp:
                    {
                        PageUp?.Invoke();
                        e.Handled = true;
                        break;
                    }

                case Keys.PageDown:
                    {
                        PageDown?.Invoke();
                        e.Handled = true;
                        break;
                    }
            }
        }

        private void TextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyHandled == true)
            {
                e.Handled = true;
                KeyHandled = false;
            }
        }
    }
}