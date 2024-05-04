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
    public partial class Form10 : Form
    {
        private bool isDrawing = false; // Флаг, указывающий, идет ли в данный момент рисование
        private Point previousPoint; // Предыдущая точка рисования
        private Color currentColor = Color.Black; // Текущий выбранный цвет рисования
        public Form10()
        {
            InitializeComponent();
        }







        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    Pen pen = new Pen(currentColor, 2); // Создаем перо с текущим выбранным цветом
                    g.DrawLine(pen, previousPoint, e.Location); // Рисуем линию между предыдущей и текущей точками
                    previousPoint = e.Location; // Обновляем предыдущую точку
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color; // Обновляем текущий цвет рисования
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                previousPoint = e.Location;
            }
        }
    }
}
