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
        public AddExib()
        {
            InitializeComponent();
        }

        private void forming(object sender, EventArgs e)
        {
            AddExpExb aee = new AddExpExb();
            aee.ShowDialog();
        }
    }
}
