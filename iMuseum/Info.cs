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

        /// <summary>
        /// Конструктор формы Подробнее об экспонате (по-умолчанию)
        /// </summary>
        public Info()
        {
            InitializeComponent();
            exponatId = 0;
        }

        /// <summary>
        /// Конструктор формы Подробнее об экспонате (рабочий)
        /// </summary>
        /// <param name="pk"></param>
        public Info(Int32 pk)
        {
            InitializeComponent();
            exponatId = pk;
        }
        
        /// <summary>
        /// Загрузка информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Load(object sender, EventArgs e)
        {
             User.load_exponatsp(exponatId);

             if (User.exponats[0].getPic() != " ")
             {
                 //MessageBox.Show(User.exponats[0].getPic());
                 pictureBox1.ImageLocation = User.exponats[0].getPic();
             }
        }

        /// <summary>
        /// Печать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print(object sender, EventArgs e)
        {

        }
    }
}
