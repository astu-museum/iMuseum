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
    public partial class AddType : Form
    {
        public AddType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelCLK(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okCLK(object sender, EventArgs e)
        {

        }
    }
}
