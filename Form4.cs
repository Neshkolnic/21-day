using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_day
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.Width < 1024 )
             this.Width += 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Width > 10)
                this.Width -= 10;
        }
    }
}
