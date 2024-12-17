using Org.BouncyCastle.Asn1.X509;
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
    public partial class DelClassForm : Form
    {
        private int _canvaId;
        public DelClassForm(int canvaId)
        {
            InitializeComponent();
            _canvaId = canvaId;
        }

        private void DelClassForm_Load(object sender, EventArgs e)
        {
            LoadClassComboBoxData();
        }

        private void LoadClassComboBoxData()
        {
            try
            {
                var data = ClassDiagramService.GetClassByCanvaId(_canvaId);
                classComboBox.Items.Clear();

                foreach (var item in data)
                {
                    classComboBox.Items.Add(new { item.Id, item.Name });
                }

                classComboBox.DisplayMember = "Name";
                classComboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加載資料時發生錯誤：{ex.Message}");
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (classComboBox.SelectedItem != null)
            {
                dynamic selectedItem = classComboBox.SelectedItem;
                int selectedId = selectedItem.Id;
                string selectedName = selectedItem.Name;
                ClassDiagramService.DelClass(selectedId);
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }
            this.Close();
        }
    }
}
