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
    public partial class Exibition : Form
    {
        public Exibition()
        {
            InitializeComponent();
        }

        private void showDetails(object sender, EventArgs e)
        {
            ExbDetails exbdt = new ExbDetails();
            exbdt.ShowDialog();
        }

        private void addExb(object sender, EventArgs e)
        {
            AddExib addex = new AddExib();
            addex.ShowDialog();
        }
    }
}
