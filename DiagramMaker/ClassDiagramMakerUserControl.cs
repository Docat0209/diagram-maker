using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static DiagramMaker.ClassDiagramService;

namespace DiagramMaker
{
    public partial class ClassDiagramMakerUserControl : UserControl
    {
        private int _canva_id;

        public ClassDiagramMakerUserControl(int canva_id)
        {
            InitializeComponent();
            _canva_id = canva_id;
        }

        private void DataBaseInit(object sender, EventArgs e)
        {
            // 從資料庫取得 class 資料
            List<ClassModel> classes = GetClass();
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
                Panel classPanel = new Panel{BorderStyle = BorderStyle.FixedSingle, Size = new Size(200, 200),BackColor = Color.LightGray};

                // Class 名稱定義
                Label classNameLabel = new Label{Text = classItem.Name,Font = new Font("Arial", 10, FontStyle.Bold),Location = new Point(5, 5),AutoSize = true};

                // 分隔線定義
                Label separatorLabel = new Label { BorderStyle = BorderStyle.Fixed3D, Location = new Point(0, 25), Size = new Size(classPanel.Width, 2) };

                // 分隔線定義
                Label separatorLabel2 = new Label { BorderStyle = BorderStyle.Fixed3D, Location = new Point(0, 117), Size = new Size(classPanel.Width, 2) };

                // 屬性區域容器定義
                Panel attributesPanel = new Panel{Location = new Point(0, 30),Size = new Size(classPanel.Width, (classPanel.Height - separatorLabel.Height - classNameLabel.Height) / 2), AutoScroll = true };// 分配固定高度給屬性

                // 方法區域容器定義
                Panel methodsPanel = new Panel{Location = new Point(0, 120),Size = new Size(classPanel.Width, (classPanel.Height - separatorLabel.Height - classNameLabel.Height) / 2),AutoScroll = true };

                // 屬性區域封裝
                int attributeYOffset = 0;
                foreach (var attribute in attributes)
                {
                    // 判別該屬性是否屬於當前類別
                    if (attribute.ClassId == classItem.ClassId)
                    {
                        Label attributeLabel = new Label
                        {
                            Text = $"{attribute.Modifiers} {attribute.DataType} {attribute.Name}",
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
            ApplyTreeLayout(classPanels);
            panel2.Paint += (sender, e) => DrawRelationships(e.Graphics, classPanels, relationships);
            panel2.Invalidate(); // 觸發重繪
        }

        private void ApplyTreeLayout(Dictionary<int, Panel> classPanels)
        {
            int currentX = 50, currentY = 50, layerHeight = 300;
            foreach (var classPanel in classPanels.Values)
            {
                classPanel.Location = new Point(currentX, currentY);
                currentX += classPanel.Width + 900;
                if (currentX > panel2.Width - classPanel.Width)
                {
                    currentX = 50;
                    currentY += layerHeight;
                }
                panel2.Controls.Add(classPanel);
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
                    (Point start, string edgeA) = GetEdgePoint(classA, classB.Location);
                    (Point end, string edgeB) = GetEdgePoint(classB, classA.Location);

                    using var pen = GetRelationshipPen(relationship.RelationshipType);

                    start = AdjustEdgePoint(start, edgeA, index, relationships.Count);
                    end = AdjustEdgePoint(end, edgeB, index, relationships.Count);

                    if(relationship.RelationshipType != 1 && relationship.RelationshipType != 2)
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

        //private List<Point> CalculatePath(Point start, Point end, Dictionary<int, Panel> classPanels)
        //{
        //    List<Point> path = new List<Point> { start };

        //    foreach (var panel in classPanels.Values)
        //    {
        //        Rectangle obstacle = new Rectangle(panel.Location, panel.Size); // 使用 Panel 的邊界

        //        if (ObstacleIntersectsLine(start, end, obstacle))
        //        {
        //            // 計算中途點的位置，避免穿越障礙
        //            Point midPoint = CalculateMidPoint(start, end, obstacle);
        //            path.Add(midPoint);
        //        }
        //    }

        //    path.Add(end);
        //    return path;
        //}

        //private bool ObstacleIntersectsLine(Point start, Point end, Rectangle obstacle)
        //{
        //    // 計算線段的邊界
        //    int minX = Math.Min(start.X, end.X);
        //    int maxX = Math.Max(start.X, end.X);
        //    int minY = Math.Min(start.Y, end.Y);
        //    int maxY = Math.Max(start.Y, end.Y);

        //    // 檢查障礙物邊界是否和線段相交
        //    return obstacle.IntersectsWith(new Rectangle(minX, minY, maxX - minX, maxY - minY));
        //}

        //private Point CalculateMidPoint(Point start, Point end, Rectangle obstacle)
        //{
        //    int midX = (start.X + end.X) / 2;
        //    int midY = (start.Y + end.Y) / 2;

        //    // 檢查是否超過障礙物的邊界
        //    if (obstacle.Contains(midX, midY))
        //    {
        //        // 設置到障礙物的邊界的最近點
        //        midX = Math.Max(obstacle.Left, Math.Min(midX, obstacle.Right));
        //        midY = Math.Max(obstacle.Top, Math.Min(midY, obstacle.Bottom));
        //    }

        //    return new Point(midX, midY);
        //}


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



        private void button1_Click(object sender, EventArgs e)
        {
            AddClassForm addClassForm = new AddClassForm(_canva_id);
            addClassForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelClassForm delClassForm = new DelClassForm(_canva_id);
            delClassForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddRelationshipForm addRelationshipForm = new AddRelationshipForm(_canva_id);
            addRelationshipForm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DelRelationshipForm delRelationshipForm = new DelRelationshipForm(_canva_id);
            delRelationshipForm.ShowDialog();
        }
    }
}
