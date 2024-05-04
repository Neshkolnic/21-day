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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            InitializeCircle();
            InitializeTimer();
        }
        private Timer timer;
        private int centerX, centerY; // Координаты центра окружности
        private int radius = 100; // Радиус окружности
        private double angle = 0; // Угол поворота точки
        private double angularSpeed = 0.05; // Угловая скорость движения точки
        private double angleIncrement = 0.05; // Увеличение угловой скорости

        private void InitializeCircle()
        {
            centerX = pictureBox1.Width / 2; // Координата x центра окружности
            centerY = pictureBox1.Height / 2; // Координата y центра окружности
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 50; // Интервал таймера в миллисекундах
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            angle += angularSpeed; // Увеличиваем угол поворота
            if (angle >= 2 * Math.PI)
            {
                angle -= 2 * Math.PI; // Обнуляем угол после полного оборота
            }

            // Вычисляем координаты точки по окружности
            int pointX = (int)(centerX + radius * Math.Cos(angle));
            int pointY = (int)(centerY + radius * Math.Sin(angle));

            // Очищаем PictureBox
            pictureBox1.Refresh();

            // Рисуем окружность
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            }

            // Рисуем точку
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.FillEllipse(Brushes.Red, pointX - 5, pointY - 5, 10, 10);
            }
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

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
