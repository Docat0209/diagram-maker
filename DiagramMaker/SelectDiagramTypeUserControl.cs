using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DiagramMaker.ClassDiagramService;
using static DiagramMaker.ObjectDiagramService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DiagramMaker
{
    public partial class SelectDiagramTypeUserControl : UserControl
    {
        private readonly int _userId;
        private PaintEventHandler _paintHandler;
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
                ClassDiagramMakerUserControl userControl = new ClassDiagramMakerUserControl(selectedId, _form, _userId);
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
            ClassDiagramMakerUserControl userControl = new ClassDiagramMakerUserControl(canvaId, _form, _userId);
            _form.ChangeUserControl(userControl);
        }

        private void createNewObjectButton_Click(object sender, EventArgs e)
        {
            int canvaId = ObjectDiagramService.CreateNewObjectCanva(objectNameTextBox.Text, _userId);
            ObjectDiagramMakerUserControl userControl = new ObjectDiagramMakerUserControl(canvaId, _form, _userId);
            _form.ChangeUserControl(userControl);
        }

        private void openOldObjectButton_Click(object sender, EventArgs e)
        {
            if (objectComboBox.SelectedItem != null)
            {
                dynamic selectedItem = objectComboBox.SelectedItem;
                int selectedId = selectedItem.Id;
                ObjectDiagramMakerUserControl userControl = new ObjectDiagramMakerUserControl(selectedId, _form, _userId);
                _form.ChangeUserControl(userControl);
            }
            else
            {
                MessageBox.Show("請先選擇一個項目！");
            }
        }

        private void DataBaseInit(int _canva_id)
        {
            panel9.Controls.Clear();
            panel9.Paint -= _paintHandler;
            List<ObjectModel> objects = GetObjects(_canva_id);
            List<ObjectAttributeModel> attributes = GetObjectAttributes();
            List<LinksModel> links = GetLinks();

            DisplayClasses(objects, attributes, links);
        }

        private void DisplayClasses(
            List<ObjectModel> objects,
            List<ObjectAttributeModel> attributes,
            List<LinksModel> links)
        {
            Dictionary<int, Panel> objectPanels = new Dictionary<int, Panel>(); // 儲存每個類別的 Panel 位置

            // 建立每個 object 的 Panel
            foreach (var objectItem in objects)
            {
                // 建立 objectsPanel 代表當前類別
                Panel objectPanel = new Panel { BorderStyle = BorderStyle.FixedSingle, Size = new Size(300, 200), BackColor = Color.LightGray };

                // objects 名稱定義
                Label objectNameLabel = new Label { Text = objectItem.ObjectName, Font = new Font("Arial", 10, FontStyle.Bold), Location = new Point(5, 5), AutoSize = true };

                // 分隔線定義
                Label separatorLabel = new Label { BorderStyle = BorderStyle.Fixed3D, Location = new Point(0, 25), Size = new Size(objectPanel.Width, 2) };

                // 屬性區域容器定義
                Panel attributesPanel = new Panel { Location = new Point(0, 30), Size = new Size(objectPanel.Width, objectPanel.Height - separatorLabel.Height - objectNameLabel.Height), AutoScroll = true };

                // 屬性區域封裝
                int attributeYOffset = 0;
                foreach (var attribute in attributes)
                {
                    // 判別該屬性是否屬於當前類別
                    if (attribute.ObjectId == objectItem.ObjectId)
                    {
                        Label attributeLabel = new Label
                        {
                            Text = $"{attribute.Name} = {attribute.Value}",
                            Font = new Font("Arial", 9),
                            Location = new Point(5, attributeYOffset),
                            AutoSize = true
                        };
                        attributesPanel.Controls.Add(attributeLabel);
                        attributeYOffset += 20;
                    }
                }

                objectPanel.Controls.Add(objectNameLabel);
                objectPanel.Controls.Add(separatorLabel);
                objectPanel.Controls.Add(attributesPanel);

                objectPanels[objectItem.ObjectId] = objectPanel;
            }
            ApplyTreeLayout(objectPanels);
            _paintHandler = (sender, e) => DrawRelationships(e.Graphics, objectPanels, links);
            panel9.Paint += _paintHandler;
            panel9.Invalidate(); // 觸發重繪
        }

        private void ApplyTreeLayout(Dictionary<int, Panel> objectPanels)
        {
            int currentX = 50, currentY = 50, layerHeight = 300;
            foreach (var objectPanel in objectPanels.Values)
            {
                objectPanel.Location = new Point(currentX, currentY);
                currentX += objectPanel.Width + 500;
                if (currentX > panel9.Width - objectPanel.Width)
                {
                    currentX = 50;
                    currentY += layerHeight;
                }
                panel9.Controls.Add(objectPanel);
            }
        }

        private void DrawRelationships(Graphics g, Dictionary<int, Panel> objectPanels, List<LinksModel> links)
        {
            int index = 0;
            foreach (var link in links)
            {
                if (objectPanels.TryGetValue(link.ObjectAId, out var objectA) &&
                    objectPanels.TryGetValue(link.ObjectBId, out var objectB))
                {
                    (Point start, string edgeA) = GetEdgePoint(objectA, objectB.Location);
                    (Point end, string edgeB) = GetEdgePoint(objectB, objectA.Location);

                    var pen = new Pen(Color.Black, 2);

                    start = AdjustEdgePoint(start, edgeA, index, links.Count);
                    end = AdjustEdgePoint(end, edgeB, index, links.Count);

                    g.DrawLine(pen, start, end);

                    // 計算文字的位置（線段中點）
                    Point textPosition = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);

                    // 繪製文字
                    string relationshipText = $"{link.LinkText}"; // 可以根據需要自訂文字內容
                    var font = new Font("Arial", 10);
                    var brush = new SolidBrush(Color.Black);
                    g.DrawString(relationshipText, font, brush, textPosition);
                }
                index++;
            }
        }

        private Point AdjustEdgePoint(Point edgePoint, string edge, int index, int total)
        {
            int offset = 20;

            if (total > 1)
            {
                int adjustment = (index - total / 2) * offset; // 中心對稱偏移計算

                switch (edge)
                {
                    case "Top":
                    case "Bottom":
                        edgePoint.X += adjustment;
                        break;
                    case "Left":
                    case "Right":
                        edgePoint.Y += adjustment;
                        break;
                }
            }
            return edgePoint;
        }

        // 計算連接點（Panel 的邊緣）
        private (Point point, string edge) GetEdgePoint(Panel panel, Point target, int offset = 0)
        {
            int centerX = panel.Location.X + panel.Width / 2;
            int centerY = panel.Location.Y + panel.Height / 2;

            int deltaX = target.X - centerX;
            int deltaY = target.Y - centerY;

            if (Math.Abs(deltaX) > Math.Abs(deltaY)) // 左右邊緣
            {
                if (deltaX > 0) // 目標在右邊
                {
                    return (new Point(panel.Location.X + panel.Width, centerY), "Right");
                }
                else // 目標在左邊
                {
                    return (new Point(panel.Location.X, centerY), "Left");
                }
            }
            else // 上下邊緣
            {
                if (deltaY > 0) // 目標在下方
                {
                    return (new Point(centerX, panel.Location.Y + panel.Height), "Bottom");
                }
                else // 目標在上方
                {
                    return (new Point(centerX, panel.Location.Y), "Top");
                }
            }
        }

        private void DataBaseInit2(int _canva_id)
        {
            panel9.Controls.Clear();
            panel9.Paint -= _paintHandler;
            // 從資料庫取得 class 資料
            List<ClassModel> classes = GetClass(_canva_id);
            List<ClassAttributeModel> attributes = GetClassAttributes();
            List<ClassMethodModel> methods = GetClassMethods();
            List<RelationshipModel> relationships = GetRelationships();

            DisplayClasses(classes, attributes, methods, relationships);
        }

        private void DisplayClasses(
            List<ClassModel> classes,
            List<ClassAttributeModel> attributes,
            List<ClassMethodModel> methods,
            List<RelationshipModel> relationships)
        {
            Dictionary<int, Panel> classPanels = new Dictionary<int, Panel>(); // 儲存每個類別的 Panel 位置

            // 建立每個 Class 的 Panel
            foreach (var classItem in classes)
            {
                // 建立 classPanel 代表當前類別
                Panel classPanel = new Panel { BorderStyle = BorderStyle.FixedSingle, Size = new Size(200, 200), BackColor = Color.LightGray };

                // Class 名稱定義
                Label classNameLabel = new Label { Text = classItem.Name, Font = new Font("Arial", 10, FontStyle.Bold), Location = new Point(5, 5), AutoSize = true };

                // 分隔線定義
                Label separatorLabel = new Label { BorderStyle = BorderStyle.Fixed3D, Location = new Point(0, 25), Size = new Size(classPanel.Width, 2) };

                // 分隔線定義
                Label separatorLabel2 = new Label { BorderStyle = BorderStyle.Fixed3D, Location = new Point(0, 117), Size = new Size(classPanel.Width, 2) };

                // 屬性區域容器定義
                Panel attributesPanel = new Panel { Location = new Point(0, 30), Size = new Size(classPanel.Width, (classPanel.Height - separatorLabel.Height - classNameLabel.Height) / 2), AutoScroll = true };// 分配固定高度給屬性

                // 方法區域容器定義
                Panel methodsPanel = new Panel { Location = new Point(0, 120), Size = new Size(classPanel.Width, (classPanel.Height - separatorLabel.Height - classNameLabel.Height) / 2), AutoScroll = true };

                // 屬性區域封裝
                int attributeYOffset = 0;
                foreach (var attribute in attributes)
                {
                    // 判別該屬性是否屬於當前類別
                    if (attribute.ClassId == classItem.ClassId)
                    {
                        Label attributeLabel = new Label
                        {
                            Text = $"{attribute.Modifiers} {attribute.Name}:{attribute.DataType}",
                            Font = new Font("Arial", 9),
                            Location = new Point(5, attributeYOffset),
                            AutoSize = true
                        };
                        attributesPanel.Controls.Add(attributeLabel);
                        attributeYOffset += 20;
                    }
                }

                // 方法區域封裝
                int methodYOffset = 0;
                foreach (var method in methods)
                {
                    if (method.ClassId == classItem.ClassId)
                    {
                        Label methodLabel = new Label
                        {
                            Text = $"{method.Modifiers} {method.Name}({method.Parameter}): {method.ReturnType}",
                            Font = new Font("Arial", 9),
                            Location = new Point(5, methodYOffset),
                            AutoSize = true
                        };
                        methodsPanel.Controls.Add(methodLabel);
                        methodYOffset += 20;
                    }
                }

                classPanel.Controls.Add(classNameLabel);
                classPanel.Controls.Add(separatorLabel);
                classPanel.Controls.Add(attributesPanel);
                classPanel.Controls.Add(separatorLabel2);
                classPanel.Controls.Add(methodsPanel);

                classPanels[classItem.ClassId] = classPanel;
            }
            ApplyTreeLayout2(classPanels);
            _paintHandler = (sender, e) => DrawRelationships(e.Graphics, classPanels, relationships);
            panel9.Paint += _paintHandler;
            panel9.Invalidate(); // 觸發重繪
        }

        private void ApplyTreeLayout2(Dictionary<int, Panel> classPanels)
        {
            int currentX = 50, currentY = 50, layerHeight = 300;
            foreach (var classPanel in classPanels.Values)
            {
                classPanel.Location = new Point(currentX, currentY);
                currentX += classPanel.Width + 900;
                if (currentX > panel9.Width - classPanel.Width)
                {
                    currentX = 50;
                    currentY += layerHeight;
                }
                panel9.Controls.Add(classPanel);
            }
        }

        private void DrawRelationships(Graphics g, Dictionary<int, Panel> classPanels, List<RelationshipModel> relationships)
        {
            int index = 0;
            foreach (var relationship in relationships)
            {
                if (classPanels.TryGetValue(relationship.ClassAId, out var classA) &&
                    classPanels.TryGetValue(relationship.ClassBId, out var classB))
                {
                    (Point start, string edgeA) = GetEdgePoint2(classA, classB.Location);
                    (Point end, string edgeB) = GetEdgePoint2(classB, classA.Location);

                    using var pen = GetRelationshipPen(relationship.RelationshipType);

                    start = AdjustEdgePoint2(start, edgeA, index, relationships.Count);
                    end = AdjustEdgePoint2(end, edgeB, index, relationships.Count);

                    if (relationship.RelationshipType != 1 && relationship.RelationshipType != 2)
                    {
                        switch (edgeB)
                        {
                            case "Top":
                                end.Y -= 10;
                                break;
                            case "Bottom":
                                end.Y += 10;
                                break;
                            case "Left":
                                end.X -= 10;
                                break;
                            case "Right":
                                end.X += 10;
                                break;
                        };
                    }

                    g.DrawLine(pen, start, end);
                    //var path = CalculatePath(start, end, classPanels);
                    //for (int i = 0; i < path.Count - 1; i++)
                    //{
                    //    g.DrawLine(pen, path[i], path[i + 1]);
                    //}

                    DrawRelationshipSymbol(g, relationship.RelationshipType, start, end, edgeB, pen.Color);
                }
                index++;
            }
        }

        private Pen GetRelationshipPen(int relationshipType)
        {
            return relationshipType switch
            {
                1 => new Pen(Color.Black, 2), // Association
                2 => new Pen(Color.Black, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }, // Dependency
                3 => new Pen(Color.Black, 2), // Composition
                4 => new Pen(Color.Black, 2), // Aggregation
                5 => new Pen(Color.Black, 2), // Inheritance
                6 => new Pen(Color.Black, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }, // Implementation
                _ => throw new ArgumentException("Invalid relationship type")
            };
        }

        private void DrawRelationshipSymbol(Graphics g, int relationshipType, Point start, Point end, string edgeB, Color color)
        {
            switch (relationshipType)
            {
                case 1: // Association
                case 2: // Dependency
                    DrawArrow(g, start, end, color);
                    break;
                case 3: // Composition
                    DrawDiamond(g, end, color, filled: true);
                    break;
                case 4: // Aggregation
                    DrawDiamond(g, end, color, filled: false);
                    break;
                case 5: // Inheritance
                case 6: // Implementation
                    DrawTriangle(g, end, edgeB, color);
                    break;
            }
        }


        private Point AdjustEdgePoint2(Point edgePoint, string edge, int index, int total)
        {
            int offset = 20;

            if (total > 1)
            {
                int adjustment = (index - total / 2) * offset; // 中心對稱偏移計算

                switch (edge)
                {
                    case "Top":
                    case "Bottom":
                        edgePoint.X += adjustment;
                        break;
                    case "Left":
                    case "Right":
                        edgePoint.Y += adjustment;
                        break;
                }
            }
            return edgePoint;
        }


        // 修改繪製箭頭的方法
        private void DrawArrow(Graphics g, Point start, Point end, Color color)
        {
            const int arrowSize = 10; // 箭頭大小
            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X);

            Point arrowPoint1 = new Point(
                (int)(end.X - arrowSize * Math.Cos(angle - Math.PI / 6)),
                (int)(end.Y - arrowSize * Math.Sin(angle - Math.PI / 6))
            );
            Point arrowPoint2 = new Point(
                (int)(end.X - arrowSize * Math.Cos(angle + Math.PI / 6)),
                (int)(end.Y - arrowSize * Math.Sin(angle + Math.PI / 6))
            );

            using (Pen pen = new Pen(color, 2))
            {
                g.DrawLine(pen, end, arrowPoint1);
                g.DrawLine(pen, end, arrowPoint2);
            }
        }

        private void DrawDiamond(Graphics g, Point end, Color color, bool filled)
        {
            const int diamondSize = 10; // 菱形大小
            Point[] diamond = new Point[]
            {
                new Point(end.X, end.Y - diamondSize), // 上
                new Point(end.X + diamondSize, end.Y), // 右
                new Point(end.X, end.Y + diamondSize), // 下
                new Point(end.X - diamondSize, end.Y)  // 左
            };

            using (Brush brush = new SolidBrush(color))
            using (Pen pen = new Pen(color, 2))
            {
                if (filled)
                    g.FillPolygon(brush, diamond);
                else
                    g.DrawPolygon(pen, diamond);
            }
        }

        private void DrawTriangle(Graphics g, Point endPoint, string edge, Color color)
        {
            const int triangleSize = 10; // 三角形大小

            Point[] triangle = edge switch
            {
                "Top" => new Point[] // 尖端朝下（相反於 Top）
                {
                    new Point(endPoint.X, endPoint.Y + triangleSize),      // 尖端（朝下）
                    new Point(endPoint.X - triangleSize, endPoint.Y),      // 左上角
                    new Point(endPoint.X + triangleSize, endPoint.Y)       // 右上角
                },
                "Bottom" => new Point[] // 尖端朝上（相反於 Bottom）
                {
                    new Point(endPoint.X, endPoint.Y - triangleSize),      // 尖端（朝上）
                    new Point(endPoint.X - triangleSize, endPoint.Y),      // 左下角
                    new Point(endPoint.X + triangleSize, endPoint.Y)       // 右下角
                },
                "Left" => new Point[] // 尖端朝右（相反於 Left）
                {
                    new Point(endPoint.X + triangleSize, endPoint.Y),      // 尖端（朝右）
                    new Point(endPoint.X, endPoint.Y - triangleSize),      // 左上角
                    new Point(endPoint.X, endPoint.Y + triangleSize)       // 左下角
                },
                "Right" => new Point[] // 尖端朝左（相反於 Right）
                {
                    new Point(endPoint.X - triangleSize, endPoint.Y),      // 尖端（朝左）
                    new Point(endPoint.X, endPoint.Y - triangleSize),      // 右上角
                    new Point(endPoint.X, endPoint.Y + triangleSize)       // 右下角
                },
                _ => throw new ArgumentException("Invalid edge direction")
            };

            using (Brush brush = new SolidBrush(color))
            {
                g.FillPolygon(brush, triangle);
            }
        }


        // 計算連接點（Panel 的邊緣）
        private (Point point, string edge) GetEdgePoint2(Panel panel, Point target, int offset = 0)
        {
            int centerX = panel.Location.X + panel.Width / 2;
            int centerY = panel.Location.Y + panel.Height / 2;

            int deltaX = target.X - centerX;
            int deltaY = target.Y - centerY;

            if (Math.Abs(deltaX) > Math.Abs(deltaY)) // 左右邊緣
            {
                if (deltaX > 0) // 目標在右邊
                {
                    return (new Point(panel.Location.X + panel.Width, centerY), "Right");
                }
                else // 目標在左邊
                {
                    return (new Point(panel.Location.X, centerY), "Left");
                }
            }
            else // 上下邊緣
            {
                if (deltaY > 0) // 目標在下方
                {
                    return (new Point(centerX, panel.Location.Y + panel.Height), "Bottom");
                }
                else // 目標在上方
                {
                    return (new Point(centerX, panel.Location.Y), "Top");
                }
            }
        }

        private void objectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectComboBox.SelectedItem != null)
            {
                dynamic selectedItem = objectComboBox.SelectedItem;
                int selectedId = selectedItem.Id;
                DataBaseInit(selectedId);
            }
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classComboBox.SelectedItem != null)
            {
                dynamic selectedItem = classComboBox.SelectedItem;
                int selectedId = selectedItem.Id;
                DataBaseInit2(selectedId);
            }
        }
    }
}
