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
        int pk;

        public ExbDetails()
        {
            InitializeComponent();
            pk = 0;
        }

        public ExbDetails(int pk1)
        {
            InitializeComponent();
            pk = pk1;
        }

        private void addEE(object sender, EventArgs e)
        {
            AddExpExb aee = new AddExpExb();
            aee.ShowDialog();
        }

        void Load_Some()
        {
            User.load_exhibitionsp(pk);

            label1.Text = User.exhibitions[0].name;
            label2.Text = User.exhibitions[0].datestart + "-" + User.exhibitions[0].dateend;
            //label3.Text = User.exhibtions[0].
        }

        private void ExbDetails_Load(object sender, EventArgs e)
        {
            Load_Some();
        }
    }
}
