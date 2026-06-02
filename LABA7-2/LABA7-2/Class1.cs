using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA7_2
{
    internal class Shape
    {
        public string Type;
        public Point P1;
        public Point P2;
        public Color PenColor;
        public Color FillColor;
        public int Width;
        public bool Fill;
        public float Angle { get; set; } = 0;
    }
}
