using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nosql
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RNS_message R = new RNS_message();
            R.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RSA_message R = new RSA_message();
            R.ShowDialog();
        }
    }
}
