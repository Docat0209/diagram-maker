using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DiagramMaker.ObjectDiagramService;

namespace DiagramMaker
{
    public partial class ObjectDiagramMakerUserControl : UserControl
    {
        private int _canva_id;
        public ObjectDiagramMakerUserControl(int canva_id)
        {
            InitializeComponent();
            _canva_id = canva_id;
        }

        private PaintEventHandler _paintHandler;

        private void ObjectDiagramMakerUserControl_Load(object sender, EventArgs e)
        {
            DataBaseInit();
        }

        private void DataBaseInit()
        {
            panel2.Controls.Clear();
            panel2.Paint -= _paintHandler;
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
            panel2.Paint += _paintHandler;
            panel2.Invalidate(); // 觸發重繪
        }

        private void ApplyTreeLayout(Dictionary<int, Panel> objectPanels)
        {
            int currentX = 50, currentY = 50, layerHeight = 300;
            foreach (var objectPanel in objectPanels.Values)
            {
                objectPanel.Location = new Point(currentX, currentY);
                currentX += objectPanel.Width + 500;
                if (currentX > panel2.Width - objectPanel.Width)
                {
                    currentX = 50;
                    currentY += layerHeight;
                }
                panel2.Controls.Add(objectPanel);
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

        private static void SavePanelAsPng(Panel panel)
        {
            using (Bitmap bitmap = new Bitmap(panel.Width, panel.Height))
            {
                panel.DrawToBitmap(bitmap, new Rectangle(0, 0, panel.Width, panel.Height));

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PNG Image|*.png";
                    saveFileDialog.Title = "Save Panel as PNG";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                    {
                        bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                        MessageBox.Show("Panel saved as PNG successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddObjectForm addObjectForm = new AddObjectForm(_canva_id);
            addObjectForm.ShowDialog();
            DataBaseInit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelObjectForm delObjectForm = new DelObjectForm(_canva_id);
            delObjectForm.ShowDialog();
            DataBaseInit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddLinksForm addLinksForm = new AddLinksForm(_canva_id);
            addLinksForm.ShowDialog();
            DataBaseInit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DelLinkForm delLinkForm = new DelLinkForm(_canva_id);
            delLinkForm.ShowDialog();
            DataBaseInit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SavePanelAsPng(panel2);
        }
    }
}
