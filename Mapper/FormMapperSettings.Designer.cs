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
            CheckedListVariables = new System.Windows.Forms.CheckedListBox();
            _TextboxTypeahead = new System.Windows.Forms.TextBox();
            ButtonSetTypeahead = new System.Windows.Forms.Button();
            lblTypeahead = new System.Windows.Forms.Label();
            lblDragTarget = new System.Windows.Forms.Label();
            _TextboxDragging = new System.Windows.Forms.TextBox();
            _ButtonSetDragging = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            _TextboxAction = new System.Windows.Forms.TextBox();
            _TextboxSuccess = new System.Windows.Forms.TextBox();
            _TextboxRetry = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            _ButtonSetUserWalk = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // CheckedListVariables
            // 
            CheckedListVariables.FormattingEnabled = true;
            CheckedListVariables.Location = new System.Drawing.Point(12, 12);
            CheckedListVariables.Name = "CheckedListVariables";
            CheckedListVariables.Size = new System.Drawing.Size(202, 220);
            CheckedListVariables.TabIndex = 1;
            CheckedListVariables.ItemCheck += CheckedListVariables_ItemCheck;
            // 
            // _TextboxTypeahead
            // 
            _TextboxTypeahead.Location = new System.Drawing.Point(295, 209);
            _TextboxTypeahead.Name = "_TextboxTypeahead";
            _TextboxTypeahead.ReadOnly = true;
            _TextboxTypeahead.Size = new System.Drawing.Size(26, 23);
            _TextboxTypeahead.TabIndex = 3;
            _TextboxTypeahead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonSetTypeahead
            // 
            ButtonSetTypeahead.Location = new System.Drawing.Point(327, 209);
            ButtonSetTypeahead.Name = "ButtonSetTypeahead";
            ButtonSetTypeahead.Size = new System.Drawing.Size(35, 23);
            ButtonSetTypeahead.TabIndex = 4;
            ButtonSetTypeahead.Text = "Set";
            ButtonSetTypeahead.UseVisualStyleBackColor = true;
            ButtonSetTypeahead.Click += ButtonSetTypeahead_Click;
            // 
            // lblTypeahead
            // 
            lblTypeahead.AutoSize = true;
            lblTypeahead.Location = new System.Drawing.Point(220, 213);
            lblTypeahead.Name = "lblTypeahead";
            lblTypeahead.Size = new System.Drawing.Size(63, 15);
            lblTypeahead.TabIndex = 5;
            lblTypeahead.Text = "Typeahead";
            // 
            // lblDragTarget
            // 
            lblDragTarget.AutoSize = true;
            lblDragTarget.Location = new System.Drawing.Point(220, 12);
            lblDragTarget.Name = "lblDragTarget";
            lblDragTarget.Size = new System.Drawing.Size(56, 15);
            lblDragTarget.TabIndex = 6;
            lblDragTarget.Text = "Dragging";
            // 
            // _TextboxDragging
            // 
            _TextboxDragging.Location = new System.Drawing.Point(220, 37);
            _TextboxDragging.Name = "_TextboxDragging";
            _TextboxDragging.ReadOnly = true;
            _TextboxDragging.Size = new System.Drawing.Size(142, 23);
            _TextboxDragging.TabIndex = 7;
            // 
            // _ButtonSetDragging
            // 
            _ButtonSetDragging.Location = new System.Drawing.Point(327, 8);
            _ButtonSetDragging.Name = "_ButtonSetDragging";
            _ButtonSetDragging.Size = new System.Drawing.Size(35, 23);
            _ButtonSetDragging.TabIndex = 8;
            _ButtonSetDragging.Text = "Set";
            _ButtonSetDragging.UseVisualStyleBackColor = true;
            _ButtonSetDragging.Click += _ButtonSetDragging_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(220, 67);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 15);
            label1.TabIndex = 9;
            label1.Text = "User Walk Settings";
            // 
            // _TextboxAction
            // 
            _TextboxAction.Location = new System.Drawing.Point(274, 88);
            _TextboxAction.Name = "_TextboxAction";
            _TextboxAction.ReadOnly = true;
            _TextboxAction.Size = new System.Drawing.Size(88, 23);
            _TextboxAction.TabIndex = 10;
            // 
            // _TextboxSuccess
            // 
            _TextboxSuccess.Location = new System.Drawing.Point(274, 117);
            _TextboxSuccess.Name = "_TextboxSuccess";
            _TextboxSuccess.ReadOnly = true;
            _TextboxSuccess.Size = new System.Drawing.Size(88, 23);
            _TextboxSuccess.TabIndex = 11;
            // 
            // _TextboxRetry
            // 
            _TextboxRetry.Location = new System.Drawing.Point(274, 148);
            _TextboxRetry.Name = "_TextboxRetry";
            _TextboxRetry.ReadOnly = true;
            _TextboxRetry.Size = new System.Drawing.Size(88, 23);
            _TextboxRetry.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(226, 91);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 15);
            label2.TabIndex = 13;
            label2.Text = "Action";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(220, 120);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 15);
            label3.TabIndex = 14;
            label3.Text = "Success";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(234, 151);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 15);
            label4.TabIndex = 15;
            label4.Text = "Retry";
            // 
            // _ButtonSetUserWalk
            // 
            _ButtonSetUserWalk.Location = new System.Drawing.Point(327, 63);
            _ButtonSetUserWalk.Name = "_ButtonSetUserWalk";
            _ButtonSetUserWalk.Size = new System.Drawing.Size(35, 23);
            _ButtonSetUserWalk.TabIndex = 16;
            _ButtonSetUserWalk.Text = "Set";
            _ButtonSetUserWalk.UseVisualStyleBackColor = true;
            _ButtonSetUserWalk.Click += _ButtonSetUserWalk_Click;
            // 
            // FormMapperSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(374, 242);
            Controls.Add(_ButtonSetUserWalk);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(_TextboxRetry);
            Controls.Add(_TextboxSuccess);
            Controls.Add(_TextboxAction);
            Controls.Add(label1);
            Controls.Add(_ButtonSetDragging);
            Controls.Add(_TextboxDragging);
            Controls.Add(lblDragTarget);
            Controls.Add(lblTypeahead);
            Controls.Add(ButtonSetTypeahead);
            Controls.Add(_TextboxTypeahead);
            Controls.Add(CheckedListVariables);
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
        private System.Windows.Forms.CheckedListBox CheckedListVariables;
        private System.Windows.Forms.TextBox _TextboxTypeahead;
        private System.Windows.Forms.Button ButtonSetTypeahead;
        private System.Windows.Forms.Label lblTypeahead;
        private System.Windows.Forms.Label lblDragTarget;
        private System.Windows.Forms.TextBox _TextboxDragging;
        private System.Windows.Forms.Button _ButtonSetDragging;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _TextboxAction;
        private System.Windows.Forms.TextBox _TextboxSuccess;
        private System.Windows.Forms.TextBox _TextboxRetry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _ButtonSetUserWalk;
    }
}