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
    public partial class mainSettings : Form
    {
        public mainSettings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User.name0 = "";
            User.source0 = "";
            User.inumber0 = "";
            User.place0 = -1;
            User.damage0 = -1;
            User.typesob0 = -1;
            User.pricefrom = -1;
            User.priceto = -1;
            User.datestart = User.superdate;
            User.dateend = User.superdate;

          //  MessageBox.Show(User.dateend.ToLongDateString());

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today.Date;
            dateTimePicker2.Value = DateTime.Today.Date;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }

        private void mainSettings_Load(object sender, EventArgs e)
        {

            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;


            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;

            if (User.pricefrom != -1)
            {
                textBox8.Text = (Convert.ToInt32(User.pricefrom)).ToString();
                textBox5.Text = (Convert.ToInt32(User.pricefrom * 100) % 100).ToString();


                textBox6.Text = (Convert.ToInt32(User.priceto)).ToString();
                textBox4.Text = (Convert.ToInt32(User.priceto * 100) % 100).ToString();

                checkBox8.Checked = true;
            }



            if (User.name0 != "")
            {
                textBox1.Text = User.name0;
                checkBox1.Checked = true;
            }

            if (User.source0 != "")
            {
                textBox2.Text = User.source0;
                checkBox2.Checked = true;
            }

            if (User.inumber0 != "")
            {
                textBox3.Text = User.inumber0;
                checkBox3.Checked = true;
            }

            if (User.datestart != User.superdate)
            {
                dateTimePicker1.Value = User.datestart;
                dateTimePicker2.Value = User.dateend;
                checkBox4.Checked = true;
            }


            if (User.typesob0 != -1)
            {
                comboBox1.SelectedIndex = User.typesob0;
                checkBox5.Checked = true;
            }


            if (User.place0 != -1)
            {
                comboBox2.SelectedIndex = User.place0;
                checkBox6.Checked = true;
            }

            if (User.damage0 != -1)
            {
                comboBox3.SelectedIndex = User.damage0;
                checkBox7.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
              
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox1.Enabled = true;
            else textBox1.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) textBox2.Enabled = true;
            else textBox2.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) textBox3.Enabled = true;
            else textBox3.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true) comboBox1.Enabled = true;
            else comboBox1.Enabled = false;

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true) comboBox2.Enabled = true;
            else comboBox2.Enabled = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true) comboBox3.Enabled = true;
            else comboBox3.Enabled = false;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
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
    }
}
