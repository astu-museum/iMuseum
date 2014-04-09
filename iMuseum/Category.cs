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
            pk_category = 0;
            nameValue = "";
            number = "";
            numberInt = 0;
        }


        /*
        private int pk_categoryValue;


        /// <summary>
        ///  ПК ,который однзачно определяет Категорию
        /// </summary>
        public int pk_category
        {
            get { return pk_categoryValue; }
            set { pk_categoryValue = value; }
        }
         */

        private int pk_category;
        public void setPkCategory(int id) { this.pk_category = id; }
        public int getPkCategory() { return this.pk_category; }
         

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
        /// Тип категории(число)
        /// </summary>
        private int numberInt;
        /// <summary>
        /// Сеттер числовго предстваления типа категории
        /// </summary>
        /// <param name="id"></param>
        public void setNumberInt(int id) { this.numberInt = id; }
        public int getNumberInt() { return this.numberInt; }


        /// <summary>
        /// Тип категории(строка)(1 - категория экспоната,2-Категория автора,3-категория целевой аудитории)
        /// </summary>
        private string numberValue;

        
        public string number
        {
            get { return numberValue; }
            set { numberValue = value; }
        }


        //Еще нужен save,update,load,delete


    }
}
