namespace DiagramMaker
{
    partial class AddRelationshipForm
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
            classComboBox1 = new ComboBox();
            relationshipComboBox = new ComboBox();
            classComboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // classComboBox1
            // 
            classComboBox1.FormattingEnabled = true;
            classComboBox1.Location = new Point(17, 54);
            classComboBox1.Name = "classComboBox1";
            classComboBox1.Size = new Size(121, 23);
            classComboBox1.TabIndex = 0;
            // 
            // relationshipComboBox
            // 
            relationshipComboBox.FormattingEnabled = true;
            relationshipComboBox.Items.AddRange(new object[] { "Association", "Dependencies", "Composition", "Aggregation", "Inheritance", "Implementation" });
            relationshipComboBox.Location = new Point(144, 54);
            relationshipComboBox.Name = "relationshipComboBox";
            relationshipComboBox.Size = new Size(121, 23);
            relationshipComboBox.TabIndex = 1;
            // 
            // classComboBox2
            // 
            classComboBox2.FormattingEnabled = true;
            classComboBox2.Location = new Point(271, 54);
            classComboBox2.Name = "classComboBox2";
            classComboBox2.Size = new Size(121, 23);
            classComboBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 30);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "ClassA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 30);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 4;
            label2.Text = "ClassB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 30);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 5;
            label3.Text = "Relationship";
            // 
            // button1
            // 
            button1.Location = new Point(17, 92);
            button1.Name = "button1";
            button1.Size = new Size(375, 50);
            button1.TabIndex = 6;
            button1.Text = "新增";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddRelationshipForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 168);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(classComboBox2);
            Controls.Add(relationshipComboBox);
            Controls.Add(classComboBox1);
            Name = "AddRelationshipForm";
            Text = "AddRelationshipForm";
            Load += AddRelationshipForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox classComboBox1;
        private ComboBox relationshipComboBox;
        private ComboBox classComboBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
    }
}