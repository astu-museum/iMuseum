using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iMuseum
{
    public partial class FlaggedExponats : Form
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public FlaggedExponats()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка списанных экспонатов в грид
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Flagged_Exps_Load(object sender, EventArgs e)
        {
            loadExps_Flagged();
        }

        private void loadExps_Flagged()
        {
            User.load_flagged_exponats();

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

        /// <summary>
        /// Отменить списание
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setFalseFlag(object sender, EventArgs e)
        {
            try
            {
                int p = dataGridView1.SelectedCells[0].RowIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбрана строка для отмены списания");
                return;
            }

            if (MessageBox.Show("Отменить списание?", "Отмена списания экспоната", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            User.exponats[dataGridView1.SelectedCells[0].RowIndex].setFlagF();

            loadExps_Flagged();
        }
    }
}
