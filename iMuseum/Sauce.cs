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
            addressValue = "";
            nameValue = "";
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
        
        public string name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }
         
        public string address
        {
            get { return addressValue; }
            set { addressValue = value; }
        }
         */

        /// <summary>
        /// Первичный ключ источника получения
        /// </summary>
        private int pk_source;

        /// <summary>
        /// Установить первичный ключ источника получения
        /// </summary>
        /// <param name="id">Первичный ключ источника получения</param>
        public void setPkSource(int id) { this.pk_source = id; }

        /// <summary>
        /// Вернуть первичный ключ источника получения
        /// </summary>
        /// <returns>Первичный ключ источника получения</returns>
        public int getPkSource() { return this.pk_source; }

        /// <summary>
        /// Наименование Источника
        /// </summary>
        private string nameValue;

        /// <summary>
        /// Установить наименование источника получения
        /// </summary>
        /// <param name="nameVal">Наименование источника получения</param>
        public void setName(string nameVal) { this.nameValue = nameVal; }

        /// <summary>
        /// Вернуть наименование источника получения
        /// </summary>
        /// <returns>Наименование источника получения</returns>
        public string getName() { return this.nameValue; }
        

        /// <summary>
        /// Адрес источника получения
        /// </summary>
        private string addressValue;

        /// <summary>
        /// Установить адрес источника получения
        /// </summary>
        /// <param name="addrVal">Адрес источника получения</param>
        public void setAddress(string addrVal) { this.addressValue = addrVal; }

        /// <summary>
        /// Вернуть адрес источника получения
        /// </summary>
        /// <returns>Адрес источника получения</returns>
        public string getAddress() { return this.addressValue; }
    }
}
