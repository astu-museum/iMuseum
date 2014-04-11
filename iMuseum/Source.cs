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
            AddSource asrc = new AddSource();
            asrc.ShowDialog();
        }

        private void srcSet(object sender, EventArgs e)
        {
            sourceSettings srcs = new sourceSettings();
            srcs.ShowDialog();
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

            User.sources[dataGridView1.SelectedCells[0].RowIndex].delete();

            LoadSources();
        }
    }
}
