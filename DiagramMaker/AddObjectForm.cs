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
    public partial class AddObjectForm : Form
    {
        private int _canvaId;
        public AddObjectForm(int canvaId)
        {
            InitializeComponent();
            _canvaId = canvaId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int objectId = ObjectDiagramService.CreateNewObject(objectNameTextBox.Text,classNameTextBox.Text, _canvaId);

            foreach (DataGridViewRow row in attDataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["att_name"].Value?.ToString();
                string value = row.Cells["att_value"].Value?.ToString();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    ObjectDiagramService.AddObjectAtt(name, value, objectId);
                }
            }
            this.Close();
        }

    }
}
