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
    public partial class ClassDiagramMakerUserControl : UserControl
    {
        private int _canva_id;
        public ClassDiagramMakerUserControl(int canva_id)
        {
            InitializeComponent();
            _canva_id = canva_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClassForm addClassForm = new AddClassForm(_canva_id);
            addClassForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelClassForm delClassForm = new DelClassForm(_canva_id);
            delClassForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddRelationshipForm addRelationshipForm = new AddRelationshipForm(_canva_id);
            addRelationshipForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DelRelationshipForm delRelationshipForm = new DelRelationshipForm(_canva_id);
            delRelationshipForm.ShowDialog();
        }
    }
}
