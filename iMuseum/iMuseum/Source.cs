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

        private void addNewSource(object sender, EventArgs e)
        {
            AddSource asrc = new AddSource();
            asrc.ShowDialog();
        }

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
    }
}
