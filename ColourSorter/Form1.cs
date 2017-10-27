using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
