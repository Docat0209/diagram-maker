namespace DiagramMaker
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            loginErrorLabel = new Label();
            loginButton = new Button();
            registerButton = new Button();
            passwordTextBox = new TextBox();
            label2 = new Label();
            accountTextBox = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(loginErrorLabel);
            groupBox1.Controls.Add(loginButton);
            groupBox1.Controls.Add(registerButton);
            groupBox1.Controls.Add(passwordTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(accountTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 227);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "登入";
            // 
            // loginErrorLabel
            // 
            loginErrorLabel.AutoSize = true;
            loginErrorLabel.ForeColor = Color.LightCoral;
            loginErrorLabel.Location = new Point(10, 92);
            loginErrorLabel.Name = "loginErrorLabel";
            loginErrorLabel.Size = new Size(0, 15);
            loginErrorLabel.TabIndex = 6;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(6, 119);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(239, 43);
            loginButton.TabIndex = 5;
            loginButton.Text = "登入";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(6, 168);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(239, 45);
            registerButton.TabIndex = 4;
            registerButton.Text = "註冊";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(50, 56);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(189, 23);
            passwordTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 59);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 2;
            label2.Text = "密碼:";
            // 
            // accountTextBox
            // 
            accountTextBox.Location = new Point(50, 27);
            accountTextBox.Name = "accountTextBox";
            accountTextBox.Size = new Size(189, 23);
            accountTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 30);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "帳號:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 251);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            Text = "DiagramMaker";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox accountTextBox;
        private Label label1;
        private TextBox passwordTextBox;
        private Label label2;
        private Button registerButton;
        private Label loginErrorLabel;
        private Button loginButton;
    }
}
