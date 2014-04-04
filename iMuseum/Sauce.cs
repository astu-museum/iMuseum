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
        }

        private int pk_sourceValue;


        /// <summary>
        ///  ПК ,который однзачно определяет Источник Получения
        /// </summary>
        public int pk_source
        {
            get { return pk_sourceValue; }
            set { pk_sourceValue = value; }
        }

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
        /// Тип категории(1 - категория экспоната,2-Категория автора,3-категория целевой аудитории)
        /// </summary>
        public string address
        {
            get { return addressValue; }
            set { addressValue = value; }
        }

     


    }
}
