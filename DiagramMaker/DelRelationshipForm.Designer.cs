namespace DiagramMaker
{
    partial class DelRelationshipForm
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
            relationshipComboBox = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // delButton
            // 
            delButton.Location = new Point(12, 57);
            delButton.Name = "delButton";
            delButton.Size = new Size(353, 61);
            delButton.TabIndex = 5;
            delButton.Text = "刪除";
            delButton.UseVisualStyleBackColor = true;
            delButton.Click += delButton_Click;
            // 
            // relationshipComboBox
            // 
            relationshipComboBox.FormattingEnabled = true;
            relationshipComboBox.Location = new Point(79, 18);
            relationshipComboBox.Name = "relationshipComboBox";
            relationshipComboBox.Size = new Size(286, 23);
            relationshipComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 3;
            label1.Text = "選擇Class:";
            // 
            // DelRelationshipForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 144);
            Controls.Add(delButton);
            Controls.Add(relationshipComboBox);
            Controls.Add(label1);
            Name = "DelRelationshipForm";
            Text = "DelRelationshipForm";
            Load += DelRelationshipForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button delButton;
        private ComboBox relationshipComboBox;
        private Label label1;
    }
}