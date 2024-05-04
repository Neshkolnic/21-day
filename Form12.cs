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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                int decimalNumber = int.Parse(textBox1.Text);

                // Перевод в двоичную систему счисления
                textBox2.Text = Convert.ToString(decimalNumber, 2);

                // Перевод в восьмеричную систему счисления
                textBox3.Text = Convert.ToString(decimalNumber, 8);

                // Перевод в шестнадцатеричную систему счисления
                textBox4.Text = Convert.ToString(decimalNumber, 16).ToUpper();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformOperation("+");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PerformOperation("*");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PerformOperation("*");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PerformOperation("-");
        }
        private void PerformOperation(string operation)
        {
            if (!string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                int operand1 = int.Parse(textBox5.Text);
                int operand2 = int.Parse(textBox6.Text);

                int result = 0;
                switch (operation)
                {
                    case "+":
                        result = operand1 + operand2;
                        break;
                    case "-":
                        result = operand1 - operand2;
                        break;
                    case "*":
                        result = operand1 * operand2;
                        break;
                    case "/":
                        if (operand2 != 0)
                            result = operand1 / operand2;
                        else
                            MessageBox.Show("Деление на ноль невозможно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                textBox7.Text = result.ToString();
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
