using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColourSorter {
    public partial class displayForm : Form {
        public Generator img;
        public displayForm() {
            InitializeComponent();
        }

        private void displayForm_Load(object sender, EventArgs e) {
            PictureBox pic = new PictureBox();
            Bitmap bmp = img.getBitmap(img.Pixels);
            pic.Width = this.Width;
            pic.Height = this.Height;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pic);


            img.scramble(1);
            Sorter sorter = new Sorter(img, pic);
            Thread t = new Thread(new ThreadStart(sorter.bubbleSort));
            t.Start();
        }
    }
}
