﻿using System;
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

        int exponatId;//Пк для редактирования

        string fir=" ", sec=" ", tyr=" ";//Куски Инвентарника

        DataSet1.CATEGORYDataTable catexp;
        DataSet1.CATEGORYDataTable cataut;
        DataSet1.CATEGORYDataTable cataud;

        DataSet1.TYPEEXPONATDataTable texp;

        //Соханение лей
        string t1, t2, t3, t4,t7,t6;
        int co1, co2, co3, co4,co5,co6,co7,co8;
        DateTime dte;

        void SaveFields()
        {
            t1 = textBox1.Text;
            t2 = textBox2.Text;
            t3 = textBox3.Text; 
            t4 = textBox4.Text;
            t7 = textBox7.Text; 
            t6 = textBox6.Text;
 
            co1 = comboBox1.SelectedIndex;
            co2 = comboBox2.SelectedIndex;
            co3 = comboBox3.SelectedIndex;
            co4 = comboBox4.SelectedIndex;
            co5 = comboBox5.SelectedIndex;
            co7 = comboBox7.SelectedIndex;


            dte = dateTimePicker1.Value;
        }

        //Загузка лей
        void LoadFields()
        {
          

           textBox1.Text=t1;
          textBox2.Text=t2;
           textBox3.Text=t3;
           textBox4.Text=t4;
           textBox7.Text=t7;
             textBox6.Text=t6;

          comboBox1.SelectedIndex=co1;
           comboBox2.SelectedIndex=co2;
            comboBox3.SelectedIndex=co3;
             comboBox4.SelectedIndex = co4;
           comboBox5.SelectedIndex = co5;
           comboBox7.SelectedIndex = co7;


             dateTimePicker1.Value = dte;

        }

        void typS()
        {
            
            co6 = comboBox6.SelectedIndex;
        }
        void typL()
        {
            comboBox6.SelectedIndex = co6;
        }


        void souS()
        {

           // MessageBox.Show(comboBox8.SelectedIndex.ToString());
            co8 = comboBox8.SelectedIndex;
        }
        void souL()
        {
           // MessageBox.Show(co8.ToString());

            if (co8 != -1)
            {
                comboBox8.SelectedIndex = co8;
            }
            else
            {
                comboBox8.SelectedIndex = -1;
            }
        }



        //После добавления нового источника грузим всё заново
        void MiniLoad()
        {

            DataSet1TableAdapters.SOURCETableAdapter sauceTableAdapter = new DataSet1TableAdapters.SOURCETableAdapter();


            User.dtrip = sauceTableAdapter.GetData();



            comboBox8.DataSource = User.dtrip;
            comboBox8.ValueMember = "NAME_";
            comboBox8.BindingContext = this.BindingContext;

        }

        /// <summary>
        /// Загрузка данных из БД
        /// </summary>
        void LoadSome()
        {

            comboBox1.SelectedIndex=0;
            comboBox5.SelectedIndex=0;
            comboBox7.SelectedIndex = 0;

            MiniLoad();

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
            LoadTypes();
        }


        /// <summary>
        /// Загрузка типов в комбобокс
        /// </summary>
        void LoadTypes()
        {
            DataSet1TableAdapters.TYPEEXPONATTableAdapter tta = new DataSet1TableAdapters.TYPEEXPONATTableAdapter();

            texp = tta.GetData();

            comboBox6.DataSource = texp;
            comboBox6.ValueMember = "NAME_";
            comboBox6.BindingContext = this.BindingContext;
        }

        /// <summary>
        /// Добавление Экспоната
        /// </summary>
        public Form2()
        {
            InitializeComponent();
            exponatId = 0;
        }

        /// <summary>
        /// Редактирование Экспоната
        /// </summary>
        /// <param name="ID"></param>
        public Form2(Int32 ID)
        {
            InitializeComponent();
            exponatId = ID;

        }

        private void openImage(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void addSource(object sender, EventArgs e)
        {
            SaveFields();
            typS();

     
            AddSource asrc = new AddSource();
            asrc.ShowDialog();

           
            MiniLoad();


            if (exponatId != 0)
            {
                Edit_Load();
            }

            LoadFields();
            typL();

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



        //    MessageBox.Show(textBox2.Text.GetHashCode().ToString());
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поле Наименование");
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("Заполните поле Инвентарный Номер");
                return;
            }

            if (textBox2.Text.Length > 100)
            {
                MessageBox.Show("Слишком длинный Инвентарный Номер");
                return;

            }

            //Проверка отсутствия всякого мусора в наименовании, инвентарнике,авторе

            int cnt = 0;
            int cnt1 = 0;


            for (int i = 0; i < textBox1.Text.Length; i++)
            {

                if (((textBox1.Text[i] < 'а') || (textBox1.Text[i] > 'я')) && ((textBox1.Text[i] < 'А') || (textBox1.Text[i] > 'Я')) && (textBox1.Text[i] != ' ') && (textBox1.Text[i] != '-') && ((textBox1.Text[i] < '0') || (textBox1.Text[i] > '9')))
                {
                    MessageBox.Show("Наименование содержит только буквы, цифры, тире и пробелы");
                    return;

                }
            }
         
            //Вставить проверку на год?

            for (int i = 0; i < textBox2.Text.Length; i++)
            {


                if ((textBox2.Text[i] < '0') || (textBox2.Text[i] > '9')) {
                    MessageBox.Show("Инвентарный номер содержит только цифры");
                    return;

                }
            }

            for (int i = 0; i < textBox7.Text.Length; i++)
            {

                if (((textBox7.Text[i] < 'а') || (textBox7.Text[i] > 'я')) && ((textBox7.Text[i] < 'А') || (textBox7.Text[i] > 'Я')) && (textBox7.Text[i] != ' ') && (textBox7.Text[i] != '-'))
                {
                    MessageBox.Show("ФИО может содержать только буквы, тире и пробелы");
                    return;

                }

                if (textBox7.Text[i] == ' ')
                {
                    cnt++;
                }

                if (textBox7.Text[i] == '-')
                {
                    cnt1++;
                }

                if ((cnt1 + cnt >= textBox7.Text.Length - 3 )&&(textBox7.Text!=" "))
                {
                    MessageBox.Show("ФИО");
                    return;
                }

            }



            if (textBox3.Text == "")
            {

                MessageBox.Show("Не оставляйте цену пустой");
                return;

            }


            if (textBox4.Text == "")
            {

                MessageBox.Show("Не оставляйте цену пустой");
                return;

            }


            if (textBox3.TextLength > 8)
            {
                MessageBox.Show("Дороговато для Краевого музея");
                return;
            }

            for (int i = 0; i < textBox3.Text.Length; i++)
            {

                

                if ((textBox3.Text[i] < '0') || (textBox3.Text[i] > '9'))
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

        






           //Проверим стоимость

        
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите Категорию Автора");
                return;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите Категорию Экспоната");
                return;
            }


            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите Категорию Целевой Аудитории");
                return;
            }

            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите Тип Экспоната");
                return;
            }

            if (comboBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите Источник получения экспоната");
                return;
            }





            //ПРоверка дублирования Инвентарника

            DataSet1TableAdapters.EXPONATTableAdapter eta = new DataSet1TableAdapters.EXPONATTableAdapter();

            if (exponatId == 0)
            {

                if (eta.DoubleNumberQuery(textBox2.Text).ToString() != "0")
                {
                    MessageBox.Show("Уже есть такой Инвентарный Номер");
                    return;
                }

            }
            else
            {
                if (eta.DoubleInumberEdit(textBox2.Text,User.exponats[0].inumber).ToString() != "0")
                {
                    MessageBox.Show("Уже есть такой Инвентарный Номер");
                    return;
                }


            }
      


            


            //ВНОСИМ НОВЫЙЭКСПОНАТ
            Exponat nExp = new Exponat();
           
            nExp.setPkCategoryExp(Convert.ToInt32(catexp.Rows[comboBox3.SelectedIndex]["pk_category"].ToString()));

           
            nExp.setPkCategoryAut(Convert.ToInt32(cataut.Rows[comboBox2.SelectedIndex]["pk_category"].ToString()));
      
            nExp.setPkCategoryAud(Convert.ToInt32(cataud.Rows[comboBox4.SelectedIndex]["pk_category"].ToString()));

            
            nExp.setPkSource(Convert.ToInt32(User.dtrip.Rows[comboBox8.SelectedIndex]["pk_source"].ToString()));

            
            
            nExp.inumber= textBox2.Text;
            nExp.name = textBox1.Text;
          
            nExp.price = Convert.ToDouble(textBox3.Text)+(Convert.ToDouble(textBox4.Text))/100;
           
            nExp.date = dateTimePicker1.Value;
         
            nExp.setTypeSob(comboBox1.SelectedIndex);


            if (textBox6.Text != "")
            {
                nExp.setDescr(textBox6.Text);
            }
            else
            {
                nExp.setDescr(" ");

            }

    
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

      

        
            if (openFileDialog1.FileName.ToString() == "openFileDialog1")
            {
                nExp.setPic(" ");
            }
            else
            {
                nExp.setPic(openFileDialog1.FileName);
            }
       
            nExp.setPkType(Convert.ToInt32(texp.Rows[comboBox6.SelectedIndex]["pk_type"].ToString()));


            //Изменить или создать
            if(exponatId==0){
             nExp.save();
                
            }
            else{
                nExp.setPkExponat(exponatId);
                nExp.update();
            }

            this.Close();
        }


        //ГЕНЕРАТОРЫ
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet1TableAdapters.EXPONATTableAdapter eta = new DataSet1TableAdapters.EXPONATTableAdapter();


            int p =Convert.ToInt32(eta.CatAutQuery((Convert.ToInt32(cataut.Rows[comboBox2.SelectedIndex]["pk_category"].ToString()))));


            long asdasd = (comboBox2.SelectedIndex + 1) * 100 + p;
            fir = asdasd.ToString();


            textBox2.Text = fir + sec + tyr;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet1TableAdapters.EXPONATTableAdapter eta = new DataSet1TableAdapters.EXPONATTableAdapter();


            int p = Convert.ToInt32(eta.CatExpQuery((Convert.ToInt32(catexp.Rows[comboBox3.SelectedIndex]["pk_category"].ToString()))));


            long asdasd = (comboBox3.SelectedIndex + 1) * 100 + p;
            sec = asdasd.ToString();



            textBox2.Text = fir + sec + tyr;



        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet1TableAdapters.EXPONATTableAdapter eta = new DataSet1TableAdapters.EXPONATTableAdapter();


            int p = Convert.ToInt32(eta.CatAudQuery((Convert.ToInt32(cataud.Rows[comboBox4.SelectedIndex]["pk_category"].ToString()))));


           // long asdasd = comboBox4.SelectedValue.GetHashCode();
           //   if (asdasd < 0) asdasd *= -1;

          //  long asdasd = Convert.ToInt32(cataud.Rows[comboBox4.SelectedIndex]["pk_category"].ToString());
          //  tyr = asdasd.ToString() + (p + 1).ToString();
            //MessageBox.Show(fir);


            long asdasd = (comboBox4.SelectedIndex + 1) * 100 + p;
            tyr = asdasd.ToString();


            textBox2.Text = fir + sec + tyr;


        }

        /// <summary>
        /// Добавить новый тип экспоната
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addType(object sender, EventArgs e)
        {
            
            SaveFields();
            souS();

          
            AddType AType = new AddType();
            AType.ShowDialog();


        
            LoadTypes();


            if (exponatId != 0)
            {
                Edit_Load();
            }
     

            LoadFields();


            souL();

        }

        /// <summary>
        /// Заполнение полей при редактировании
        /// </summary>
        void Edit_Load(){
           
            textBox1.Text = User.exponats[0].name;
            textBox2.Text = User.exponats[0].inumber;
            textBox3.Text = (Convert.ToInt32(User.exponats[0].price)).ToString();
            textBox4.Text = (Convert.ToInt32(User.exponats[0].price * 100) % 100).ToString();


  

            
            comboBox1.SelectedIndex = User.exponats[0].getTypeSob();
            comboBox8.SelectedValue = User.exponats[0].sourceValue;
            dateTimePicker1.Value=User.exponats[0].date;

        

            textBox7.Text = User.exponats[0].getFio();
            comboBox5.SelectedIndex = User.exponats[0].getDamage();
            comboBox7.SelectedIndex=User.exponats[0].getPlace();

            textBox6.Text = User.exponats[0].getDescr();

            openFileDialog1.FileName = User.exponats[0].getPic();

            //МЕСТО ДЛЯ ЗАГРУЗКИ КАТЕГОРИЙ И ТИПА

            DataSet1TableAdapters.CATEGORYTableAdapter loady = new DataSet1TableAdapters.CATEGORYTableAdapter();

            //Категория Экспоната
            DataSet1.CATEGORYDataTable catdt = loady.GetCatExpName(exponatId);

            foreach (DataSet1.CATEGORYRow categ in catdt)
            {
                comboBox3.SelectedValue= categ.NAME_;
            }

            //КАтегория автора
            catdt = loady.GetCatAutName(exponatId);

            foreach (DataSet1.CATEGORYRow categ in catdt)
            {
                comboBox2.SelectedValue = categ.NAME_;
            }

            //Целеад
            catdt = loady.GetCatAudName(exponatId);


            foreach (DataSet1.CATEGORYRow categ in catdt)
            {
                comboBox4.SelectedValue = categ.NAME_;
            }


            //Тип

            DataSet1TableAdapters.TYPEEXPONATTableAdapter typie = new DataSet1TableAdapters.TYPEEXPONATTableAdapter();

            DataSet1.TYPEEXPONATDataTable tdd = typie.GetTypeName(exponatId);

            foreach (DataSet1.TYPEEXPONATRow categ in tdd)
            {
                comboBox6.SelectedValue = categ.NAME_;
            }


            //Проверка нахождения на выставке
            DataSet1TableAdapters.CATEGORYEXPONATTableAdapter ceta = new DataSet1TableAdapters.CATEGORYEXPONATTableAdapter();

          
            if (ceta.onExhibition(exponatId) != 0)
            {
                MessageBox.Show("Экспонат \"" + textBox1.Text + "\" в данное время принадлежит одной или более выставок. Изменение его категорий, целевой аудитории, места хранения и даты получения заблокировано.",
                    "Информация",MessageBoxButtons.OK,MessageBoxIcon.Information);
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                dateTimePicker1.Enabled = false;

                comboBox7.Enabled = false;
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadSome();
            if (exponatId != 0)
            {
                User.load_exponatsp(exponatId);
                Edit_Load();
            }
        }
    }
}
