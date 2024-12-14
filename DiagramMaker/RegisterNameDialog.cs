using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramMaker
{
    public partial class RegisterNameDialog : Form
    {
        public string UserInput { get; set; }
        public RegisterNameDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UserInput = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
