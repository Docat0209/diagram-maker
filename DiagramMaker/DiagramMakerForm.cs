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
    public partial class DiagramMakerForm : Form
    {
        int _userid;
        public DiagramMakerForm(int userid)
        {
            InitializeComponent();
            _userid=userid;
        }

        private void DiagramMakerForm_Load(object sender, EventArgs e)
        {
            SelectDiagramTypeUserControl selectDiagramTypeUserControl = new SelectDiagramTypeUserControl(_userid , this);
            ChangeUserControl(selectDiagramTypeUserControl);
        }

        public void ChangeUserControl(UserControl userControl)
        {
            this.userControlPanel.Controls.Clear();
            this.userControlPanel.Controls.Add(userControl);
        }
    }
}
