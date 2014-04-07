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
    public partial class Filter : Form
    {
        public Filter()
        {
           // DataSet1TableAdapters.CATEGORYTableAdapter st = new DataSet1TableAdapters.CATEGORYTableAdapter();

            /*
            DataSet1.CATEGORYDataTable customerData = st.GetData();

            checkBoxComboBox3.DataSource = customerData.Rows;
            */
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            

          //  MessageBox.Show(checkBoxComboBox3.SelectedIndex.ToString());
        }
    }
}
