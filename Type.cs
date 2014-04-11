using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iMuseum
{
    /// <summary>
    /// Класс,отвечающий  за Тип экспоната
    /// </summary>
    class Type
    {
        /// <summary>
        ///  Создать экземпляр класса Типа экспоната
        /// </summary>
        public Type()
        {
            pk_type = 0;
            nameValue = "";
        }

      /*  private int pk_typeValue;


        /// <summary>
        ///  ПК ,который однзачно определяет Тип Экспоната
        /// </summary>
        public int pk_type
        {
            get { return pk_typeValue; }
            set { pk_typeValue = value; }
        }
        */

        private int pk_type;
        public void setPkType(int id) { this.pk_type = id; }
        public int getPkType() { return this.pk_type; }



        private string nameValue;

        /// <summary>
        /// Наименование Типа Экспоната
        /// </summary>
        public string name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }



    }
}
