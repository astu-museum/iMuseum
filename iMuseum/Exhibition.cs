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


        /// <summary>
        /// Список экспонатов выставки
        /// </summary>
        List<Exponat> exponats;


        //Добавить список Экспонатов и Категорий


        /*
        private int pk_exhibitionValue;


        /// <summary>
        ///  ПК ,который однзачно определяет Выставку
        /// </summary>
        public int pk_exhibition
        {
            get { return pk_exhibitionValue; }
            set { pk_exhibitionValue = value; }
        }*/

        /// <summary>
        /// ПК выставк
        /// </summary>
        private int pk_exhibition;
        public void setPkExhibition(int id) { this.pk_exhibition = id; }
        public int getPkExhibition() { return this.pk_exhibition; }


        /// <summary>
        /// Наименование категории
        /// </summary>
        private string nameValue;
           
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
