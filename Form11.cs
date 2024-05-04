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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private Timer timer;
        private float rotationAngle = 0; // Угол вращения
        private float angularSpeed = 1; // Угловая скорость вращения
        private float angleIncrement = 1; // Увеличение угловой скорости

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 50; // Интервал таймера в миллисекундах
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            rotationAngle += angularSpeed; // Увеличиваем угол вращения
            if (rotationAngle >= 360)
            {
                rotationAngle -= 360; // Обнуляем угол после полного оборота
            }

            // Перерисовываем PictureBox
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Очищаем PictureBox
            e.Graphics.Clear(Color.White);

            // Рассчитываем координаты вершин треугольника
            float centerX = pictureBox1.Width / 2;
            float centerY = pictureBox1.Height / 2;
            float radius = 100; // Радиус описанной окружности
            PointF[] points = new PointF[3];
            for (int i = 0; i < 3; i++)
            {
                float angle = (i * 120 + rotationAngle) * (float)Math.PI / 180; // Угол для текущей вершины
                float x = centerX + radius * (float)Math.Cos(angle);
                float y = centerY + radius * (float)Math.Sin(angle);
                points[i] = new PointF(x, y);
            }

            // Рисуем треугольник
            e.Graphics.DrawPolygon(Pens.Black, points);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            angularSpeed += angleIncrement; // Увеличиваем угловую скорость
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                button2.Text = "Старт";
            }
            else
            {
                timer.Start();
                button2.Text = "Стоп";
            }
        }
    }
}
