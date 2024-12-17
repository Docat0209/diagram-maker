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
    public partial class AddLinksForm : Form
    {
        private int _canvaId;
        public AddLinksForm(int canvaId)
        {
            InitializeComponent();
            _canvaId=canvaId;
        }

        private void AddLinksForm_Load(object sender, EventArgs e)
        {
            LoadObjectComboBoxData();
        }

        private void LoadObjectComboBoxData()
        {
            try
            {
                var data = ObjectDiagramService.GetObjectByCanvaId(_canvaId);
                objectComboBox1.Items.Clear();
                objectComboBox2.Items.Clear();

                foreach (var item in data)
                {
                    string Name = item.ObjectName + ":" + item.ClassName;
                    objectComboBox1.Items.Add(new { item.Id, Name });
                    objectComboBox2.Items.Add(new { item.Id, Name });
                }

                objectComboBox1.DisplayMember = "Name";
                objectComboBox1.ValueMember = "Id";

                objectComboBox2.DisplayMember = "Name";
                objectComboBox2.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加載資料時發生錯誤：{ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (objectComboBox1.SelectedItem != null && objectComboBox2.SelectedItem != null)
            {
                dynamic selectedItem1 = objectComboBox1.SelectedItem;
                dynamic selectedItem2 = objectComboBox2.SelectedItem;
                int selectedId1 = selectedItem1.Id;
                int selectedId2 = selectedItem2.Id;

                String linkText = linkTextBox.Text;

                try
                {
                    ObjectDiagramService.AddLink(selectedId1, selectedId2, linkText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("已存在Link");
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
