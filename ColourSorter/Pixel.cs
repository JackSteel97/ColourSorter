using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourSorter {
    public class Pixel {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Colour {get;set;}
        public float Hue { get { return Colour.GetHue(); } }

        public Pixel(int x, int y, Color colour) {
            X = x;
            Y = y;
            Colour = colour;
        }

        
    }
}
