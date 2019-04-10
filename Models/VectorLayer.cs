using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;

namespace miniGIS.Models
{
    public class VectorLayer : Layer
    {
        public List<Geopoint> Points { get; set; }

        public VectorLayer()
        {
            Points = new List<Geopoint>();
        }

        public VectorLayer(string path)
        {
            var reader = new StreamReader(path);

            string line;
            var lines = new List<string>();

            while ((line = reader.ReadLine()) != null)
                lines.Add(line);
            reader.Close();

            var format = new NumberFormatInfo();
            format.NumberDecimalSeparator = ".";

            Points = new List<Geopoint>();

            for (int i = 0; i < lines.Count; i++)
            {
                var temp = lines[i].Split('\t');

                var x = float.Parse(temp[0], format);
                var y = float.Parse(temp[1], format);
                var z = float.Parse(temp[2], format);

                var point = new Geopoint(x, -y, z);

                Points.Add(point);
            }
        }

        public override void Save(string path)
        {
            var format = new NumberFormatInfo();
            format.NumberDecimalSeparator = ".";

            var writer = new StreamWriter(path, false);

            foreach (var point in Points)
                writer.WriteLine(string.Format("{0}\t{1}\t{2}",
                                 point.X.ToString(format), (-point.Y).ToString(format), point.Z.ToString(format)));

            writer.Close();
        }

        public override void Paint()
        {
            foreach (var point in Points)
                point.Paint();     
        }
    }
}
