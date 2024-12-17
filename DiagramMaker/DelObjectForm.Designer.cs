namespace DiagramMaker
{
    partial class DelObjectForm
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
            objectComboBox = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // delButton
            // 
            delButton.Location = new Point(12, 53);
            delButton.Name = "delButton";
            delButton.Size = new Size(233, 61);
            delButton.TabIndex = 5;
            delButton.Text = "刪除";
            delButton.UseVisualStyleBackColor = true;
            delButton.Click += delButton_Click;
            // 
            // objectComboBox
            // 
            objectComboBox.FormattingEnabled = true;
            objectComboBox.Location = new Point(87, 14);
            objectComboBox.Name = "objectComboBox";
            objectComboBox.Size = new Size(158, 23);
            objectComboBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "選擇Object:";
            // 
            // DelObjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 130);
            Controls.Add(delButton);
            Controls.Add(objectComboBox);
            Controls.Add(label1);
            Name = "DelObjectForm";
            Text = "DelObjectForm";
            Load += DelObjectForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button delButton;
        private ComboBox objectComboBox;
        private Label label1;
    }
}