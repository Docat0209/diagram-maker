using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DiagramMaker
{
    public partial class SelectDiagramTypeUserControl : UserControl
    {
        private readonly int _userId;
        private DiagramMakerForm _form;
        public SelectDiagramTypeUserControl(int userId, DiagramMakerForm diagramMakerForm)
        {
            InitializeComponent();
            _userId = userId;
            _form = diagramMakerForm;
        }

        private void SelectDiagramTypeUserControl_Load(object sender, EventArgs e)
        {
            LoadClassComboBoxData();
        }

        private void LoadClassComboBoxData()
        {
            try
            {
                var data = ClassDiagramService.GetClassCanvaByUserId(_userId);
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

        private void openOldClassButton_Click(object sender, EventArgs e)
        {
            if (classComboBox.SelectedItem != null)
            {
                dynamic selectedItem = classComboBox.SelectedItem;
                int selectedId = selectedItem.Id;
                string selectedName = selectedItem.Name;
                ClassDiagramMakerUserControl userControl = new ClassDiagramMakerUserControl(selectedId);
                _form.ChangeUserControl(userControl);
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }
        }

        private void createNewClassButton_Click(object sender, EventArgs e)
        {
            int canvaId = ClassDiagramService.CreateNewClassCanva(classNameTextBox.Text , _userId);
            ClassDiagramMakerUserControl userControl = new ClassDiagramMakerUserControl(canvaId);
            _form.ChangeUserControl(userControl);
        }
    }
}
