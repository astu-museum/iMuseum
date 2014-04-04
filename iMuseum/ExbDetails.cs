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
    public partial class ExbDetails : Form
    {
        public ExbDetails()
        {
            InitializeComponent();
        }

        private void addEE(object sender, EventArgs e)
        {
            AddExpExb aee = new AddExpExb();
            aee.ShowDialog();
        }
    }
}
