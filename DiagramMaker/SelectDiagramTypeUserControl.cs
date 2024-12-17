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
            LoadObjectComboBoxData();
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

        private void LoadObjectComboBoxData()
        {
            try
            {
                var data = ObjectDiagramService.GetObjectCanvaByUserId(_userId);
                objectComboBox.Items.Clear();

                foreach (var item in data)
                {
                    objectComboBox.Items.Add(new { item.Id, item.Name });
                }

                objectComboBox.DisplayMember = "Name";
                objectComboBox.ValueMember = "Id";
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
            int canvaId = ClassDiagramService.CreateNewClassCanva(classNameTextBox.Text, _userId);
            ClassDiagramMakerUserControl userControl = new ClassDiagramMakerUserControl(canvaId);
            _form.ChangeUserControl(userControl);
        }

        private void createNewObjectButton_Click(object sender, EventArgs e)
        {
            int canvaId = ObjectDiagramService.CreateNewObjectCanva(objectNameTextBox.Text, _userId);
            ObjectDiagramMakerUserControl userControl = new ObjectDiagramMakerUserControl(canvaId);
            _form.ChangeUserControl(userControl);
        }

        private void openOldObjectButton_Click(object sender, EventArgs e)
        {
            if (objectComboBox.SelectedItem != null)
            {
                dynamic selectedItem = objectComboBox.SelectedItem;
                int selectedId = selectedItem.Id;
                ObjectDiagramMakerUserControl userControl = new ObjectDiagramMakerUserControl(selectedId);
                _form.ChangeUserControl(userControl);
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }
        }
    }
}
