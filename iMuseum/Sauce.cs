using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iMuseum
{

    /// <summary>
    /// Класс,отвечающий  за источник получения экспоната
    /// </summary>

    class Sauce
    {
        /// <summary>
        ///  Создать экземпляр класса источника
        /// </summary>
        public Sauce()
        {
            pk_source = 0;
            address = "";
        }

        /*
        private int pk_sourceValue;


        /// <summary>
        ///  ПК ,который однзачно определяет Источник Получения
        /// </summary>
        public int pk_source
        {
            get { return pk_sourceValue; }
            set { pk_sourceValue = value; }
        }
        */

        private int pk_source;
        public void setPkSource(int id) { this.pk_source = id; }
        public int getPkSource() { return this.pk_source; }

        private string nameValue;

        /// <summary>
        /// Наименование Источника
        /// </summary>
        public string name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        private string addressValue;

        /// <summary>
        /// Адрес Источник
        /// </summary>
        public string address
        {
            get { return addressValue; }
            set { addressValue = value; }
        }
    }
}
