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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            InitializeClock();
        }
        private Timer timer;
        private void InitializeClock()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            // Получаем угол поворота для каждой стрелки
            float secondAngle = (float)currentTime.Second / 60 * 360;
            float minuteAngle = (float)currentTime.Minute / 60 * 360 + (float)currentTime.Second / 60 * 6;
            float hourAngle = (float)currentTime.Hour / 12 * 360 + (float)currentTime.Minute / 60 * 30;

            // Очищаем PictureBox
            pictureBox2.Refresh();

            // Рисуем стрелки
            DrawHand(pictureBox2, Pens.Red, secondAngle, 100, 1);
            DrawHand(pictureBox2, Pens.Blue, minuteAngle, 80, 2);
            DrawHand(pictureBox2, Pens.Black, hourAngle, 60, 4);
        }

        private void DrawHand(PictureBox pictureBox, Pen pen, float angle, int length, int width)
        {
            using (Graphics g = pictureBox.CreateGraphics())
            {
                g.TranslateTransform(pictureBox.Width / 2, pictureBox.Height / 2); // Перемещаем начало координат в центр PictureBox
                g.RotateTransform(angle); // Поворачиваем на нужный угол
                g.DrawLine(pen, 0, 0, 0, -length); // Рисуем стрелку
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            DrawGraph();
        }
        private void DrawGraph()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Определение границ рисунка
                int minX = -10;
                int maxX = 10;
                int minY = -10;
                int maxY = 10;

                // Определение масштаба для осей x и y
                float scaleX = pictureBox1.Width / (maxX - minX);
                float scaleY = pictureBox1.Height / (maxY - minY);

                // Нарисовать оси координат
                g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2); // X
                g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height); // Y

                // Нарисовать график функции y = -2x^2 + 3x
                PointF[] points = new PointF[pictureBox1.Width];
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    float x = (i - pictureBox1.Width / 2) / scaleX;
                    float y = -2 * x * x + 3 * x;
                    int screenX = i;
                    int screenY = (int)(pictureBox1.Height / 2 - y * scaleY);
                    points[i] = new PointF(screenX, screenY);
                }
                g.DrawLines(Pens.Red, points);
            }

            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                button1.Text = "Старт";
            }
            else
            {
                timer.Start();
                button1.Text = "Стоп";
            }
        }
    }
}
