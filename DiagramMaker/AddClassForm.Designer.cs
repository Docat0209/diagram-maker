namespace DiagramMaker
{
    partial class AddClassForm
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
            methodDataGridView = new DataGridView();
            method_modifiers = new DataGridViewTextBoxColumn();
            method_name = new DataGridViewTextBoxColumn();
            method_parameter = new DataGridViewTextBoxColumn();
            method_returnType = new DataGridViewTextBoxColumn();
            classNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            att_modifiers = new DataGridViewTextBoxColumn();
            att_name = new DataGridViewTextBoxColumn();
            att_dataType = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)attDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)methodDataGridView).BeginInit();
            SuspendLayout();
            // 
            // attDataGridView
            // 
            attDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            attDataGridView.Columns.AddRange(new DataGridViewColumn[] { att_modifiers, att_name, att_dataType });
            attDataGridView.Location = new Point(25, 105);
            attDataGridView.Name = "attDataGridView";
            attDataGridView.Size = new Size(344, 307);
            attDataGridView.TabIndex = 2;
            // 
            // methodDataGridView
            // 
            methodDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            methodDataGridView.Columns.AddRange(new DataGridViewColumn[] { method_modifiers, method_name, method_parameter, method_returnType });
            methodDataGridView.Location = new Point(413, 105);
            methodDataGridView.Name = "methodDataGridView";
            methodDataGridView.Size = new Size(443, 307);
            methodDataGridView.TabIndex = 3;
            // 
            // method_modifiers
            // 
            method_modifiers.HeaderText = "modifiers";
            method_modifiers.Name = "method_modifiers";
            // 
            // method_name
            // 
            method_name.HeaderText = "name";
            method_name.Name = "method_name";
            // 
            // method_parameter
            // 
            method_parameter.HeaderText = "parameter";
            method_parameter.Name = "method_parameter";
            // 
            // method_returnType
            // 
            method_returnType.HeaderText = "return type";
            method_returnType.Name = "method_returnType";
            // 
            // classNameTextBox
            // 
            classNameTextBox.Location = new Point(25, 42);
            classNameTextBox.Name = "classNameTextBox";
            classNameTextBox.Size = new Size(187, 23);
            classNameTextBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 5;
            label1.Text = "Class名稱:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 87);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 6;
            label2.Text = "屬性:";
            // 
            // button1
            // 
            button1.Location = new Point(25, 431);
            button1.Name = "button1";
            button1.Size = new Size(831, 52);
            button1.TabIndex = 7;
            button1.Text = "確定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(413, 87);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 8;
            label3.Text = "方法:";
            // 
            // att_modifiers
            // 
            att_modifiers.HeaderText = "modifiers";
            att_modifiers.Name = "att_modifiers";
            // 
            // att_name
            // 
            att_name.HeaderText = "name";
            att_name.Name = "att_name";
            // 
            // att_dataType
            // 
            att_dataType.HeaderText = "data_type";
            att_dataType.Name = "att_dataType";
            // 
            // AddClassForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 495);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(classNameTextBox);
            Controls.Add(methodDataGridView);
            Controls.Add(attDataGridView);
            Name = "AddClassForm";
            Text = "AddClassForm";
            Load += AddClassForm_Load;
            ((System.ComponentModel.ISupportInitialize)attDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)methodDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView attDataGridView;
        private DataGridView methodDataGridView;
        private TextBox classNameTextBox;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private DataGridViewTextBoxColumn method_modifiers;
        private DataGridViewTextBoxColumn method_name;
        private DataGridViewTextBoxColumn method_parameter;
        private DataGridViewTextBoxColumn method_returnType;
        private DataGridViewTextBoxColumn att_modifiers;
        private DataGridViewTextBoxColumn att_name;
        private DataGridViewTextBoxColumn att_dataType;
    }
}