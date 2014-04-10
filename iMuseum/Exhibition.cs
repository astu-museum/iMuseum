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
            exponats = new List<int>();
            categories = new List<int>();
             cnames = new List<string>();
             types = new List<int>();
        }



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
        /// Список экспонатов выставки
        /// </summary>
      private List<int> exponats;
        /// <summary>
        /// ПК категорий
        /// </summary>
      private List<int> categories;
      /// <summary>
      /// ПК Типов
      /// </summary>
      private List<int> types;
        /// <summary>
        /// Имена категорий
        /// </summary>
      private List<string> cnames;
 




        //Экспонаты
      public void setExponats(List<int> a)
      {
          exponats = a;
      }

      public List<int> getExponats()
      {
          return exponats;
      }

      public void addExponat(int a)
      {
          exponats.Add(a);
      }

      public int getExponat(int i )
      {
          return exponats[i];
      }

        //Имена
      public void setCategories(List<int> a)
      {
          categories = a;
      }

      public List<int> getCategories()
      {
          return categories;
      }

      public void addCategory(int a)
      {
          categories.Add(a);
      }

      public int getCategory(int i)
      {
          return categories[i];
      }


        //КатеГории


      public void setCnames(List<string> a)
      {
          cnames = a;
      }

      public List<string> getCnames()
      {
          return cnames;
      }

      public void addCname(string a)
      {
          cnames.Add(a);
      }

      public string getCname(int i)
      {
          return cnames[i];
      }
        //Типы

      public void setTypes(List<int> a)
      {
          types = a;
      }

      public List<int> getTypes()
      {
          return types;
      }

      public void addType(int a)
      {
          types.Add(a);
      }

      public int getTypes(int i)
      {
          return types[i];
      }



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
