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
    public partial class AddRelationshipForm : Form
    {
        private int _canvaId;
        public AddRelationshipForm(int canvaId)
        {
            InitializeComponent();
            _canvaId = canvaId;
        }

        private void AddRelationshipForm_Load(object sender, EventArgs e)
        {
            LoadClassComboBoxData();
        }

        private void LoadClassComboBoxData()
        {
            try
            {
                var data = ClassDiagramService.GetClassByCanvaId(_canvaId);
                classComboBox1.Items.Clear();
                classComboBox2.Items.Clear();

                foreach (var item in data)
                {
                    classComboBox1.Items.Add(new { item.Id, item.Name });
                    classComboBox2.Items.Add(new { item.Id, item.Name });
                }

                classComboBox1.DisplayMember = "Name";
                classComboBox1.ValueMember = "Id";

                classComboBox2.DisplayMember = "Name";
                classComboBox2.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加載資料時發生錯誤：{ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (classComboBox1.SelectedItem != null && classComboBox2.SelectedItem != null && relationshipComboBox.SelectedItem != null)
            {
                dynamic selectedItem1 = classComboBox1.SelectedItem;
                dynamic selectedItem2 = classComboBox2.SelectedItem;
                int selectedId1 = selectedItem1.Id;
                int selectedId2 = selectedItem2.Id;

                int relationship = relationshipComboBox.SelectedIndex+1;

                try
                {
                    ClassDiagramService.AddRelationship(selectedId1, selectedId2, relationship);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("已存在Relationship");
                }
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }

            this.Close();
        }
    }
}
