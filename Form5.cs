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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем строку из TextBox
            string inputString = textBox1.Text;

            // Конвертируем строку в целое число
            try
            {
                int intValue = int.Parse(inputString);
                label2.Text = $"Целое число: {intValue}";
            }
            catch (FormatException)
            {
                label2.Text = "Невозможно конвертировать в целое число";
            }

            // Конвертируем строку в вещественное число
            try
            {
                float floatValue = float.Parse(inputString);
                label2.Text += $"\nВещественное число: {floatValue}";
            }
            catch (FormatException)
            {
                label2.Text += "\nНевозможно конвертировать в вещественное число";
            }
        }
    }
}
