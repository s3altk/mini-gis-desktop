using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGIS.Models
{
    public class BitmapBuffer
    {
        private static int width = 2048;

        public static int Width
        {
            get { return width; }
            set { width = value; }
        }

        private static int height = 1536;

        public static int Height
        {
            get { return height; }
            set { height = value; }
        }

        public static float X { get; set; }
        public static float Y { get; set; }

        public static float Xo { get; private set; }
        public static float Yo { get; private set; }

        public static float Xpc { get; set; }
        public static float Ypc { get; set; }

        private static Bitmap bitmap = new Bitmap(width, height);

        public static Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }

        private static Graphics graphics = Graphics.FromImage(bitmap);

        public static Graphics Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }

        private static SolidBrush brush = new SolidBrush(Color.Black);

        public static SolidBrush Brush
        {
            get { return brush; }
            set { brush = value; }
        }

        private static Pen pen = new Pen(Color.Black);

        public static Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }

        public static void Clear()
        {
            brush.Color = Color.LightGray;

            graphics.FillRectangle(brush, 0, 0, width, height);
        }

        public static void Paint(Graphics g)
        {
            g.DrawImage(bitmap, Xo, Yo);
        }

        public static void Refresh(Graphics g)
        {
            g.DrawImage(bitmap, X, Y);
        }

        public static void SetSize(Size s)
        {
            width = s.Width;
            height = s.Height;
        }

        public static void SetSize(int w, int h)
        {
            width = w;
            height = h;
        }

        public static void SetXY(Size s)
        {
            Xpc = s.Width / 2;
            Ypc = s.Height / 2;

            X = Xpc - Width / 2;
            Y = Ypc - Height / 2;

            Xo = X;
            Yo = Y;
        }

        public static void SetXY(int w, int h)
        {
            Xpc = w / 2;
            Ypc = h / 2;

            X = Xpc - Width / 2;
            Y = Ypc - Height / 2;

            Xo = X;
            Yo = Y;
        }

        public static void SetXoYo()
        {
            X = Xo;
            Y = Yo;
        }
    }
}
