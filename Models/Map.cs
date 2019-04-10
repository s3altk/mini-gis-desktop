using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace miniGIS.Models
{
    public class Map
    {
        public static float Scale { get; set; }
        public static float Xc { get; set; }
        public static float Yc { get; set; }

        public static float StartScale { get; private set; }  
        public static float Xco { get; private set; }
        public static float Yco { get; private set; }

        public static void SetStartScale()
        {
            Scale = StartScale;
        }

        public static void SetMapCenter()
        {
            Xc = Xco;
            Yc = Yco;
        }

        public static PointF FromGeoToBitmap(float x, float y)
        {
            var bp = new PointF();

            bp.X = (float)(BitmapBuffer.Width / 2 + (x + Xc) * Scale);
            bp.Y = (float)(BitmapBuffer.Height / 2 + (y + Yc) * Scale);

            return bp;
        }

        public static PointF FromGeoToBitmap(PointF p)
        {
            var bp = new PointF();

            bp.X = (float)(BitmapBuffer.Width / 2 + (p.X + Xc) * Scale);
            bp.Y = (float)(BitmapBuffer.Height / 2 + (p.Y + Yc) * Scale);

            return bp;
        }

        public static PointF FromScreenToGeo(float x, float y)
        {
            var gp = new PointF();

            gp.X = (float)(((x - BitmapBuffer.Xpc) / Scale) - Xc);
            gp.Y = (float)(((y - BitmapBuffer.Ypc) / Scale) - Yc);

            return gp;
        }

        public static PointF FromScreenToGeo(PointF p)
        {
            var gp = new PointF();

            gp.X = (float)(((p.X - BitmapBuffer.Xpc) / Scale) - Xc);
            gp.Y = (float)(((p.Y - BitmapBuffer.Ypc) / Scale) - Yc);

            return gp;
        }

        public static void SetMapScale(GridGeometry geometry)
        {
            var dx = geometry.Xn - geometry.Xo;
            var dy = geometry.Yn - geometry.Yo;

            var centerX = dx / 2 + geometry.Xo;
            var centerY = dy / 2 + geometry.Yo;

            Xco = -centerX;
            Yco = -centerY;

            Xc = Xco;
            Yc = Yco;

            var sx = (float)(BitmapBuffer.Width / 5) / dx;
            var sy = (float)(BitmapBuffer.Height / 5) / dy;

            StartScale = sx > sy ? sx : sy;
            Scale = StartScale;
        }

        public static void SetMapScale(float xo, float yo, float xn, float yn)
        {
            var dx = xn - xo;
            var dy = yn - yo;

            var centerX = dx / 2 + xo;
            var centerY = dy / 2 + yo;

            Xco = -centerX;
            Yco = -centerY;

            Xc = Xco;
            Yc = Yco;

            var sx = (float)(BitmapBuffer.Width / 5) / dx;
            var sy = (float)(BitmapBuffer.Height / 5) / dy;

            StartScale = sx > sy ? sx : sy;
            Scale = StartScale;
        }
    }
}
