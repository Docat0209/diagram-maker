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
    public partial class DelRelationshipForm : Form
    {
        private int _canvaId;
        private Dictionary<int, string> relationshipIdMap;
        public DelRelationshipForm(int canvaId)
        {
            InitializeComponent();
            _canvaId = canvaId;
        }

        private void DelRelationshipForm_Load(object sender, EventArgs e)
        {
            relationshipIdMap = new Dictionary<int, string>
            {
                {1,"Association"},
                {2,"Dependencies"},
                {3,"Composition"},
                {4,"Aggregation"},
                {5,"Inheritance"},
                {6,"Implementation"}
            };
            LoadRelationshipComboBoxData();
        }

        private string GetRelationshipName(int relationshipId)
        {
            return relationshipIdMap.TryGetValue(relationshipId, out string relationshipName)
                ? relationshipName
                : "未知關係";
        }


        public class ComboBoxValue
        {
            public int Id1 { get; set; }
            public int Id2 { get; set; }
        }
        private void LoadRelationshipComboBoxData()
        {
            try
            {
                var data = ClassDiagramService.GetRelationshipByCanvaId(_canvaId);
                relationshipComboBox.Items.Clear();

                foreach (var item in data)
                {
                    string relationshipName = GetRelationshipName(item.relationshipId);

                    string display_name = $"{item.Name1}_{relationshipName}_{item.Name2}";

                    relationshipComboBox.Items.Add(new
                    {
                        Value = new ComboBoxValue { Id1 = item.Id1, Id2 = item.Id2 },
                        DisplayName = display_name
                    });
                }

                relationshipComboBox.DisplayMember = "DisplayName";
                relationshipComboBox.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加載資料時發生錯誤：{ex.Message}");
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            if (relationshipComboBox.SelectedItem != null)
            {
                dynamic selectedItem = relationshipComboBox.SelectedItem;
                ComboBoxValue selectedId = selectedItem.Value;
                ClassDiagramService.DelRelationship(selectedId.Id1 , selectedId.Id2);
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }
            this.Close();
        }
    }
}
