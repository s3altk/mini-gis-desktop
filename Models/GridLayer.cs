using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace miniGIS.Models
{
    public class GridLayer : Layer
    {
        public GridGeometry Geometry { get; private set; }
        public float?[,] Nodes { get; set; }

        public Color MinColor { get; set; }
        public Color MaxColor { get; set; }

        private Bitmap gradient;

        private float minValue;
        private float maxValue;

        private bool canRedraw = true;

        public bool CanRedraw
        {
            get { return canRedraw; }
            set { canRedraw = value; }
        }

        public GridLayer(string path)
        {
            var reader = new StreamReader(path);

            string line;
            var lines = new List<string>();

            while ((line = reader.ReadLine()) != null)
                lines.Add(line);

            reader.Close();

            var format = new NumberFormatInfo();
            format.NumberDecimalSeparator = ".";

            var d = float.Parse(lines[0].Split(':')[1], format);
            var xo = float.Parse(lines[1].Split(':')[1], format);
            var yo = float.Parse(lines[3].Split(':')[1], format);
            var sx = int.Parse(lines[5].Split(':')[1], format);
            var sy = int.Parse(lines[6].Split(':')[1], format);

            var xn = xo + (sx - 1) * d;
            var yn = yo + (sy - 1) * d;

            Geometry = new GridGeometry(d, xo, yo, xn, yn, sx, sy);

            Nodes = new float?[Geometry.Sy, Geometry.Sx];

            var rgb = lines[7].Split(':')[1].Split(' ');
            var r = int.Parse(rgb[0]);
            var g = int.Parse(rgb[1]);
            var b = int.Parse(rgb[2]);

            MinColor = Color.FromArgb(r, g, b);

            rgb = lines[8].Split(':')[1].Split(' ');
            r = int.Parse(rgb[0]);
            g = int.Parse(rgb[1]);
            b = int.Parse(rgb[2]);

            MaxColor = Color.FromArgb(r, g, b);

            int k = 10;

            maxValue = 0;
            minValue = 0;

            for (int i = 0; i < Geometry.Sy; i++)
            {
                for (int j = 0; j < Geometry.Sx; j++)
                {
                    float value;

                    if (float.TryParse(lines[k], NumberStyles.Any, format, out value))
                    {
                        Nodes[i, j] = value;

                        if (value < minValue)
                            minValue = value;

                        if (value > maxValue)
                            maxValue = value;
                    }
                    else
                        Nodes[i, j] = null;

                    k++;
                }
            }
        }

        public GridLayer(GridGeometry geometry)
        {
            Geometry = geometry;

            Nodes = new float?[Geometry.Sy, Geometry.Sx];
        }

        public void RestoreGeofield(List<Geopoint> points, Color minColor, Color maxColor, int n, int p)
        {
            MinColor = minColor;
            MaxColor = maxColor;

            var closePoints = new Dictionary<Geopoint, double>();

            for (int i = 0; i < Geometry.Sy; i++)
            {
                for (int j = 0; j < Geometry.Sx; j++)
                {
                    var x = Geometry.Xo + Geometry.D * j;
                    var y = Geometry.Yo + Geometry.D * i;

                    foreach (var point in points)
                    {
                        double sd = Math.Pow(x - point.X, 2) + Math.Pow(y - point.Y, 2);

                        closePoints.Add(point, sd);                            
                    }

                    closePoints = closePoints.OrderBy(t => t.Value).Take(n).ToDictionary(k => k.Key, v => v.Value);

                    float N = 0;
                    float D = 0;

                    foreach (var point in closePoints)
                    {
                        double d = Math.Sqrt(point.Value);

                        if (d.Equals(0))
                        {
                            N = point.Key.Z;
                            D = 1;

                            break;
                        }

                        double s = Math.Pow(d, p);

                        N += (float)(point.Key.Z / s);
                        D += (float)(1 / s);
                    }

                    Nodes[i, j] = (float)(N / D);

                    closePoints.Clear();
                }
            }

            maxValue = 0;
            minValue = 0;

            for (int i = 0; i < Geometry.Sy; i++)
            {
                for (int j = 0; j < Geometry.Sx; j++)
                {
                    if (Nodes[i, j] != null)
                    {
                        if (Nodes[i, j] < minValue)
                            minValue = (float)Nodes[i, j];

                        if (Nodes[i, j] > maxValue)
                            maxValue = (float)Nodes[i, j];
                    }
                }
            }
        }

        public float? GetValueInGeofieldPoint(PointF gp)
        {
            if (gp.X < Geometry.Xo || gp.X > Geometry.Xn || gp.Y < Geometry.Yo || gp.Y > Geometry.Yn)
                return null;
            else
            {
                int y = (int)((gp.Y - Geometry.Yo) / Geometry.D); 
                int x = (int)((gp.X - Geometry.Xo) / Geometry.D);
           
                var z1 = Nodes[y, x];
                var z2 = Nodes[y + 1, x];

                var z3 = Nodes[y, x + 1];
                var z4 = Nodes[y + 1, x + 1];

                var dx = gp.X - (Geometry.Xo + Geometry.D * x);
                var dy = gp.Y - (Geometry.Yo + Geometry.D * y);

                if (z1 != null && z2 != null && z3 != null && z4 != null)
                {
                    var z5 = (dy * (z2 - z1)) / Geometry.D + z1;
                    var z6 = (dy * (z4 - z3)) / Geometry.D + z3;

                    var z = (dx * (z6 - z5)) / Geometry.D + z5;

                    return z;
                }
                else
                    return null;
            }
        }

        public override void Save(string path)
        {
            var format = new NumberFormatInfo();
            format.NumberDecimalSeparator = ".";

            var writer = new StreamWriter(path, false);

            writer.WriteLine(string.Format("D:{0}", Geometry.D.ToString(format)));
            writer.WriteLine(string.Format("Xo:{0}", Geometry.Xo.ToString(format)));
            writer.WriteLine(string.Format("Xn:{0}", Geometry.Xn.ToString(format)));
            writer.WriteLine(string.Format("Yo:{0}", Geometry.Yo.ToString(format)));
            writer.WriteLine(string.Format("Yn:{0}", Geometry.Yn.ToString(format)));
            writer.WriteLine(string.Format("Sx:{0}", Geometry.Sx.ToString(format)));
            writer.WriteLine(string.Format("Sy:{0}", Geometry.Sy.ToString(format)));

            writer.WriteLine("Min color (R G B):" + string.Format("{0} {1} {2}", MinColor.R, MinColor.G, MinColor.B));
            writer.WriteLine("Max color (R G B):" + string.Format("{0} {1} {2}", MaxColor.R, MaxColor.G, MaxColor.B));

            writer.WriteLine("Nodes (Z):");

            for (int i = 0; i < Geometry.Sy; i++)
                for (int j = 0; j < Geometry.Sx; j++)
                {
                    if (Nodes[i, j] == null)
                        writer.WriteLine(string.Format("null"));
                    else
                        writer.WriteLine(string.Format("{0}", ((float)Nodes[i, j]).ToString(format)));
                }

            writer.Close();
        }

        public override void Paint()
        {
            if (gradient == null)
                gradient = new Bitmap(Geometry.Sx, Geometry.Sy);

            if (canRedraw)
            {
                var k1 = maxValue - minValue;

                var kr = (MaxColor.R - MinColor.R) / k1;
                var kg = (MaxColor.G - MinColor.G) / k1;
                var kb = (MaxColor.B - MinColor.B) / k1;

                for (int i = 0; i < Geometry.Sy; i++)
                {
                    for (int j = 0; j < Geometry.Sx; j++)
                    {
                        if (Nodes[i, j] != null)
                        {
                            var k2 = Nodes[i, j] - minValue;

                            var R = (int)(kr * k2 + MinColor.R);
                            var G = (int)(kg * k2 + MinColor.G);
                            var B = (int)(kb * k2 + MinColor.B);

                            gradient.SetPixel(j, i, Color.FromArgb(R, G, B));
                        }
                        else
                        {
                            gradient.SetPixel(j, i, Color.Transparent);
                        }
                    }
                }

                canRedraw = false;
            }

            var leftTop = Map.FromGeoToBitmap(Geometry.Xo, Geometry.Yo);
            var rightTop = Map.FromGeoToBitmap(Geometry.Xn, Geometry.Yo);
            var leftBottom = Map.FromGeoToBitmap(Geometry.Xo, Geometry.Yn);

            //var difX = ((rightTop.X - leftTop.X) / (Geometry.Sx - 1)) / 2;
            //var difY = ((leftBottom.Y - leftTop.Y) / (Geometry.Sy - 1)) / 2;

            //leftTop.X -= difX;
            //leftTop.Y -= difY;

            var size = new Size((int)(rightTop.X - leftTop.X), (int)(leftBottom.Y - leftTop.Y));

            BitmapBuffer.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            BitmapBuffer.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            BitmapBuffer.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            BitmapBuffer.Graphics.DrawImage(gradient, new RectangleF(leftTop, size));
        }
    }
}
