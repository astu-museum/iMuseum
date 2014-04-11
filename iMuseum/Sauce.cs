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
            name = "";
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
        /// Наименование источника получения (переменная)
        /// </summary>
        private string nameValue;

        /// <summary>
        /// Наименование источника получения
        /// </summary>
        public string name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        /// <summary>
        /// Адрес источника получения (переменная)
        /// </summary>
        private string addressValue;

        /// <summary>
        /// Адрес источника получения
        /// </summary>
        public string address
        {
            get { return addressValue; }
            set { addressValue = value; }
        }

        /// <summary>
        /// Сохранение в базу Источника получения
        /// </summary>
        public void save()
        {
            DataSet1TableAdapters.SOURCETableAdapter srcAdapter = new DataSet1TableAdapters.SOURCETableAdapter();

            srcAdapter.InsertSRC(nameValue, addressValue);
        }

        /// <summary>
        /// Удаление источника из БД
        /// </summary>
        public void delete()
        {

        }
    }
}
