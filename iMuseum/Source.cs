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

                MessageBox.Show("Не выбрана строка для удаления");
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
        /// Загрузка Источников получения
        /// </summary>
        private void LoadSources()
        {
            User.load_sources();

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
    }
}
