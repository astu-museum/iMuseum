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
        /// <summary>
        /// Добавление источника
        /// </summary>
        public AddSource()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Редактирование источника
        /// </summary>
        /// <param name="editID">ID</param>
        public AddSource(Int32 editID)
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

            if (textBox3.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            //Проверка поля Наименование источника получения
            for (int i = 0; i < textBox2.Text.Length; i++)
            {

                if (((textBox2.Text[i] < 'а') || (textBox2.Text[i] > 'я')) && ((textBox2.Text[i] < 'А') || (textBox2.Text[i] > 'Я')) && ((textBox2.Text[i] < '0') || (textBox2.Text[i] > '9')) &&
                    (textBox2.Text[i] != ' ') && (textBox2.Text[i] != '-') && (textBox2.Text[i] != '.') && (textBox2.Text[i] != ','))
                {
                    MessageBox.Show("Наименование источника может содержать только русские буквы, цифры и символы: пробел - . ,");
                    return;
                }

                if (textBox2.Text[i] == ' ')
                {
                    cnt++;
                }

                if (textBox2.Text[i] == '.')
                {
                    cnt++;
                }

                if (textBox2.Text[i] == ',')
                {
                    cnt++;
                }

                if (textBox2.Text[i] == '-')
                {
                    cnt++;
                }
                if (cnt1 + cnt >= textBox2.Text.Length || textBox2.Text == "")
                {
                    MessageBox.Show("Введите наименование источника получения");
                    return;
                }

            }

            cnt = 0;
            cnt1 = 0;

            //Проверка поля Адрес
            for (int i = 0; i < textBox3.Text.Length; i++)
            {

                if (((textBox3.Text[i] < 'а') || (textBox3.Text[i] > 'я')) && ((textBox3.Text[i] < 'А') || (textBox3.Text[i] > 'Я')) && ((textBox3.Text[i] < '0') || (textBox3.Text[i] > '9')) &&
                    (textBox3.Text[i] != ' ') && (textBox3.Text[i] != '-') && (textBox3.Text[i] != '.') && (textBox3.Text[i] != ','))
                {
                    MessageBox.Show("Адрес может содержать только русские буквы, цифры и символы: пробел - . ,");
                    return;
                }

                if (textBox3.Text[i] == ' ')
                {
                    cnt++;
                }

                if (textBox3.Text[i] == '.')
                {
                    cnt++;
                }

                if (textBox3.Text[i] == ',')
                {
                    cnt++;
                }

                if (textBox3.Text[i] == '-')
                {
                    cnt++;
                }
                if (cnt1 + cnt >= textBox3.Text.Length || textBox3.Text == "")
                {
                    MessageBox.Show("Введите адрес");
                    return;
                }

            }

            //Здесь вроде как должна быть проверка дублирования, но пока обойдемся


            //Вносим новый источник

            Sauce newSRC = new Sauce();

            newSRC.name = textBox2.Text;
            newSRC.address = textBox3.Text;

            newSRC.save();

            this.Close();
        }
    }
}
