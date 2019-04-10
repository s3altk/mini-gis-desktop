using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace miniGIS.Models
{
    public class Geopoint
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Geopoint(float x, float y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Geopoint(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Paint()
        {
            var bp = Map.FromGeoToBitmap(X, Y);

            BitmapBuffer.Brush.Color = Color.Black;

            BitmapBuffer.Graphics.FillEllipse(BitmapBuffer.Brush, bp.X - 1, bp.Y - 1, 2, 2); 
        }
    }
}
