using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColourSorter {
    public class Generator {
        private List<Pixel> pixels;
        private int Width;
        private int Height;
        public List<Pixel> Pixels {
            get { return pixels; }
            set { this.pixels = value; }
        }

        public Generator(int width, int height) {
            Width = width;
            Height = height;
            int totalNum = width * height;
            pixels = new List<Pixel>(totalNum);
            for(int y = 0; y < height; y++) {
                HsvToRgb(y % 360, 1, 1, out int r, out int g, out int b);
                Color colour = Color.FromArgb(r, g, b);                
                for(int x = 0; x < width; x++) {
                    pixels.Add(new Pixel(x, y, colour));
                }
            }
        }

        public Bitmap getBitmap(List<Pixel> pxls) {
            Bitmap bmp = new Bitmap(Width, Height);
            foreach(Pixel pixel in pxls) {
                bmp.SetPixel(pixel.X, pixel.Y, pixel.Colour);
            }
            return bmp;
        }

        public void scramble(int runs) {
            Random r = new Random();
            for (int i = 0; i < runs;i++) {
                for(int j = 0; j<pixels.Count; j++) {
                    int index = r.Next(pixels.Count - 1);
                    //swap
                    swap(j, index,pixels);                                      
                }
            }
        }

        public void swap(int index1, int index2, List<Pixel> pxls) {
            int tempX = pxls[index1].X;
            int tempY = pxls[index1].Y;
            pxls[index1].X = pxls[index2].X;
            pxls[index1].Y = pxls[index2].Y;
            pxls[index2].X = tempX;
            pxls[index2].Y = tempY;
            Pixel temp = pxls[index1];
            pxls[index1] = pxls[index2];
            pxls[index2] = temp;
        }


        //convertor from: https://stackoverflow.com/questions/1335426/is-there-a-built-in-c-net-system-api-for-hsv-to-rgb
        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b) {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0) { R = G = B = 0; } else if (S <= 0) {
                R = G = B = V;
            } else {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i) {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        int Clamp(int i) {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }
}
