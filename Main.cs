using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using miniGIS.Models;
using System.Globalization;

namespace miniGIS
{
    public partial class Main : Form
    {
        List<Layer> layers;

        Graphics panelGraphics;

        bool canMoveLayer;
        bool canChangeLayerOrder;

        bool canCreateFrame;
        bool canDrawFrame;

        int zoomClick;    

        float currentX; 
        float currentY;

        public Main()
        {
            InitializeComponent();

            layers = new List<Layer>();

            canMoveLayer = false;
            canChangeLayerOrder = false;

            canCreateFrame = false;
            canDrawFrame = false;

            zoomClick = 0;

            currentX = 0;
            currentY = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BitmapBuffer.SetXY(centralPanel.Size);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panelGraphics = centralPanel.CreateGraphics();

            BitmapBuffer.SetXY(centralPanel.Size);

            panelGraphics.DrawImage(BitmapBuffer.Bitmap, BitmapBuffer.X, BitmapBuffer.Y);
        } 

        private void Form1_Click(object sender, EventArgs e)
        {
            if (centralPanel.Visible == false)
                centralPanel.Visible = true;         
        }

        private void loadLayer_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Все форматы (*.*)|*.*";
            openFileDialog1.Title = "Открыть файл";
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Layer layer;

                    var startIndex = openFileDialog1.FileName.LastIndexOf("\\") + 1;
                    var length = openFileDialog1.FileName.Length - startIndex;
                    var name = openFileDialog1.FileName.Substring(startIndex, length);

