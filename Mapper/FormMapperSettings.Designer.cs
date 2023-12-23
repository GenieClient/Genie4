namespace GenieClient.Forms
{
    partial class FormMapperSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CheckedListClasses = new System.Windows.Forms.CheckedListBox();
            CheckedListVariables = new System.Windows.Forms.CheckedListBox();
            label1 = new System.Windows.Forms.Label();
            TextboxTypeahead = new System.Windows.Forms.TextBox();
            ButtonSetTypeahead = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // CheckedListClasses
            // 
            CheckedListClasses.FormattingEnabled = true;
            CheckedListClasses.Location = new System.Drawing.Point(12, 12);
            CheckedListClasses.Name = "CheckedListClasses";
            CheckedListClasses.Size = new System.Drawing.Size(145, 94);
            CheckedListClasses.TabIndex = 0;
            CheckedListClasses.ItemCheck += CheckedListClasses_ItemCheck;
            // 
            // CheckedListVariables
            // 
            CheckedListVariables.FormattingEnabled = true;
            CheckedListVariables.Location = new System.Drawing.Point(163, 12);
            CheckedListVariables.Name = "CheckedListVariables";
            CheckedListVariables.Size = new System.Drawing.Size(145, 94);
            CheckedListVariables.TabIndex = 1;
            CheckedListVariables.ItemCheck += CheckedListVariables_ItemCheck;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 115);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(130, 15);
            label1.TabIndex = 2;
            label1.Text = "automapper.typeahead";
            // 
            // TextboxTypeahead
            // 
            TextboxTypeahead.Location = new System.Drawing.Point(163, 112);
            TextboxTypeahead.Name = "TextboxTypeahead";
            TextboxTypeahead.Size = new System.Drawing.Size(27, 23);
            TextboxTypeahead.TabIndex = 3;
            // 
            // ButtonSetTypeahead
            // 
            ButtonSetTypeahead.Location = new System.Drawing.Point(196, 112);
            ButtonSetTypeahead.Name = "ButtonSetTypeahead";
            ButtonSetTypeahead.Size = new System.Drawing.Size(112, 23);
            ButtonSetTypeahead.TabIndex = 4;
            ButtonSetTypeahead.Text = "Set Typeahead";
            ButtonSetTypeahead.UseVisualStyleBackColor = true;
            ButtonSetTypeahead.Click += ButtonSetTypeahead_Click;
            // 
            // FormMapperSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(319, 145);
            Controls.Add(ButtonSetTypeahead);
            Controls.Add(TextboxTypeahead);
            Controls.Add(label1);
            Controls.Add(CheckedListVariables);
            Controls.Add(CheckedListClasses);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMapperSettings";
            ShowIcon = false;
            Text = "Automapper Script Settings";
            FormClosing += FormMapperSettings_FormClosing;
            VisibleChanged += FormMapperSettings_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckedListBox CheckedListClasses;
        private System.Windows.Forms.CheckedListBox CheckedListVariables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextboxTypeahead;
        private System.Windows.Forms.Button ButtonSetTypeahead;
    }
}