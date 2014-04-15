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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

        }
    }
}
