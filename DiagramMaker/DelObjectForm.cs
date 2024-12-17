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
    public partial class DelObjectForm : Form
    {
        private int _canvaId;
        public DelObjectForm(int canvaId)
        {
            InitializeComponent();
            _canvaId = canvaId;
        }

        private void DelObjectForm_Load(object sender, EventArgs e)
        {
            LoadObjectComboBoxData();
        }

        private void LoadObjectComboBoxData()
        {
            try
            {
                var data = ObjectDiagramService.GetObjectByCanvaId(_canvaId);
                objectComboBox.Items.Clear();

                foreach (var item in data)
                {
                    string Name = item.ObjectName + ":" + item.ClassName;
                    objectComboBox.Items.Add(new { item.Id, Name });
                }

                objectComboBox.DisplayMember = "Name";
                objectComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加載資料時發生錯誤：{ex.Message}");
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (objectComboBox.SelectedItem != null)
            {
                dynamic selectedItem = objectComboBox.SelectedItem;
                int selectedId = selectedItem.Id;
                ObjectDiagramService.DelObject(selectedId);
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }
            this.Close();
        }
    }
}
