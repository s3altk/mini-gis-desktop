using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGIS.Models
{
    public class GridGeometry
    {
        public float D { get; private set; }

        public float Xo { get; private set; }
        public float Yo { get; private set; }

        public float Xn { get; private set; }
        public float Yn { get; private set; }

        public int Sx { get; private set; }
        public int Sy { get; private set; }

        public GridGeometry(float d, float xo, float yo, float xn, float yn, int sx, int sy)
        {
            D = d;

            Xo = xo;
            Yo = yo;

            Xn = xn;
            Yn = yn;

            Sx = sx;
            Sy = sy;
        }
    }
}
