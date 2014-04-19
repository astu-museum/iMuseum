using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace iMuseum
{
    /// <summary>
    /// Форма "Информация об экспонате"
    /// </summary>
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
            printDocument1.PrintPage += new PrintPageEventHandler(pre_print);
            printDocument1.DocumentName = label_title.Text;
            if (printDialog_exp.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog_exp.PrinterSettings;

                printDocument1.Print();
            }
        }

        /// <summary>
        /// Метод печати
        /// </summary>
        /// <param name="expInfo"></param>
        private void pre_print(object sender, PrintPageEventArgs e)
        {
            Bitmap printExp = new Bitmap(765, 510);
            this.DrawToBitmap(printExp, new Rectangle(0, 0, 765, 510));

            Rectangle rc = new Rectangle(10, 30, 755, 480);
            printExp = GetBitmapRegion(rc, printExp);

            Graphics g = e.Graphics;
            g.DrawImage(printExp,0,0);
        }

        /// <summary>
        /// Обрезка изображения
        /// </summary>
        /// <param name="rect">Область обрезки</param>
        /// <param name="bmp">Изображение</param>
        /// <returns></returns>
        Bitmap GetBitmapRegion(Rectangle rect, Bitmap bmp)
        {
            Bitmap region = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(region))
            {
                g.DrawImage(bmp, 0, 0, rect, GraphicsUnit.Pixel);
            }
            return region;
        }
    }
}
