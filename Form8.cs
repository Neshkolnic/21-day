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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            InitializeBall();
            InitializeTimer();
        }
        private Timer timer;
        private int ballSize = 20; // Размер шарика
        private int ballSpeed = 5; // Скорость движения шарика
        private int ballX, ballY; // Текущие координаты шарика
        private int ballDirectionX = 1; // Направление движения шарика по оси X
        private int ballDirectionY = 1; // Направление движения шарика по оси Y

        private void Form8_Load(object sender, EventArgs e)
        {

        }
        private void InitializeBall()
        {
            ballX = (pictureBox1.Width - ballSize) / 2; // Начальные координаты X шарика
            ballY = (pictureBox1.Height - ballSize) / 2; // Начальные координаты Y шарика
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 50; // Интервал таймера в миллисекундах
            timer.Tick += Timer_Tick;
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           
            {
                // Рисуем шарик
                e.Graphics.FillEllipse(Brushes.Red, ballX, ballY, ballSize, ballSize);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновляем координаты шарика
            ballX += ballSpeed * ballDirectionX;
            ballY += ballSpeed * ballDirectionY;

            // Проверяем, достиг ли шарик границы по оси X
            if (ballX <= 0 || ballX + ballSize >= pictureBox1.Width)
            {
                ballDirectionX *= -1; // Изменяем направление движения
            }

            // Проверяем, достиг ли шарик границы по оси Y
            if (ballY <= 0 || ballY + ballSize >= pictureBox1.Height)
            {
                ballDirectionY *= -1; // Изменяем направление движения
            }

            // Перерисовываем PictureBox
            pictureBox1.Invalidate();
        }
    }
}
