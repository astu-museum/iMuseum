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
        }

        private void searchSett(object sender, EventArgs e)
        {
            mainSettings mst = new mainSettings();
            mst.ShowDialog();
        }
    }
}
