using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DiagramMaker.DelRelationshipForm;

namespace DiagramMaker
{
    public partial class DelLinkForm : Form
    {
        private int _canvaId;
        public DelLinkForm(int canvaId)
        {
            InitializeComponent();
            _canvaId=canvaId;
        }

        private void DelLinkForm_Load(object sender, EventArgs e)
        {
            LoadLinksComboBoxData();
        }

        public class ComboBoxValue
        {
            public int Id1 { get; set; }
            public int Id2 { get; set; }
        }

        private void LoadLinksComboBoxData()
        {
            try
            {
                var data = ObjectDiagramService.GetLinksByCanvaId(_canvaId);
                linkComboBox.Items.Clear();

                foreach (var item in data)
                {
                    string display_name = $"{item.ObjectName1}:{item.ClassName1}_{item.linkText}_{item.ObjectName2}:{item.ClassName2}";

                    linkComboBox.Items.Add(new
                    {
                        Value = new ComboBoxValue { Id1 = item.Id1, Id2 = item.Id2 },
                        DisplayName = display_name
                    });
                }

                linkComboBox.DisplayMember = "DisplayName";
                linkComboBox.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加載資料時發生錯誤：{ex.Message}");
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (linkComboBox.SelectedItem != null)
            {
                dynamic selectedItem = linkComboBox.SelectedItem;
                ComboBoxValue selectedId = selectedItem.Value;
                ObjectDiagramService.DelLink(selectedId.Id1, selectedId.Id2);
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }
            this.Close();
        }
    }
}
