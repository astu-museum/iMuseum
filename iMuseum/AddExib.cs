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
    public partial class AddExib : Form
    {

        DataSet1.CATEGORYDataTable catexp;
        DataSet1.CATEGORYDataTable cataut;
        DataSet1.CATEGORYDataTable cataud;
        
        DataSet1.TYPEEXPONATDataTable texp;

        List<int> ex;
        List<int> av;
        List<int> ad;
        List<int> ty;

        public AddExib()
        {
            InitializeComponent();
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(2);
        }

        private void forming(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поле Наименование");
                return;
            }

            for (int i = 0; i < textBox1.Text.Length; i++)
            {

                if (((textBox1.Text[i] < 'а') || (textBox1.Text[i] > 'я')) && ((textBox1.Text[i] < 'А') || (textBox1.Text[i] > 'Я')) && (textBox1.Text[i] != ' ') && (textBox1.Text[i] != '-') && ((textBox1.Text[i] < '0') || (textBox1.Text[i] > '9')))
                {
                    MessageBox.Show("Наименование содержит только  буквы,цифры,тире и пробелы");
                    return;

                }
            }


            //ПРоверка дублирования Инвентарника

            DataSet1TableAdapters.EXHIBITIONTableAdapter eta = new DataSet1TableAdapters.EXHIBITIONTableAdapter();
            if (eta.DoubleExhName(textBox1.Text).ToString() != "0")
            {
                MessageBox.Show("Уже есть такая выставка");
                return;
            }



            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Выставка не может кончаться раньше чем началась");
                return;
            }



            //Создадим новую выставку

            Exhibition exh = new Exhibition();
            
            exh.name = textBox1.Text.ToString();
            exh.datestart = dateTimePicker1.Value;
            exh.dateend = dateTimePicker2.Value;

            for (int i = 1; i < checkBoxComboBox1.Items.Count; i++)
            {
                // MessageBox.Show(checkBoxComboBox1.Items[i].ToString());
                if (checkBoxComboBox1.CheckBoxItems[i].Checked)
                {
                   
                    exh.addCategory(ex[i - 1]);
                    exh.addCname(checkBoxComboBox1.Items[i].ToString());
                
                }


            }

            if (exh.getCategories().Count == 0)
            {
                MessageBox.Show("ВЫберите хотя бы одну категорию экспоната");
                return;
            }

            int pp = exh.getCategories().Count;



            for (int i = 1; i < checkBoxComboBox2.Items.Count; i++)
            {

                //  MessageBox.Show(checkBoxComboBox2.Items[i].ToString());
                if (checkBoxComboBox2.CheckBoxItems[i].Checked)
                {
                    exh.addCategory(av[i - 1]);
                    exh.addCname(checkBoxComboBox2.Items[i].ToString());

                }


            }

            if (exh.getCategories().Count == pp)
            {
                MessageBox.Show("ВЫберите хотя бы одну категорию автора");
                return;
            }

            pp = exh.getCategories().Count;



            for (int i = 1; i < checkBoxComboBox3.Items.Count; i++)
            {
                if (checkBoxComboBox3.CheckBoxItems[i].Checked)
                {
                    exh.addCategory(ad[i - 1]);
                    exh.addCname(checkBoxComboBox3.Items[i].ToString());
                }


            }

            if (exh.getCategories().Count == pp)
            {
                MessageBox.Show("ВЫберите хотя бы одну целевую аудиторию");
                return;
            }


            if (exh.getCategories().Count == 0)
            {
                MessageBox.Show("ВЫберите хотя бы одну категорию");
                return;
            }


            //ЗАБАБАХАЕМ ГЕНЕРАЦИЮ
            User.exhibitions.Add(exh);
            User.load_exponats();
            User.filterExh();
            User.generate(Convert.ToInt32(numericUpDown1.Value));

            //ЗАБАБАХ КОНЧИЛСЯ

            AddExpExb aee = new AddExpExb();

          

           if(aee.ShowDialog()==DialogResult.Yes){
                User.exhibitions.Clear();
               this.Close();
           }

            //СДЕЛАТЬ ЗАКРЫТИЕ ЭТОГО ОКНА,ЕСЛИ ТАМ ПРИНЯЛИ ВЫСТАВКУ

            //А НЕЧЕГО ЭТОТ МУСОР ОСТАВЛЯТЬ
           User.exhibitions.Clear();
        }

        void LoadSome()
        {

            User.exhibitions = new List<Exhibition>();

            ex = new List<int>();
            av = new List<int>();
            ad = new List<int>();
            ty = new List<int>();

            //АВТОРОКАТЕГОРИЯ
            DataSet1TableAdapters.CATEGORYTableAdapter cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


            cataut = cta.GetDataAut();


            foreach (DataSet1.CATEGORYRow dr in cataut.Rows)
            {


                checkBoxComboBox2.Items.Add(dr.NAME_);


                int p = Convert.ToInt32(dr.PK_CATEGORY);

                av.Add(p);
            }


            //AUDITROY
            DataSet1TableAdapters.CATEGORYTableAdapter cto = new DataSet1TableAdapters.CATEGORYTableAdapter();


            cataud = cto.GetDataAud();


            foreach (DataSet1.CATEGORYRow dr in cataud.Rows)
            {

                checkBoxComboBox3.Items.Add(dr.NAME_);

                int p = Convert.ToInt32(dr.PK_CATEGORY);

                ad.Add(p);
            }

            //EXPONAT
            DataSet1TableAdapters.CATEGORYTableAdapter cte = new DataSet1TableAdapters.CATEGORYTableAdapter();

            catexp = cte.GetDataExp();

            foreach (DataSet1.CATEGORYRow dr in catexp.Rows)
            {
                checkBoxComboBox1.Items.Add(dr.NAME_);


                int p = Convert.ToInt32(dr.PK_CATEGORY);

                ex.Add(p);
            }


        }

        private void AddExib_Load(object sender, EventArgs e)
        {
            LoadSome();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtp1ch(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
        }
    }
}
