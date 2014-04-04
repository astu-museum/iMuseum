using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iMuseum
{
    /// <summary>
    /// Класс,отвечающий за выставки
    /// </summary>
    class Exhibition
    {
        /// <summary>
        /// Создать экземпляр класса выставки
        /// </summary>
        public Exhibition()
        {
        }


        private int pk_exhibitionValue;


        /// <summary>
        ///  ПК ,который однзачно определяет Выставку
        /// </summary>
        public int pk_exhibition
        {
            get { return pk_exhibitionValue; }
            set { pk_exhibitionValue = value; }
        }

        private string nameValue;

        /// <summary>
        /// Наименование категории
        /// </summary>
        public string name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        /// <summary>
        /// Дата начала выставки
        /// </summary>
        private DateTime datestartValue;

        public DateTime datestart
        {
            get { return datestartValue; }
            set { datestartValue = value; }
        }

        /// <summary>
        /// Дата окончания выставки
        /// </summary>

        private DateTime dateendValue;

        public DateTime dateend
        {
            get { return dateendValue; }
            set { dateendValue = value; }
        }
 


    }
}
