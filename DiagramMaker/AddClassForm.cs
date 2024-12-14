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
    public partial class AddClassForm : Form
    {
        private int _canvaId;
        public AddClassForm(int canvaId)
        {
            InitializeComponent();
            _canvaId = canvaId;
        }

        private void AddClassForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int classId = ClassDiagramService.CreateNewClass(classNameTextBox.Text , _canvaId);

            foreach (DataGridViewRow row in attDataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                string modifiers = row.Cells["att_modifiers"].Value?.ToString();
                string name = row.Cells["att_name"].Value?.ToString();
                string dataType = row.Cells["att_dataType"].Value?.ToString();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(modifiers) && !string.IsNullOrEmpty(dataType))
                {
                    ClassDiagramService.AddClassAtt(modifiers, name, dataType, classId);
                }
            }
            this.Close();
        }
    }
}
