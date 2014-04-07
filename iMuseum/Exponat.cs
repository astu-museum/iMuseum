using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iMuseum
{
    /// <summary>
    /// Класс,отвечающий за экспонат...ДОПИЛИТЬ НЕПОЛНЫЙ НИСОКЛЬКО
    /// </summary>
    class Exponat
    {

        /// <summary>
        /// Создать экземпляр класса экспоната
        /// </summary>
        public Exponat()
        {
        }

        // ПК ,который однзачно определяет Экспонат
        private int pk_exponatValue;
        /// <summary>
        /// ПК ,который однзачно определяет Экспонат
        /// </summary>
        public int pk_exponat
        {
            get { return pk_exponatValue; }
            set { pk_exponatValue = value; }
        }

        private int pk_sourceValue;

        /// <summary>
        ///  внешний ключ ,который однзачно определяет Источник Получения
        /// </summary>
        /// 
    

        public int pk_source
        {
            get { return pk_sourceValue; }
            set { pk_sourceValue = value; }
        }


        private int pk_categoryexpValue;

        /// <summary>
        ///  ПК ,который однзачно определяет Категорию
        /// </summary>
        public int pk_categoryexp
        {
            get { return pk_categoryexpValue; }
            set { pk_categoryexpValue = value; }
        }


        private int pk_categoryautValue;
        /// <summary>
        ///  ПК ,который однзачно определяет Категорию
        /// </summary>
        public int pk_categoryaut
        {
            get { return pk_categoryautValue; }
            set { pk_categoryautValue = value; }
        }


        private int pk_categoryaudValue;
        /// <summary>
        ///  ПК ,который однзачно определяет Категорию
        /// </summary>
        public int pk_categoryaud
        {
            get { return pk_categoryaudValue; }
            set { pk_categoryaudValue = value; }
        }



        private DateTime dateValue;
        /// <summary>
        ///  Дата получения экспоната
        /// </summary>
        public DateTime date
        {
            get { return dateValue; }
            set { dateValue = value; }
        }





    }
}
