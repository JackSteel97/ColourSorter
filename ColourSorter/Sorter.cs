using AForge.Video;
using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ColourSorter {
    public class Sorter {
        Generator Gen;
        PictureBox ctx;
        List<Pixel> img;
        string FolderPath;
        int outputFileCount = 0;
        List<Bitmap> imgs;
        public Sorter(Generator gen, PictureBox context, string outputPath = "") {
            Gen = gen;
            ctx = context;
            img = Gen.Pixels.ToList();
            FolderPath = outputPath;
            outputFileCount = 0;
            imgs = new List<Bitmap>(1000);
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
            } catch (Exception e) {
                return;
            }
        }



        public void bubbleSort() {
            outputFileCount = 0;
            startUpdate();
            bool swapped = false;
            int n = img.Count;
            do {
                swapped = false;
                for (int i = 1; i < n; i++) {
                    if (img[i - 1].Hue > img[i].Hue) {
                        //swap
                        Gen.swap(i - 1, i, img);
                        swapped = true;
                    }
                }
                startUpdate();
                n--;

            } while (swapped);
            startUpdate();
        }

        public void insertionSort() {
            outputFileCount = 0;
            int i = 1;
            startUpdate();
            while (i < img.Count) {
                int j = i;
                while (j > 0 && img[j - 1].Hue > img[j].Hue) {
                    Gen.swap(j, j - 1, img);
                    j--;

                }
                i++;
                startUpdate();
            }
            startUpdate();
        }
        public void startQuickSort() {
            quickSort(img, 0, img.Count - 1);
        }
        private void quickSort(List<Pixel> A, int low, int high) {       
            if (low < high) {
                int p = partition(A, low, high);
                quickSort(A, low, p - 1);
                quickSort(A, p + 1, high);
            }
        }

        private int partition(List<Pixel> A, int low, int high) {
            Pixel pivot = A[high];
            int i = low - 1;
            for (int j = low; j < high; j++) {
                if (A[j].Hue < pivot.Hue) {
                    i++;
                    Gen.swap(i, j, A);
                }
            }
            if (A[high].Hue < A[i + 1].Hue) {
                Gen.swap(i + 1, high, A);
            }
            return i + 1;
        }

        private void startUpdate() {
            if (ctx != null) {
                Thread t = new Thread(update);
                t.Start(Gen.getBitmap(img.ToList()));
            } else if (!string.IsNullOrWhiteSpace(FolderPath)) {
                //write file
                Bitmap bmp = Gen.getBitmap(img.ToList());
                bmp.Save(FolderPath + "\\img_" + outputFileCount.ToString() + ".png");
                outputFileCount++;
            }

        }

        private void update(object image) {
            try {
                Bitmap bmp = (Bitmap)image;
                imgs.Add(bmp);
                ctx.Image = bmp;
                refreshThreadSafe(ctx);

            } catch (Exception e) {
                update(image);
            }

        }
    }
}
