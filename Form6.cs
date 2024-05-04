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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            DrawSineGraph();
        }
        private void DrawSineGraph()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Определите границы рисунка
                int minX = -20;
                int maxX = 20;
                int minY = -1;
                int maxY = 1;

                // Определите масштаб для осей x и y
                float scaleX = pictureBox1.Width / (maxX - minX);
                float scaleY = pictureBox1.Height / (maxY - minY);

                // Нарисуйте оси координат
                g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2); // X
                g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height); // Y

                // Нарисуйте график функции y = sin(x)
                for (float x = minX; x < maxX; x += 0.01f)
                {
                    float y = (float)Math.Sin(x);
                    int screenX = (int)(pictureBox1.Width / 2 + x * scaleX);
                    int screenY = (int)(pictureBox1.Height / 2 - y * scaleY);
                    bmp.SetPixel(screenX, screenY, Color.Red); // Рисует точку
                }
            }

            pictureBox1.Image = bmp;
        }
    }
}
