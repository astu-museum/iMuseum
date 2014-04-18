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

             if (User.exponats[0].getPic() != " ") pictureBox1.ImageLocation = User.exponats[0].getPic();                         //Изображение
             
             label_number.Text = User.exponats[0].inumber.ToString();                       //Инвентарный номер
             label_title.Text = User.exponats[0].name.ToString();                           //Наименование экспоната
             label_damage.Text = "Состояние экспоната: " + User.exponats[0].damageStr;      //Состояние
             label_date.Text = "Дата получения: " + User.exponats[0].date.ToString().Substring(0, 10);                  //Дата получения
             label_mesto.Text = "Место хранения: " + User.exponats[0].placeStr;    //Место хранения
             label_price.Text = "Цена: " + User.exponats[0].price + " рублей";      //Цена экспоната
             label_source.Text = "Источник получения: " + User.exponats[0].sourceValue; //Источник получения

             textBox_info.Text = User.exponats[0].getDescr(); //Описание

             if(User.exponats[0].getFio() != " ") label_author.Text = "Автор: " + User.exponats[0].getFio(); //Автор
             label_sypesob.Text = "Тип собственности: " + User.exponats[0].typeSobStr; //Тип собственности

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
