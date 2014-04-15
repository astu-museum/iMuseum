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
    public partial class sourceSettings : Form
    {
        int a;

        public sourceSettings()
        {
            InitializeComponent();
        }

        public sourceSettings(ref int a1)
        {
            InitializeComponent();
            a = a1;
        }

        /// <summary>
        /// Заблокировать/разблокировать поиск по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lockTitle(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox1.Enabled = true;
            else textBox1.Enabled = false;
        }

        /// <summary>
        /// Заблокировать/разблокировать поиск по месту хранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lock_place(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) comboBox2.Enabled = true;
            else comboBox2.Enabled = false;
        }

        /// <summary>
        /// Заблокировать/разблокировать поиск по состоянию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lockDamage(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) comboBox3.Enabled = true;
            else comboBox3.Enabled = false;
        }

        /// <summary>
        /// Заблокировать/разблокировать поиск по стоимости
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lockPrice(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox8.Enabled = true;
            }
            else
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sourceSettings_Load(object sender, EventArgs e)
        {
            textBox8.Text = (Convert.ToInt32(User.pricefrom)).ToString();
            textBox5.Text = (Convert.ToInt32(User.pricefrom* 100) % 100).ToString();

            textBox6.Text = (Convert.ToInt32(User.priceto)).ToString();
            textBox4.Text = (Convert.ToInt32(User.priceto * 100) % 100).ToString();

            textBox1.Text = User.name0;

            comboBox2.SelectedIndex = User.place0;
            comboBox3.SelectedIndex = User.damage0;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            User.name0 = "";
            User.place0 = -1;
            User.damage0 = -1;
            User.pricefrom = 0.0;
            User.priceto = 0.0;
            

            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;




        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox4.Checked == true)
            {

                if (textBox8.Text == "")
                {

                    MessageBox.Show("Не оставляйте цену пустой");
                    return;

                }

                if (textBox5.Text == "")
                {

                    MessageBox.Show("Не оставляйте цену пустой");
                    return;

                }


                if (textBox6.Text == "")
                {

                    MessageBox.Show("Не оставляйте цену пустой");
                    return;

                }

                if (textBox4.Text == "")
                {

                    MessageBox.Show("Не оставляйте цену пустой");
                    return;

                }

                if (textBox8.TextLength > 8)
                {
                    MessageBox.Show("Дороговато для Краевого музея");
                    return;
                }

                for (int i = 0; i < textBox8.Text.Length; i++)
                {



                    if ((textBox8.Text[i] < '0') || (textBox8.Text[i] > '9'))
                    {
                        MessageBox.Show("Стоимость(руб) только цифры");
                        return;

                    }
                }


                for (int i = 0; i < textBox5.Text.Length; i++)
                {



                    if ((textBox4.Text[i] < '0') || (textBox4.Text[i] > '9'))
                    {
                        MessageBox.Show("Стоимость(коп) только цифры");
                        return;

                    }
                }

                if (textBox5.TextLength > 2)
                {
                    MessageBox.Show("Копеек не больше 99");
                    return;
                }

                if (textBox6.TextLength > 8)
                {
                    MessageBox.Show("Дороговато для Краевого музея");
                    return;
                }

                for (int i = 0; i < textBox6.Text.Length; i++)
                {



                    if ((textBox6.Text[i] < '0') || (textBox6.Text[i] > '9'))
                    {
                        MessageBox.Show("Стоимость(руб) только цифры");
                        return;

                    }
                }


                for (int i = 0; i < textBox4.Text.Length; i++)
                {



                    if ((textBox4.Text[i] < '0') || (textBox4.Text[i] > '9'))
                    {
                        MessageBox.Show("Стоимость(коп) только цифры");
                        return;

                    }
                }

                if (textBox4.TextLength > 2)
                {
                    MessageBox.Show("Копеек не больше 99");
                    return;
                }
            }

            if (checkBox1.Checked == true)
            {
                User.name0 = textBox1.Text;
            }


            if (checkBox2.Checked == true)
            {
                User.place0 = comboBox2.SelectedIndex;
            }

            if (checkBox3.Checked == true)
            {
                User.damage0 = comboBox3.SelectedIndex;
            }

            if (checkBox4.Checked == true)
            {
                User.pricefrom = Convert.ToDouble(textBox8.Text) + (Convert.ToDouble(textBox5.Text)) / 100;
                User.priceto = Convert.ToDouble(textBox6.Text) + (Convert.ToDouble(textBox4.Text)) / 100;
           
                    
            }

            this.Close();

            

        }
    }
}
