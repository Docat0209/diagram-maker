namespace DiagramMaker
{
    partial class DelLinkForm
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
            delButton = new Button();
            linkComboBox = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // delButton
            // 
            delButton.Location = new Point(12, 51);
            delButton.Name = "delButton";
            delButton.Size = new Size(353, 61);
            delButton.TabIndex = 8;
            delButton.Text = "刪除";
            delButton.UseVisualStyleBackColor = true;
            delButton.Click += delButton_Click;
            // 
            // linkComboBox
            // 
            linkComboBox.FormattingEnabled = true;
            linkComboBox.Location = new Point(79, 12);
            linkComboBox.Name = "linkComboBox";
            linkComboBox.Size = new Size(286, 23);
            linkComboBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 6;
            label1.Text = "選擇Link:";
            // 
            // DelLinkForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 135);
            Controls.Add(delButton);
            Controls.Add(linkComboBox);
            Controls.Add(label1);
            Name = "DelLinkForm";
            Text = "DelLinkForm";
            Load += DelLinkForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button delButton;
        private ComboBox linkComboBox;
        private Label label1;
    }
}