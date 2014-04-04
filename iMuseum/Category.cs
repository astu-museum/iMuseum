using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iMuseum
{

    /// <summary>
    /// Класс,отвечающий за категории
    /// </summary>
    class Category
    {
        /// <summary>
        /// Создать экземпляр класса категории
        /// </summary>
        public Category()
        {
        }


        private int pk_categoryValue;


        /// <summary>
        ///  ПК ,который однзачно определяет Категорию
        /// </summary>
        public int pk_category
        {
            get { return pk_categoryValue; }
            set { pk_categoryValue = value; }
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

        private int numberValue;

        /// <summary>
        /// Тип категории(1 - категория экспоната,2-Категория автора,3-категория целевой аудитории)
        /// </summary>
        public int number
        {
            get { return numberValue; }
            set { numberValue = value; }
        }


        //Еще нужен save,update,load,delete


    }
}
