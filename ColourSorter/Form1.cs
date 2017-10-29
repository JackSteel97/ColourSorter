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
    public partial class ParentForm : Form {
        public ParentForm() {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e) {
            displayForm display = new displayForm();
            Generator gen = new Generator(Convert.ToInt32(widthNum.Value),Convert.ToInt32(heightNum.Value));
            display.img = gen;
            display.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            fbDialog.ShowDialog();
            if (string.IsNullOrWhiteSpace(fbDialog.SelectedPath)) {
                return;
            }
            Generator gen = new Generator(Convert.ToInt32(widthNum.Value), Convert.ToInt32(heightNum.Value));
            gen.scramble(1);
            Sorter sorter = new Sorter(gen, null,fbDialog.SelectedPath);
            Thread t = new Thread(new ThreadStart(sorter.startQuickSort));
            t.Start();
        }
    }
}
