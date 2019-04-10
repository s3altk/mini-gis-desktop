using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGIS.Models
{
    public enum LayerType { Grid, Vector }

    public abstract class Layer
    {
        public string Name { get; set; }
        public bool Checked { get; set; }
        public LayerType Type { get; set; }

        public abstract void Save(string path);
        public abstract void Paint();
    }
}
