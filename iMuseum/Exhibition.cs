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
            pk_exhibition = 0;
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


        /// <summary>
        /// СОХРАНЕНИЕ В БАЗУ экс
        /// </summary>

        public void save()
        {
         // INSERT INTO "KOMRAZR"."EXHIBITION" ("NAME_", "DATESTART", "DATEEND") VALUES ( ?, ?, ?)


     


           //Если новенький,то занести
            if (pk_exhibition == 0)
            {

                DataSet1TableAdapters.EXHIBITIONTableAdapter regionTableAdapter =
                new DataSet1TableAdapters.EXHIBITIONTableAdapter();


                regionTableAdapter.InsertExp(name,datestart,dateend);


                //Получим ПК,чтоб цеплять категории
                DataSet1.EXHIBITIONDataTable dt = regionTableAdapter.GetPkExhibition(name);

                foreach (DataSet1.EXHIBITIONRow sRow in dt)
                {
                   pk_exhibition = Convert.ToInt32(sRow.PK_EXHIBITION);
                }

                DataSet1TableAdapters.CATEGORYEXHIBITIONTableAdapter cta =
               new DataSet1TableAdapters.CATEGORYEXHIBITIONTableAdapter();


                //ПОЦЕПЛЯЕМ КАТЕГОРИЙ,ИБО НОВАЯ ВЫСТАВКА
                for(int i = 0;i < categories.Count;i++){
                    //INSERT INTO "KOMRAZR"."CATEGORYEXHIBITION" ("PK_CATEGORY", "PK_EXHIBITION",") VALUES (?, ?)
                    cta.InsertExp(categories[i],pk_exhibition);
                }


            }


            DataSet1TableAdapters.CATEGORYEXPONATTableAdapter ctex =
               new DataSet1TableAdapters.CATEGORYEXPONATTableAdapter();

            for (int i = 0; i < exponats.Count; i++)
            {
                //INSERT INTO "KOMRAZR"."CATEGORYEXPONAT" ("PK_EXHIBITION", "PK_EXPONAT") VALUES (?, ?)
                ctex.InsertExp(pk_exhibition,exponats[i]);
            }

        }

        /// <summary>
        /// Удаление выставки из базы
        /// </summary>
        public void delete_()
        {
            DataSet1TableAdapters.EXHIBITIONTableAdapter regionTableAdapter = new DataSet1TableAdapters.EXHIBITIONTableAdapter();

            regionTableAdapter.DeleteQuery(pk_exhibition);
        }
 

        


    }
}
