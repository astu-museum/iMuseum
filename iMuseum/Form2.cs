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
    public partial class Form2 : Form
    {

        DataSet1.CATEGORYDataTable catexp;
        DataSet1.CATEGORYDataTable cataut;
        DataSet1.CATEGORYDataTable cataud;

        DataSet1.TYPEEXPONATDataTable texp;

        void LoadSome()
        {

            comboBox1.SelectedIndex=0;
            comboBox5.SelectedIndex=0;
            comboBox7.SelectedIndex = 0;

            DataSet1TableAdapters.SOURCETableAdapter sauceTableAdapter = new DataSet1TableAdapters.SOURCETableAdapter();


          User.dtrip = sauceTableAdapter.GetData();

         

            comboBox8.DataSource = User.dtrip;
            comboBox8.ValueMember = "NAME_";
            comboBox8.BindingContext = this.BindingContext;

            //ЭКСПОНАТОКАТЕГОРИЯ
            DataSet1TableAdapters.CATEGORYTableAdapter cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


            cataut = cta.GetDataAut();



            comboBox2.DataSource = cataut;
            comboBox2.ValueMember = "NAME_";
            comboBox2.BindingContext = this.BindingContext;



            //АВТОРОКАТЕГОРИЯ
            cataut = cta.GetDataAud();



            comboBox4.DataSource = cataut;
            comboBox4.ValueMember = "NAME_";
            comboBox4.BindingContext = this.BindingContext;


            //Целевая адутиоря
            catexp = cta.GetDataExp();



            comboBox3.DataSource = catexp;
            comboBox3.ValueMember = "NAME_";
            comboBox3.BindingContext = this.BindingContext;


            //ТИПЫ

            DataSet1TableAdapters.TYPEEXPONATTableAdapter tta = new DataSet1TableAdapters.TYPEEXPONATTableAdapter();

            texp = tta.GetData();



            comboBox6.DataSource = texp;
            comboBox6.ValueMember = "NAME_";
            comboBox6.BindingContext = this.BindingContext;
        

          

        }

        public Form2()
        {
            InitializeComponent();
            LoadSome();
        }

        private void openImage(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void addSource(object sender, EventArgs e)
        {
            AddSource asrc = new AddSource();
            asrc.ShowDialog();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ПРОВЕРКА ВОХМОЖНОСТИТ ПОЛУЧЕНИЯ ВЕСЕЛОЙ ШТУКОВИНЫ
          //  MessageBox.Show(User.dtrip.Rows[comboBox8.SelectedIndex]["pk_source"].ToString());
        }
    }
}
