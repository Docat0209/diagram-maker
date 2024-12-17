namespace DiagramMaker
{
    partial class AddObjectForm
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
            attDataGridView = new DataGridView();
            att_name = new DataGridViewTextBoxColumn();
            att_value = new DataGridViewTextBoxColumn();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            objectNameTextBox = new TextBox();
            label3 = new Label();
            classNameTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)attDataGridView).BeginInit();
            SuspendLayout();
            // 
            // attDataGridView
            // 
            attDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            attDataGridView.Columns.AddRange(new DataGridViewColumn[] { att_name, att_value });
            attDataGridView.Location = new Point(12, 97);
            attDataGridView.Name = "attDataGridView";
            attDataGridView.Size = new Size(403, 307);
            attDataGridView.TabIndex = 9;
            // 
            // att_name
            // 
            att_name.HeaderText = "name";
            att_name.Name = "att_name";
            // 
            // att_value
            // 
            att_value.HeaderText = "value";
            att_value.Name = "att_value";
            // 
            // button1
            // 
            button1.Location = new Point(12, 423);
            button1.Name = "button1";
            button1.Size = new Size(403, 52);
            button1.TabIndex = 14;
            button1.Text = "確定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 13;
            label2.Text = "屬性:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 12;
            label1.Text = "Object名稱:";
            // 
            // objectNameTextBox
            // 
            objectNameTextBox.Location = new Point(12, 34);
            objectNameTextBox.Name = "objectNameTextBox";
            objectNameTextBox.Size = new Size(187, 23);
            objectNameTextBox.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(228, 16);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 16;
            label3.Text = "Class名稱:";
            // 
            // classNameTextBox
            // 
            classNameTextBox.Location = new Point(228, 34);
            classNameTextBox.Name = "classNameTextBox";
            classNameTextBox.Size = new Size(187, 23);
            classNameTextBox.TabIndex = 15;
            // 
            // AddObjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 509);
            Controls.Add(label3);
            Controls.Add(classNameTextBox);
            Controls.Add(attDataGridView);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(objectNameTextBox);
            Name = "AddObjectForm";
            Text = "AddObjectForm";
            ((System.ComponentModel.ISupportInitialize)attDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView attDataGridView;
        private DataGridViewTextBoxColumn att_modifiers;
        private DataGridViewTextBoxColumn att_dataType;
        private DataGridView methodDataGridView;
        private DataGridViewTextBoxColumn method_modifiers;
        private DataGridViewTextBoxColumn method_name;
        private DataGridViewTextBoxColumn method_parameter;
        private DataGridViewTextBoxColumn method_returnType;
        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox objectNameTextBox;
        private DataGridViewTextBoxColumn att_name;
        private DataGridViewTextBoxColumn att_value;
        private Label label3;
        private TextBox classNameTextBox;
    }
}