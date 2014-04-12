using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iMuseum
{
    public partial class AddType : Form
    {
        public AddType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelCLK(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okCLK(object sender, EventArgs e)
        {
            for(Int32 i = 0; i < textBox_title.Text.Length; i++)
                if (((textBox_title.Text[i] < 'а') || (textBox_title.Text[i] > 'я')) && ((textBox_title.Text[i] < 'А') || (textBox_title.Text[i] > 'Я'))
                    && (textBox_title.Text[i] != ' ') && (textBox_title.Text[i] != '-'))
                {
                    MessageBox.Show("Допускаются только русские буквы и символы: пробел и -");
                    return;
                }


            //Проверка криворукости
            String checkstr = textBox_title.Text;
            checkstr = checkstr.TrimEnd(new Char[] { ' ', '-' });
            if (checkstr.Length == 0)
            {
                MessageBox.Show("Введите наименование типа экспоната");
                return;
            }

            DataSet1TableAdapters.TYPEEXPONATTableAdapter typeAdapter = new DataSet1TableAdapters.TYPEEXPONATTableAdapter();

            //Проверка на дублирование
            if (typeAdapter.DoubleTYPE(textBox_title.Text) != 0)
            {
                MessageBox.Show("Тип " + textBox_title.Text + " уже существует");
                return;
            }
            
            //Добавляем в базу
            typeAdapter.InsertTYPE(textBox_title.Text);

            this.Close();
        }
    }
}