                    if (layers.Where(t => t.Name == name).Count() == 0)
                    {
                        if (openFileDialog1.FileName.Contains(".grid"))
                        {
                            layer = new GridLayer(openFileDialog1.FileName);
                            layer.Type = LayerType.Grid;

                            if (layers.Count == 0)
                            {
                                var temp = layer as GridLayer;

                                Map.SetMapScale(temp.Geometry);
                            }
                        }
                        else
                        {
                            layer = new VectorLayer(openFileDialog1.FileName);
                            layer.Type = LayerType.Vector;

                            if (layers.Count == 0)
                            {
                                var temp = layer as VectorLayer;

                                var xo = temp.Points.Min(p => p.X);
                                var yo = temp.Points.Min(p => p.Y);

                                var xn = temp.Points.Max(p => p.X);
                                var yn = temp.Points.Max(p => p.Y);

                                Map.SetMapScale(xo, yo, xn, yn);
                            }
                        }

                        layer.Name = name;
                        layer.Checked = true;

                        layers.Add(layer);
                        layersList.Items.Add(layer.Name, CheckState.Checked);

                        layersList.SetSelected(0, true);
                        rightPanel.Visible = true;
                    }
                    else
                        MessageBox.Show("Слой с таким именем уже существует");
                }
                catch
                {
                    MessageBox.Show("Ошибка при чтении файла");
                }
            }
        }

        private void loupePlus_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            BitmapBuffer.SetXoYo();

            var checkedLayers = new List<Layer>();

            foreach (var item in layers)
                if (item.Checked == true)
                    checkedLayers.Add(item);

            if (checkedLayers.Count != 0)
            {
                zoomClick++;

                if (zoomClick != 0)
                    resetLayer.Visible = true;
                else
                    resetLayer.Visible = false;

                if (zoomClick > -31 && zoomClick < 0)
                    loupeMinus.Visible = true;

                if (zoomClick < 31)
                {
                    Map.Scale *= 1.25f;
                    BitmapBuffer.Clear();

                    checkedLayers.Reverse();

                    foreach (var item in checkedLayers)
                        item.Paint();

                    BitmapBuffer.Paint(panelGraphics);

                    if (zoomClick == 30)
                        loupePlus.Visible = false;
                }                
            }
            else
                MessageBox.Show("Не отмечен слой");
        }

        private void loupeMinus_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            BitmapBuffer.SetXoYo();

            var checkedLayers = new List<Layer>();

            foreach (var item in layers)
                if (item.Checked == true)
                    checkedLayers.Add(item);

            if (checkedLayers.Count != 0)
            {
                zoomClick--;

                if (zoomClick != 0)
                    resetLayer.Visible = true;
                else
                    resetLayer.Visible = false;

                if (zoomClick < 31 && zoomClick > 0)
                    loupePlus.Visible = true;

                if (zoomClick > -31)
                {
                    Map.Scale /= 1.25f;
                    BitmapBuffer.Clear();

                    checkedLayers.Reverse();

                    foreach (var item in checkedLayers)
                        item.Paint();

                    BitmapBuffer.Paint(panelGraphics);

                    if (zoomClick == -30)
                        loupeMinus.Visible = false;
                }
            }
            else
                MessageBox.Show("Не отмечен слой");
        }

        private void resetLayer_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            var checkedLayers = new List<Layer>();

            foreach (var item in layers)
                if (item.Checked == true)
                    checkedLayers.Add(item);

            if (checkedLayers.Count != 0)
            {
                loupePlus.Visible = true;
                loupeMinus.Visible = true;
                resetLayer.Visible = false;

                zoomClick = 0;

                Map.SetStartScale();
                Map.SetMapCenter();

                BitmapBuffer.SetXoYo();
                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Paint(panelGraphics);
            }
            else
                MessageBox.Show("Не отмечен слой");    
        }

        private void moveLayer_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            var checkedLayers = new List<Layer>();

            foreach (var item in layers)
                if (item.Checked == true)
                    checkedLayers.Add(item);

            if (checkedLayers.Count != 0)
            {
                if (moveLayer.Text == "Переместить")
                {
                    canMoveLayer = true;
                    moveLayer.Text = "Отмена";
                    moveLayer.BackColor = Color.LightGreen;

                    loadLayer.Visible = false;
                    saveLayer.Visible = false;
                    deleteLayer.Visible = false;
                    layersList.Visible = false;
                    layerUp.Visible = false;
                    layerDown.Visible = false;

                    rightPanel.Visible = false;
                }
                else
                {
                    canMoveLayer = false;
                    moveLayer.Text = "Переместить";
                    moveLayer.BackColor = Color.WhiteSmoke;

                    loadLayer.Visible = true;
                    saveLayer.Visible = true;
                    deleteLayer.Visible = true;
                    layersList.Visible = true;
                    layerUp.Visible = true;
                    layerDown.Visible = true;

                    rightPanel.Visible = true;

                    layersList.SetSelected(0, true);
                }
            }
            else
                MessageBox.Show("Не отмечен слой");
        }

        private void deleteLayer_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            if (layersList.SelectedIndex != -1)
            {
                layers.RemoveAt(layersList.SelectedIndex);
                layersList.Items.RemoveAt(layersList.SelectedIndex);

                if (layers.Count == 0)
                    rightPanel.Visible = false;
                else
                    layersList.SetSelected(0, true);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                if (checkedLayers.Count != 0)
                {
                    BitmapBuffer.Clear();

                    checkedLayers.Reverse();

                    foreach (var item in checkedLayers)
                        item.Paint();

                    BitmapBuffer.Paint(panelGraphics);
                }
                else
                {
                    BitmapBuffer.Clear();
                    BitmapBuffer.Paint(panelGraphics);
                }
            }
            else
                MessageBox.Show("Невозможное действие");
        }

        private void saveLayer_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            if (layersList.SelectedIndex != -1)
            {
                saveFileDialog1.FileName = layersList.Text;
                saveFileDialog1.Title = "Сохранить файл";
                saveFileDialog1.RestoreDirectory = true;

                if (layersList.Text.Contains("grid"))
                    saveFileDialog1.Filter = "GRID модель (*.grid)|*.grid";
                else
                    saveFileDialog1.Filter = "3D точки (*.points)|*.points";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
                {
                    try
                    {
                        layers[layersList.SelectedIndex].Save(saveFileDialog1.FileName);

                        MessageBox.Show("Файл успешно сохранен");
                    }
                    catch
                    {
                        MessageBox.Show("Файл не сохранен");
                    }
                }
            }
            else
                MessageBox.Show("Невозможное действие");
        }

        private void layerUp_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            var index = layersList.SelectedIndex;

            if (index != -1 && index > 0)
            {
                canChangeLayerOrder = true;

                var obj = layersList.Items[index];
                var check = layersList.GetItemChecked(index);

                layersList.Items.RemoveAt(index);
                layersList.Items.Insert(index - 1, obj);
                layersList.SetItemChecked(index - 1, check);
                
                layersList.Text = obj.ToString();

                layers.Reverse(index - 1, 2);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                if (checkedLayers.Count != 0)
                {
                    BitmapBuffer.Clear();

                    checkedLayers.Reverse();

                    foreach (var item in checkedLayers)
                        item.Paint();

                    BitmapBuffer.Paint(panelGraphics);
                }
                else
                {
                    BitmapBuffer.Clear();
                    BitmapBuffer.Paint(panelGraphics);
                }

                canChangeLayerOrder = false;
            }
            else
                MessageBox.Show("Невозможное действие");
        }

        private void layerDown_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            var index = layersList.SelectedIndex;
            var s = layersList.Items.Count;

            if (index != -1 && index < s - 1)
            {
                canChangeLayerOrder = true;

                var obj = layersList.Items[index];
                var check = layersList.GetItemChecked(index);

                layersList.Items.RemoveAt(index);
                layersList.Items.Insert(index + 1, obj);
                layersList.SetItemChecked(index + 1, check);

                layersList.Text = obj.ToString();

                layers.Reverse(index, 2);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                if (checkedLayers.Count != 0)
                {
                    BitmapBuffer.Clear();

                    checkedLayers.Reverse();

                    foreach (var item in checkedLayers)
                        item.Paint();

                    BitmapBuffer.Paint(panelGraphics);
                }
                else
                {
                    BitmapBuffer.Clear();
                    BitmapBuffer.Paint(panelGraphics);
                }

                canChangeLayerOrder = false;
            }
            else
                MessageBox.Show("Невозможное действие");
        }

        private void centralPanel_MouseDown(object sender, MouseEventArgs e)
        {
            centralPanel.Focus();

            if (canCreateFrame == true && canDrawFrame == false)
            {
                currentX = e.X;
                currentY = e.Y;

                canDrawFrame = true;
            }
            else if (canCreateFrame == true && canDrawFrame == true)
            {
                var sp1 = new PointF(currentX, currentY);
                var sp2 = new PointF(e.X, e.Y);

                var gp1 = Map.FromScreenToGeo(sp1);
                var gp2 = Map.FromScreenToGeo(sp2);

                canDrawFrame = false;
            }
                     
            if (canMoveLayer == true)
            {
                centralPanel.Cursor = Cursors.NoMove2D;
                resetLayer.Visible = true;

                leftPanel.Visible = false;

                currentX = e.X;
                currentY = e.Y;               
            }
        }

        private void centralPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (canCreateFrame == true && canDrawFrame == true)
            {
                var sp1 = new PointF(currentX, currentY);
                var sp2 = new PointF(e.X, e.Y);

                var gp1 = Map.FromScreenToGeo(sp1);
                var gp2 = Map.FromScreenToGeo(sp2);

                var mp1 = Map.FromGeoToBitmap(gp1);
                var mp2 = Map.FromGeoToBitmap(gp2);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                float minX = 0;
                float minY = 0;
                float maxX = 0;
                float maxY = 0;

                if (mp2.X > mp1.X && mp2.Y > mp1.Y)
                {
                    BitmapBuffer.Pen.Color = Color.White;
                    BitmapBuffer.Pen.Width = 2;

                    BitmapBuffer.Graphics.DrawRectangle(BitmapBuffer.Pen, mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                    minX = gp1.X;
                    minY = gp1.Y;

                    maxX = gp2.X;
                    maxY = gp2.Y;
                }
                else if (mp2.X < mp1.X && mp2.Y > mp1.Y)
                {
                    BitmapBuffer.Pen.Color = Color.White;
                    BitmapBuffer.Pen.Width = 2;

                    BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp2.X, mp1.Y, mp1.X - mp2.X, mp2.Y - mp1.Y);

                    minX = gp2.X;
                    minY = gp1.Y;

                    maxX = gp1.X;
                    maxY = gp2.Y;
                }
                else if (mp2.X > mp1.X && mp2.Y < mp1.Y)
                {
                    BitmapBuffer.Pen.Color = Color.White;
                    BitmapBuffer.Pen.Width = 2;

                    BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp1.X, mp2.Y, mp2.X - mp1.X, mp1.Y - mp2.Y);

                    minX = gp1.X;
                    minY = gp2.Y;

                    maxX = gp2.X;
                    maxY = gp1.Y;
                }
                else if (mp2.X < mp1.X && mp2.Y < mp1.Y)
                {
                    BitmapBuffer.Pen.Color = Color.White;
                    BitmapBuffer.Pen.Width = 2;

                    BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp2.X, mp2.Y, mp1.X - mp2.X, mp1.Y - mp2.Y);

                    minX = gp2.X;
                    minY = gp2.Y;

                    maxX = gp1.X;
                    maxY = gp1.Y;
                }

                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                textBox2.Text = minX.ToString(format);
                textBox3.Text = minY.ToString(format);

                textBox4.Text = maxX.ToString(format);
                textBox5.Text = maxY.ToString(format);

                BitmapBuffer.Paint(panelGraphics);
            }

            if (canMoveLayer == true)
            {
                if (e.Button != MouseButtons.Left) return;

                BitmapBuffer.X += (e.X - currentX);
                BitmapBuffer.Y += (e.Y - currentY);

                Map.Xc += (float)(e.X - currentX) / Map.Scale;
                Map.Yc += (float)(e.Y - currentY) / Map.Scale;

                currentX = e.X;
                currentY = e.Y;

                BitmapBuffer.Refresh(panelGraphics);
            }

        }

        private void centralPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (canMoveLayer == true)
            {
                centralPanel.Cursor = Cursors.Default;

                leftPanel.Visible = true;
            }
        }

        private void centralPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Map.Scale != Map.StartScale)
                resetLayer.Visible = true;
            else
                resetLayer.Visible = false;

            BitmapBuffer.SetXoYo();

            var checkedLayers = new List<Layer>();

            foreach (var item in layers)
                if (item.Checked == true)
                    checkedLayers.Add(item);

            if (e.Delta > 0)
                Map.Scale *= 1.25f;
            else if (e.Delta < 0)
                Map.Scale /= 1.25f;

            BitmapBuffer.Clear();

            checkedLayers.Reverse();

            foreach (var item in checkedLayers)
                item.Paint();

            BitmapBuffer.Paint(panelGraphics);
        }

        private void centralPanel_Paint(object sender, PaintEventArgs e)
        {
            BitmapBuffer.Refresh(panelGraphics);
        }

        private void centralPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            centralPanel.Focus();

            if (layersList.Text.Contains(".grid"))
            {
                if (layers.Count > 0)
                {
                    var checkedLayers = new List<Layer>();

                    foreach (var item in layers)
                        if (item.Checked == true)
                            checkedLayers.Add(item);

                    if (checkedLayers.Count != 0)
                    {
                        var sp = new PointF(e.X, e.Y);
                        var gp = Map.FromScreenToGeo(sp);
                        var mp = Map.FromGeoToBitmap(gp);

                        BitmapBuffer.Clear();

                        checkedLayers.Reverse();

                        foreach (var item in checkedLayers)
                            item.Paint();

                        BitmapBuffer.Brush.Color = Color.White;
                        BitmapBuffer.Graphics.FillEllipse(BitmapBuffer.Brush, mp.X - 5, mp.Y - 5, 10, 10);

                        BitmapBuffer.Brush.Color = Color.Gray;
                        BitmapBuffer.Graphics.FillEllipse(BitmapBuffer.Brush, mp.X - 3, mp.Y - 3, 6, 6);

                        BitmapBuffer.Paint(panelGraphics);

                        var format = new NumberFormatInfo();
                        format.NumberDecimalSeparator = ".";

                        infoPanel.Visible = true;

                        label12.Text = string.Format("Значение геополя в точке ({0}, {1})", gp.X.ToString(format), gp.Y.ToString(format));
                        textBox10.Text = "";

                        foreach (GridLayer layer in checkedLayers.Where(t => t.Type == LayerType.Grid).Reverse())
                        {
                            var z = layer.GetValueInGeofieldPoint(gp);

                            if (z != null)
                                textBox10.Text += string.Format("Слой [{0}]:\t{1}\r\n", layer.Name, ((float)z).ToString(format));
                        }
                    }
                }
            }
        }

        private void layersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (layersList.SelectedIndex != -1 && canChangeLayerOrder == false)
            {
                if (layersList.Text.Contains(".points"))
                {
                    infoPanel.Visible = false;

                    createGrid.Text = "Построить регулярную сеть";

                    minColor.BackColor = Color.Blue;
                    maxColor.BackColor = Color.Red;

                    drawFrame.Visible = true;

                    label1.Visible = true;

                    textBox1.Text = "1000";
                    textBox1.Visible = true;

                    label2.Visible = true;
                    textBox2.Visible = true;

                    label3.Visible = true;
                    textBox3.Visible = true;

                    label4.Visible = true;
                    textBox4.Visible = true;

                    label5.Visible = true;
                    textBox5.Visible = true;

                    label6.Visible = true;
                    textBox6.Text = "10";
                    textBox6.Visible = true;

                    label7.Visible = true;
                    textBox7.Text = "3";
                    textBox7.Visible = true;

                    label8.Visible = true;
                    textBox8.Visible = true;

                    label9.Visible = true;
                    textBox9.Visible = true;
                }
                else
                {
                    var temp = layers[layersList.SelectedIndex] as GridLayer;

                    createGrid.Text = "Изменить регулярную сеть";

                    minColor.BackColor = temp.MinColor;
                    maxColor.BackColor = temp.MaxColor;

                    drawFrame.Visible = false;

                    label1.Visible = false;
                    textBox1.Visible = false;

                    label2.Visible = false;
                    textBox2.Visible = false;

                    label3.Visible = false;
                    textBox3.Visible = false;

                    label4.Visible = false;
                    textBox4.Visible = false;

                    label5.Visible = false;
                    textBox5.Visible = false;

                    label6.Visible = false;
                    textBox6.Visible = false;

                    label7.Visible = false;
                    textBox7.Visible = false;

                    label8.Visible = false;
                    textBox8.Visible = false;

                    label9.Visible = false;
                    textBox9.Visible = false;
                }
            }
        }

        private void layersList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (layers.Count > 0)
            {
                if (e.CurrentValue == CheckState.Unchecked)
                {
                    e.NewValue = CheckState.Checked;
                    layers[e.Index].Checked = true;
                }
                else if (e.CurrentValue == CheckState.Checked)
                {
                    e.NewValue = CheckState.Unchecked;
                    layers[e.Index].Checked = false;
                }

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                if (checkedLayers.Count != 0)
                {
                    BitmapBuffer.Clear();

                    checkedLayers.Reverse();

                    foreach (var item in checkedLayers)
                        item.Paint();

                    BitmapBuffer.Paint(panelGraphics);
                }
                else
                {
                    BitmapBuffer.Clear();
                    BitmapBuffer.Paint(panelGraphics);
                }
            }
        }

        private void createGrid_Click(object sender, EventArgs e)
        {
            if (drawFrame.Text == "Готово")
            {
                MessageBox.Show("Завершите предыдущее действие");

                return;
            }

            if (createGrid.Text == "Построить регулярную сеть")
            {
                try
                {
                    var format = new NumberFormatInfo();
                    format.NumberDecimalSeparator = ".";

                    var d = float.Parse(textBox1.Text, format);

                    var xo = float.Parse(textBox2.Text, format);
                    var yo = float.Parse(textBox3.Text, format);
                    var xn = float.Parse(textBox4.Text, format);
                    var yn = float.Parse(textBox5.Text, format);

                    var n = int.Parse(textBox6.Text, format);
                    var p = int.Parse(textBox7.Text, format);

                    var sx = int.Parse(textBox8.Text, format);
                    var sy = int.Parse(textBox9.Text, format);

                    var geometry = new GridGeometry(d, xo, yo, xn, yn, sx, sy);
                    var temp = layers[layersList.SelectedIndex] as VectorLayer;

                    var layer = new GridLayer(geometry);
                    layer.RestoreGeofield(temp.Points, minColor.BackColor, maxColor.BackColor, n, p);

                    layer.Name = "Новый слой.grid";

                    if (layers.Count > 0)
                    {
                        var numbers = new List<int>();

                        var dot = layer.Name.LastIndexOf('.');
                        var tmp = layer.Name.Substring(0, dot);

                        int count = 0;

                        for (int i = 0; i < layers.Count; i++)
                        {
                            if (layers[i].Name.Contains(tmp))
                            {
                                count++;

                                var ri = layers[i].Name.LastIndexOf(')');
                                var li = layers[i].Name.LastIndexOf('(');
                                var pi = layers[i].Name.LastIndexOf('.');

                                if (li != -1 && ri != -1 && ri + 1 == pi)
                                {
                                    var pos = layers[i].Name.Substring(li + 1, ri - li - 1);

                                    int number = -1;

                                    if (int.TryParse(pos, out number))
                                        numbers.Add(number);
                                }
                            }
                        }

                        if (numbers.Count > 0 && count > 0)
                        {
                            int counter = 2;

                            while (numbers.Contains(counter))
                                counter++;

                            if (count == numbers.Count)
                                layer.Name = layer.Name.Insert(dot, "");
                            else
                                layer.Name = layer.Name.Insert(dot, string.Format("({0})", counter));
                        }
                        else if (numbers.Count == 0 && count > 0)
                            layer.Name = layer.Name.Insert(dot, "(2)");
                    }

                    layer.Checked = true;
                    layer.Type = LayerType.Grid;

                    layers.Add(layer);
                    layersList.Items.Add(layer.Name, CheckState.Checked);
                }
                catch
                {
                    MessageBox.Show("Не удалось выполнить действие");
                }
            }
            else
            {
                var temp = layers[layersList.SelectedIndex] as GridLayer;

                temp.MinColor = minColor.BackColor;
                temp.MaxColor = maxColor.BackColor;
                temp.CanRedraw = true;

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Paint(panelGraphics);
            }
        }

        private void minColor_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                minColor.BackColor = colorDialog1.Color;
        }

        private void maxColor_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                maxColor.BackColor = colorDialog1.Color;
        }

        private void drawFrame_Click(object sender, EventArgs e)
        {
            btnFocus.Focus();

            if (drawFrame.Text == "Выбрать область")
            {
                drawFrame.Text = "Готово";
                canCreateFrame = true;
                drawFrame.BackColor = Color.LightGreen;

                leftPanel.Visible = false;
            }
            else
            {
                drawFrame.Text = "Выбрать область";
                canCreateFrame = false;
                drawFrame.BackColor = Color.WhiteSmoke;

                leftPanel.Visible = true;

                textBox1_Leave(sender, e);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                var d = float.Parse(textBox1.Text, format);

                var xo = float.Parse(textBox2.Text, format);
                var yo = float.Parse(textBox3.Text, format);
                var xn = float.Parse(textBox4.Text, format);
                var yn = float.Parse(textBox5.Text, format);

                var sx = (int)((xn - xo) / d + 1);
                var sy = (int)((yn - yo) / d + 1);

                xn = xo + (sx - 1) * d;
                yn = yo + (sy - 1) * d;

                textBox4.Text = xn.ToString(format);
                textBox5.Text = yn.ToString(format);

                textBox8.Text = sx.ToString(format);
                textBox9.Text = sy.ToString(format);

                var mp1 = Map.FromGeoToBitmap(xo, yo);
                var mp2 = Map.FromGeoToBitmap(xn, yn);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Pen.Color = Color.White;
                BitmapBuffer.Pen.Width = 2;

                BitmapBuffer.Graphics.DrawRectangle(BitmapBuffer.Pen, mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                BitmapBuffer.Paint(panelGraphics);
            }
            catch { }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                var d = float.Parse(textBox1.Text, format);

                var xo = float.Parse(textBox2.Text, format);
                var yo = float.Parse(textBox3.Text, format);
                var xn = float.Parse(textBox4.Text, format);
                var yn = float.Parse(textBox5.Text, format);

                var sx = int.Parse(textBox8.Text, format);
                var sy = int.Parse(textBox9.Text, format);

                d = (xn - xo) / (sx - 1);
                yn = yo + (sy - 1) * d;

                textBox1.Text = d.ToString(format);
                textBox5.Text = yn.ToString(format);

                var mp1 = Map.FromGeoToBitmap(xo, yo);
                var mp2 = Map.FromGeoToBitmap(xn, yn);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Pen.Color = Color.White;
                BitmapBuffer.Pen.Width = 2;

                BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                BitmapBuffer.Paint(panelGraphics);
            }
            catch { }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                var d = float.Parse(textBox1.Text, format);

                var xo = float.Parse(textBox2.Text, format);
                var yo = float.Parse(textBox3.Text, format);
                var xn = float.Parse(textBox4.Text, format);
                var yn = float.Parse(textBox5.Text, format);

                var sx = int.Parse(textBox8.Text, format);
                var sy = int.Parse(textBox9.Text, format);

                d = (yn - yo) / (sy - 1);
                xn = xo + (sx - 1) * d;

                textBox1.Text = d.ToString(format);
                textBox4.Text = xn.ToString(format);

                var mp1 = Map.FromGeoToBitmap(xo, yo);
                var mp2 = Map.FromGeoToBitmap(xn, yn);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Pen.Color = Color.White;
                BitmapBuffer.Pen.Width = 2;

                BitmapBuffer.Graphics.DrawRectangle(BitmapBuffer.Pen, mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                BitmapBuffer.Paint(panelGraphics);
            }
            catch { }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            try
            {
                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                var d = float.Parse(textBox1.Text, format);

                var xo = float.Parse(textBox2.Text, format);
                var yo = float.Parse(textBox3.Text, format);
                var xn = float.Parse(textBox4.Text, format);
                var yn = float.Parse(textBox5.Text, format);

                var sx = int.Parse(textBox8.Text, format);
                var sy = int.Parse(textBox9.Text, format);

                d = (xn - xo) / (sx - 1);
                yn = yo + (sy - 1) * d;

                textBox1.Text = d.ToString(format);
                textBox5.Text = yn.ToString(format);

                var mp1 = Map.FromGeoToBitmap(xo, yo);
                var mp2 = Map.FromGeoToBitmap(xn, yn);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Pen.Color = Color.White;
                BitmapBuffer.Pen.Width = 2;

                BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                BitmapBuffer.Paint(panelGraphics);
            }
            catch { }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                var d = float.Parse(textBox1.Text, format);

                var xo = float.Parse(textBox2.Text, format);
                var yo = float.Parse(textBox3.Text, format);
                var xn = float.Parse(textBox4.Text, format);
                var yn = float.Parse(textBox5.Text, format);

                var sx = int.Parse(textBox8.Text, format);
                var sy = int.Parse(textBox9.Text, format);

                d = (yn - yo) / (sy - 1);
                xn = xo + (sx - 1) * d;

                textBox1.Text = d.ToString(format);
                textBox4.Text = xn.ToString(format);

                var mp1 = Map.FromGeoToBitmap(xo, yo);
                var mp2 = Map.FromGeoToBitmap(xn, yn);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Pen.Color = Color.White;
                BitmapBuffer.Pen.Width = 2;

                BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                BitmapBuffer.Paint(panelGraphics);
            }
            catch { }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            try
            {
                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                var d = float.Parse(textBox1.Text, format);

                var xo = float.Parse(textBox2.Text, format);
                var yo = float.Parse(textBox3.Text, format);
                var xn = float.Parse(textBox4.Text, format);
                var yn = float.Parse(textBox5.Text, format);

                var sx = int.Parse(textBox8.Text, format);

                xn = xo + (sx - 1) * d;

                textBox4.Text = xn.ToString(format);

                var mp1 = Map.FromGeoToBitmap(xo, yo);
                var mp2 = Map.FromGeoToBitmap(xn, yn);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Pen.Color = Color.White;
                BitmapBuffer.Pen.Width = 2;

                BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                BitmapBuffer.Paint(panelGraphics);
            }
            catch { }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            try
            {
                var format = new NumberFormatInfo();
                format.NumberDecimalSeparator = ".";

                var d = float.Parse(textBox1.Text, format);

                var xo = float.Parse(textBox2.Text, format);
                var yo = float.Parse(textBox3.Text, format);
                var xn = float.Parse(textBox4.Text, format);
                var yn = float.Parse(textBox5.Text, format);

                var sy = int.Parse(textBox9.Text, format);

                yn = yo + (sy - 1) * d;

                textBox5.Text = yn.ToString(format);

                var mp1 = Map.FromGeoToBitmap(xo, yo);
                var mp2 = Map.FromGeoToBitmap(xn, yn);

                var checkedLayers = new List<Layer>();

                foreach (var item in layers)
                    if (item.Checked == true)
                        checkedLayers.Add(item);

                BitmapBuffer.Clear();

                checkedLayers.Reverse();

                foreach (var item in checkedLayers)
                    item.Paint();

                BitmapBuffer.Pen.Color = Color.White;
                BitmapBuffer.Pen.Width = 2;

                BitmapBuffer.Graphics.DrawRectangle(new Pen(Color.White, 2), mp1.X, mp1.Y, mp2.X - mp1.X, mp2.Y - mp1.Y);

                BitmapBuffer.Paint(panelGraphics);
            }
            catch { }
        }

        private void closeInfoPanel_Click(object sender, EventArgs e)
        {
            infoPanel.Visible = false;

            var checkedLayers = new List<Layer>();

            foreach (var item in layers)
                if (item.Checked == true)
                    checkedLayers.Add(item);

            BitmapBuffer.Clear();

            checkedLayers.Reverse();

            foreach (var item in checkedLayers)
                item.Paint();

            BitmapBuffer.Paint(panelGraphics);
        }
    }
}
