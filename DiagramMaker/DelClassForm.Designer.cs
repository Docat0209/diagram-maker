namespace DiagramMaker
{
    partial class DelClassForm
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
            label1 = new Label();
            classComboBox = new ComboBox();
            delButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 33);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "選擇Class:";
            // 
            // classComboBox
            // 
            classComboBox.FormattingEnabled = true;
            classComboBox.Location = new Point(87, 30);
            classComboBox.Name = "classComboBox";
            classComboBox.Size = new Size(158, 23);
            classComboBox.TabIndex = 1;
            // 
            // delButton
            // 
            delButton.Location = new Point(20, 69);
            delButton.Name = "delButton";
            delButton.Size = new Size(225, 61);
            delButton.TabIndex = 2;
            delButton.Text = "刪除";
            delButton.UseVisualStyleBackColor = true;
            delButton.Click += delButton_Click;
            // 
            // DelClassForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 155);
            Controls.Add(delButton);
            Controls.Add(classComboBox);
            Controls.Add(label1);
            Name = "DelClassForm";
            Text = "DelClassForm";
            Load += DelClassForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox classComboBox;
        private Button delButton;
    }
}