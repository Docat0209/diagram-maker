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
    public partial class ObjectDiagramMakerUserControl : UserControl
    {
        private int _canva_id;
        public ObjectDiagramMakerUserControl(int canva_id)
        {
            InitializeComponent();
            _canva_id = canva_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddObjectForm addObjectForm = new AddObjectForm(_canva_id);
            addObjectForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelObjectForm delObjectForm = new DelObjectForm(_canva_id);
            delObjectForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddLinksForm addLinksForm = new AddLinksForm(_canva_id);
            addLinksForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DelLinkForm delLinkForm = new DelLinkForm(_canva_id);
            delLinkForm.ShowDialog();
        }
    }
}
