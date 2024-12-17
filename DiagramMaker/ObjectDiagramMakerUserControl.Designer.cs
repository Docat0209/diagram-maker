namespace DiagramMaker
{
    partial class ObjectDiagramMakerUserControl
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
            panel1 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 1091);
            panel1.TabIndex = 2;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.Location = new Point(0, 219);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(346, 73);
            button5.TabIndex = 4;
            button5.Text = "刪除links";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.Location = new Point(0, 146);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(346, 73);
            button4.TabIndex = 3;
            button4.Text = "新增links";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.Location = new Point(0, 73);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(346, 73);
            button3.TabIndex = 2;
            button3.Text = "刪除object";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(346, 73);
            button1.TabIndex = 0;
            button1.Text = "新增object";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(346, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1691, 1091);
            panel2.TabIndex = 3;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Bottom;
            button2.Location = new Point(0, 1018);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(346, 73);
            button2.TabIndex = 5;
            button2.Text = "匯出圖表";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ObjectDiagramMakerUserControl
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "ObjectDiagramMakerUserControl";
            Size = new Size(2037, 1091);
            Load += ObjectDiagramMakerUserControl_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button1;
        private Panel panel2;
        private Button button2;
    }
}
