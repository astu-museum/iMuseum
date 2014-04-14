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
    public partial class Info : Form
    {
        int exponatId;

        public Info()
        {
            InitializeComponent();
            exponatId = 0;
        }

        public Info(Int32 pk)
        {
            InitializeComponent();
            exponatId = pk;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Изменение информации об экспонате
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editExp(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void Info_Load(object sender, EventArgs e)
        {
             User.load_exponatsp(exponatId);

             if (User.exponats[0].getPic() != " ")
             {
                 //MessageBox.Show(User.exponats[0].getPic());
                 pictureBox1.ImageLocation = User.exponats[0].getPic();
             }
        }
    }
}
