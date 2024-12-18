namespace DiagramMaker
{
    partial class SelectDiagramTypeUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            openOldClassButton = new Button();
            panel3 = new Panel();
            classComboBox = new ComboBox();
            panel2 = new Panel();
            label1 = new Label();
            panel1 = new Panel();
            createNewClassButton = new Button();
            panel7 = new Panel();
            classNameTextBox = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            openOldObjectButton = new Button();
            panel4 = new Panel();
            objectComboBox = new ComboBox();
            panel5 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            createNewObjectButton = new Button();
            panel8 = new Panel();
            objectNameTextBox = new TextBox();
            label4 = new Label();
            panel11 = new Panel();
            panel9 = new Panel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(openOldClassButton);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(classComboBox);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(createNewClassButton);
            groupBox1.Controls.Add(panel7);
            groupBox1.Controls.Add(classNameTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(13, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(242, 253);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Class Diagram";
            // 
            // openOldClassButton
            // 
            openOldClassButton.Dock = DockStyle.Top;
            openOldClassButton.Location = new Point(3, 198);
            openOldClassButton.Name = "openOldClassButton";
            openOldClassButton.Size = new Size(236, 42);
            openOldClassButton.TabIndex = 4;
            openOldClassButton.Text = "開啟舊檔";
            openOldClassButton.UseVisualStyleBackColor = true;
            openOldClassButton.Click += openOldClassButton_Click;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 188);
            panel3.Name = "panel3";
            panel3.Size = new Size(236, 10);
            panel3.TabIndex = 6;
            // 
            // classComboBox
            // 
            classComboBox.Dock = DockStyle.Top;
            classComboBox.FormattingEnabled = true;
            classComboBox.Location = new Point(3, 165);
            classComboBox.Name = "classComboBox";
            classComboBox.Size = new Size(236, 23);
            classComboBox.TabIndex = 1;
            classComboBox.SelectedIndexChanged += classComboBox_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 155);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 10);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 140);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 3;
            label1.Text = "舊檔:";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 34);
            panel1.TabIndex = 2;
            // 
            // createNewClassButton
            // 
            createNewClassButton.Dock = DockStyle.Top;
            createNewClassButton.Location = new Point(3, 67);
            createNewClassButton.Name = "createNewClassButton";
            createNewClassButton.Size = new Size(236, 39);
            createNewClassButton.TabIndex = 0;
            createNewClassButton.Text = "開啟新檔";
            createNewClassButton.UseVisualStyleBackColor = true;
            createNewClassButton.Click += createNewClassButton_Click;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(3, 57);
            panel7.Name = "panel7";
            panel7.Size = new Size(236, 10);
            panel7.TabIndex = 8;
            // 
            // classNameTextBox
            // 
            classNameTextBox.Dock = DockStyle.Top;
            classNameTextBox.Location = new Point(3, 34);
            classNameTextBox.Name = "classNameTextBox";
            classNameTextBox.Size = new Size(236, 23);
            classNameTextBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(3, 19);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 9;
            label3.Text = "新檔檔名:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(openOldObjectButton);
            groupBox2.Controls.Add(panel4);
            groupBox2.Controls.Add(objectComboBox);
            groupBox2.Controls.Add(panel5);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(panel6);
            groupBox2.Controls.Add(createNewObjectButton);
            groupBox2.Controls.Add(panel8);
            groupBox2.Controls.Add(objectNameTextBox);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(13, 274);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(242, 253);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Object Diagram";
            // 
            // openOldObjectButton
            // 
            openOldObjectButton.Dock = DockStyle.Top;
            openOldObjectButton.Location = new Point(3, 198);
            openOldObjectButton.Name = "openOldObjectButton";
            openOldObjectButton.Size = new Size(236, 42);
            openOldObjectButton.TabIndex = 4;
            openOldObjectButton.Text = "開啟舊檔";
            openOldObjectButton.UseVisualStyleBackColor = true;
            openOldObjectButton.Click += openOldObjectButton_Click;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 188);
            panel4.Name = "panel4";
            panel4.Size = new Size(236, 10);
            panel4.TabIndex = 6;
            // 
            // objectComboBox
            // 
            objectComboBox.Dock = DockStyle.Top;
            objectComboBox.FormattingEnabled = true;
            objectComboBox.Location = new Point(3, 165);
            objectComboBox.Name = "objectComboBox";
            objectComboBox.Size = new Size(236, 23);
            objectComboBox.TabIndex = 1;
            objectComboBox.SelectedIndexChanged += objectComboBox_SelectedIndexChanged;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(3, 155);
            panel5.Name = "panel5";
            panel5.Size = new Size(236, 10);
            panel5.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(3, 140);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 3;
            label2.Text = "舊檔:";
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(3, 106);
            panel6.Name = "panel6";
            panel6.Size = new Size(236, 34);
            panel6.TabIndex = 2;
            // 
            // createNewObjectButton
            // 
            createNewObjectButton.Dock = DockStyle.Top;
            createNewObjectButton.Location = new Point(3, 67);
            createNewObjectButton.Name = "createNewObjectButton";
            createNewObjectButton.Size = new Size(236, 39);
            createNewObjectButton.TabIndex = 0;
            createNewObjectButton.Text = "開啟新檔";
            createNewObjectButton.UseVisualStyleBackColor = true;
            createNewObjectButton.Click += createNewObjectButton_Click;
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(3, 57);
            panel8.Name = "panel8";
            panel8.Size = new Size(236, 10);
            panel8.TabIndex = 11;
            // 
            // objectNameTextBox
            // 
            objectNameTextBox.Dock = DockStyle.Top;
            objectNameTextBox.Location = new Point(3, 34);
            objectNameTextBox.Name = "objectNameTextBox";
            objectNameTextBox.Size = new Size(236, 23);
            objectNameTextBox.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(3, 19);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 12;
            label4.Text = "新檔檔名:";
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Left;
            panel11.Location = new Point(0, 0);
            panel11.Name = "panel11";
            panel11.Size = new Size(269, 861);
            panel11.TabIndex = 6;
            // 
            // panel9
            // 
            panel9.BackColor = SystemColors.Control;
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(269, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(1315, 861);
            panel9.TabIndex = 7;
            // 
            // SelectDiagramTypeUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel9);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel11);
            Name = "SelectDiagramTypeUserControl";
            Size = new Size(1584, 861);
            Load += SelectDiagramTypeUserControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panel1;
        private ComboBox classComboBox;
        private Button createNewClassButton;
        private Button openOldClassButton;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private GroupBox groupBox2;
        private Button openOldObjectButton;
        private Panel panel4;
        private ComboBox objectComboBox;
        private Panel panel5;
        private Label label2;
        private Panel panel6;
        private Button createNewObjectButton;
        private Panel panel7;
        private TextBox classNameTextBox;
        private Label label3;
        private Panel panel8;
        private TextBox objectNameTextBox;
        private Label label4;
        private Panel panel11;
        private Panel panel9;
    }
}
