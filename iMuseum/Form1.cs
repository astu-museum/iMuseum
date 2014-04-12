using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationControls;

namespace iMuseum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Добавление нового экспоната
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewExp(object sender, EventArgs e)
        {

         

            Form2 f2 = new Form2();
            f2.ShowDialog();


            //Вдруг доабвили что-то подходящее под фильтр?Надо вывести
            Load_Exponats();

        }
        /// <summary>
        /// Подробнее об экспонате
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void infoExp(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void setFilter(object sender, EventArgs e)
        {
            Filter fltr = new Filter();
            fltr.ShowDialog();

            //Вновь пофильтруем
            Load_Exponats();
           

        }

        private void showExib(object sender, EventArgs e)
        {
            Exibition exb = new Exibition();
            exb.ShowDialog();
        }

        private void showSources(object sender, EventArgs e)
        {
            Source src = new Source();
            src.ShowDialog();

            Load_Exponats();
        }

        private void searchSett(object sender, EventArgs e)
        {
            mainSettings mst = new mainSettings();
            mst.ShowDialog();

            Load_Exponats();
        }

        /// <summary>
        /// Производит загружку всех экспонатов и фильтрует по заданному фильтру
        /// </summary>
        private void Load_Exponats()
        {
            User.load_exponats();
            User.filter();

            //ТУТ ДЕЛАЕМ ФИЛЬТРЕЦ

           // dataGridView1.DataSource = null;

            number.DataPropertyName = "inumber";
            title.DataPropertyName = "name";
            source.DataPropertyName = "sourceValue";
            date.DataPropertyName = "date";
            typesob.DataPropertyName = "typeSobStr";
            mesto.DataPropertyName = "placeStr";
            damage.DataPropertyName = "damageStr";
            price.DataPropertyName = "price";



            dataGridView1.DataSource = User.exponats;

         


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            User.typeFilter = new List<int>();
            User.categoryAuthorFilter = new List<int>();
            User.categoryAuditoryFilter = new List<int>();
            User.categoryExponatFilter = new List<int>();
            User.Checks = new List<int>();

            Load_Exponats();

         
          

           
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                int p = dataGridView1.SelectedCells[0].RowIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбрана строка для удаления");
                return;
            }

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            User.exponats[dataGridView1.SelectedCells[0].RowIndex].delete_();

            Load_Exponats();

        }
    }
}
