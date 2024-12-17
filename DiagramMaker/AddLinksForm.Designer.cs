namespace DiagramMaker
{
    partial class AddLinksForm
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
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            objectComboBox2 = new ComboBox();
            objectComboBox1 = new ComboBox();
            linkTextBox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 84);
            button1.Name = "button1";
            button1.Size = new Size(375, 50);
            button1.TabIndex = 13;
            button1.Text = "新增";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 22);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 12;
            label3.Text = "Link text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 22);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 11;
            label2.Text = "ObjectB";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 10;
            label1.Text = "ObjectA";
            // 
            // objectComboBox2
            // 
            this.objectComboBox2.FormattingEnabled = true;
            this.objectComboBox2.Location = new Point(266, 46);
            this.objectComboBox2.Name = "objectComboBox2";
            this.objectComboBox2.Size = new Size(121, 23);
            this.objectComboBox2.TabIndex = 9;
            // 
            // objectComboBox1
            // 
            objectComboBox1.FormattingEnabled = true;
            objectComboBox1.Location = new Point(12, 46);
            objectComboBox1.Name = "objectComboBox1";
            objectComboBox1.Size = new Size(121, 23);
            objectComboBox1.TabIndex = 7;
            // 
            // linkTextBox
            // 
            linkTextBox.Location = new Point(139, 46);
            linkTextBox.Name = "linkTextBox";
            linkTextBox.Size = new Size(121, 23);
            linkTextBox.TabIndex = 14;
            // 
            // AddLinksForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 158);
            Controls.Add(linkTextBox);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(objectComboBox2);
            Controls.Add(objectComboBox1);
            Name = "AddLinksForm";
            Text = "AddLinksForm";
            Load += AddLinksForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox objectComboBox2;
        private ComboBox relationshipComboBox;
        private ComboBox objectComboBox1;
        private TextBox linkTextBox;
    }
}