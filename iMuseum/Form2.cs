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

        string fir, sec, tyr;//Куски Инвентарника

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

            //АВТОРОКАТЕГОРИЯ
            DataSet1TableAdapters.CATEGORYTableAdapter cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


            cataut = cta.GetDataAut();



            comboBox2.DataSource = cataut;
            comboBox2.ValueMember = "NAME_";
            comboBox2.BindingContext = this.BindingContext;



            //АУДИОТРЕКАТЕГОРИЯ
            DataSet1TableAdapters.CATEGORYTableAdapter cto = new DataSet1TableAdapters.CATEGORYTableAdapter();
            cataud = cto.GetDataAud();



            comboBox4.DataSource = cataud;
            comboBox4.ValueMember = "NAME_";
            comboBox4.BindingContext = this.BindingContext;


            //Категория Экспоанат
            DataSet1TableAdapters.CATEGORYTableAdapter cte = new DataSet1TableAdapters.CATEGORYTableAdapter();
            catexp = cte.GetDataExp();



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
            //СГЕНЕРИМ ЗДЕСБ ИНВЕНТАРНИК?

            //ПРОВЕРКА ВОХМОЖНОСТИТ ПОЛУЧЕНИЯ ВЕСЕЛОЙ ШТУКОВИНЫ
          //  MessageBox.Show(User.dtrip.Rows[comboBox8.SelectedIndex]["pk_source"].ToString());
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            //ЗДЕСЬ ПРОВЕРКИ,КОТОРЫЕ ВЫХОДЯТ,ЕСЛИ КОСЯК



            //ВНОСИМ НОВЫЙЭКСПОНАТ
            Exponat nExp = new Exponat();
           
            nExp.setPkCategoryExp(Convert.ToInt32(catexp.Rows[comboBox3.SelectedIndex]["pk_category"].ToString()));

           
            nExp.setPkCategoryAut(Convert.ToInt32(cataut.Rows[comboBox2.SelectedIndex]["pk_category"].ToString()));
           // MessageBox.Show(nExp.getPkCategoryAut().ToString());
            nExp.setPkCategoryAud(Convert.ToInt32(cataud.Rows[comboBox4.SelectedIndex]["pk_category"].ToString()));

            
            nExp.setPkSource(Convert.ToInt32(User.dtrip.Rows[comboBox8.SelectedIndex]["pk_source"].ToString()));

            
            
            nExp.inumber= textBox2.Text;
            nExp.name = textBox1.Text;
          
            nExp.price = Convert.ToDouble(textBox3.Text)+(Convert.ToDouble(textBox4.Text))/100;
           
            nExp.date = dateTimePicker1.Value;
         
            nExp.setTypeSob(comboBox1.SelectedIndex);
            
            nExp.setDescr(textBox6.Text);
    
            nExp.setPlace(comboBox7.SelectedIndex);
        
            nExp.setDamage(comboBox5.SelectedIndex);
          
            nExp.setFlag(0);
      
            if (textBox7.Text != "")
            {
                nExp.setFio(textBox7.Text);
            }
            else
            {
                nExp.setFio(" ");
            }

      

            //Вставить нормальное извлечение пути до картинки
            nExp.setPic(" ");
       
            nExp.setPkType(Convert.ToInt32(texp.Rows[comboBox6.SelectedIndex]["pk_type"].ToString()));

            nExp.save();

            this.Close();
        }
    }
}
