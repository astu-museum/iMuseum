using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMuseum
{
    public partial class AddSource : Form
    {
        public AddSource()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавление нового источника получения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Int32 cnt = 0, cnt1 = 0;
            for (int i = 0; i < textBox2.Text.Length; i++)
            {

                if (((textBox2.Text[i] < 'а') || (textBox2.Text[i] > 'я')) && ((textBox2.Text[i] < 'А') || (textBox2.Text[i] > 'Я')) && (textBox2.Text[i] != ' ') && (textBox2.Text[i] != '-'))
                {
                    MessageBox.Show("Наименование источника может содержать только русские буквы и пробелы");
                    return;
                }

                if (textBox2.Text[i] == ' ')
                {
                    cnt++;
                }

                if (textBox2.Text[i] == '-')
                {
                    cnt++;
                }
                if (cnt1 + cnt >= textBox2.Text.Length)
                {
                    MessageBox.Show("Введите наименование источника получения");
                    return;
                }

            }
        }
    }
}
