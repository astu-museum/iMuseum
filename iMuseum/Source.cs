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
    public partial class Source : Form
    {

        String sear;

        public Source()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавление нового источника получения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewSource(object sender, EventArgs e)
        {
            AddSource asrc = new AddSource();
            asrc.ShowDialog();
         
            User.sources = new List<Sauce>();
            LoadSources();
        }

        /// <summary>
        /// Изменить источник
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editSource(object sender, EventArgs e)
        {
            try
            {
                int p = dataGridView1.SelectedCells[0].RowIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбрана строка для редактирования");
                return;
            }



            AddSource asrc = new AddSource( User.sources[dataGridView1.SelectedCells[0].RowIndex].getPkSource());
            asrc.ShowDialog();
            LoadSources();
        }

        private void srcSet(object sender, EventArgs e)
        {
            sourceSettings srcs = new sourceSettings();
            srcs.ShowDialog();
            LoadSources();
        }

        /// <summary>
        /// Производит поиск подстроки
        /// </summary>
        void ApplySearch()
        {
            User.sourceSearch(sear);
        }


        /// <summary>
        /// Загрузка Источников получения
        /// </summary>
        private void LoadSources()
        {
            User.load_sources();
            ApplySearch();


            name.DataPropertyName = "name";
            address.DataPropertyName = "address";

            dataGridView1.DataSource = User.sources;
        }

        /// <summary>
        /// Загрузка формы Источники получения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_SourceForm(object sender, EventArgs e)
        {

            sear = "";

            User.sources = new List<Sauce>();

            LoadSources();
        }

        /// <summary>
        /// Удаление источника получения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Source(object sender, EventArgs e)
        {

            if (MessageBox.Show("Удалить источник?", "Удаление источника получения", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

         //   try
          //  {

            try
            {
                int p = dataGridView1.SelectedCells[0].RowIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбрана строка для удаления");
                return;
            }


            try
            {
                User.sources[dataGridView1.SelectedCells[0].RowIndex].delete();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Нельзя удалить Источник,так как существуют Экспонаты,им переданные ");
                return;
            }

            LoadSources();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           sear = textBox1.Text;
           LoadSources();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            sear = "";
            LoadSources();
        }
    }
}
