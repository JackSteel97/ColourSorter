using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColourSorter {
    public class Sorter {
        Generator Gen;
        PictureBox ctx;
        List<Pixel> img;
        public Sorter(Generator gen,PictureBox context) {
            Gen = gen;
            ctx = context;
            img = Gen.Pixels.ToList();
        }

        private delegate void refreshDelegate(Control control);

        public static void refreshThreadSafe(Control control) {
            try {
                if (control.InvokeRequired) {
                    control.Invoke(new refreshDelegate
                    (refreshThreadSafe),
                    new object[] { control });
                } else {
                    control.Refresh();
                }
            }catch(Exception e) {
                return;
            }            
        }


       
        public void bubbleSort() {           
            bool swapped = false;
            int n = img.Count;          
            do {
                swapped = false;
                for (int i = 1; i < n; i++){
                    if (img[i-1].Colour.GetHue() > img[i].Colour.GetHue()) {
                        //swap
                        Gen.swap(i - 1, i,img);
                        swapped = true;
                    }    
                }
                Thread t = new Thread(new ThreadStart(update));
                t.Start();
                n--;                
            } while (swapped);
        }

        private void update() {
            ctx.Image = Gen.getBitmap(img.ToList());
            refreshThreadSafe(ctx);
        }
    }
}
