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


       
        /// <summary>
        /// ПК экспоната
        /// </summary>
        private int pk_exponat;
        public void setPkExponat(int id) { this.pk_exponat = id; }
        public int getPkExponat() { return this.pk_exponat; }

        /// <summary>
        /// ПК источника получения
        /// </summary>
        private int pk_source;
        public void setPkSource(int id) { this.pk_source = id; }
        public int getPkSource() { return this.pk_source; }


        /// <summary>
        /// Строковое представление источника
        /// </summary>
        private string sourceString;


        public string sourceValue
        {
            get { return sourceString; }
            set { sourceString = value; }
        }

        /// <summary>
        /// Тип Эукспоната
        /// </summary>
        private int pk_type;
        public void setPkType(int id) { this.pk_type = id; }
        public int getPkType() { return this.pk_type; }



        /// <summary>
        /// ПК категории Экспоанат
        /// </summary>
        private int pk_categoryExp;
        public void setPkCategoryExp(int id) { this.pk_categoryExp = id; }
        public int getPkCategoryExp() { return this.pk_categoryExp; }

        /// <summary>
        /// ПК категории Автора
        /// </summary>
        private int pk_categoryAut;
        public void setPkCategoryAut(int id) { this.pk_categoryAut = id; }
        public int getPkCategoryAut() { return this.pk_categoryAut; }

        /// <summary>
        /// Пк категории Аудитории
        /// </summary>
        private int pk_categoryAud;
        public void setPkCategoryAud(int id) { this.pk_categoryAud = id; }
        public int getPkCategoryAud() { return this.pk_categoryAud; }


        private DateTime dateValue;
        /// <summary>
        ///  Дата получения экспоната
        /// </summary>
        public DateTime date
        {
            get { return dateValue; }
            set { dateValue = value; }
        }


        private double priceValue;
        /// <summary>
        ///  Цена экспоната
        /// </summary>
        public double price
        {
            get { return priceValue; }
            set { priceValue = value; }
        }

        private string nameValue;

        /// <summary>
        /// Наименование  Экспоната
        /// </summary>
        public string name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }


      
      
        private string inumberValue;
        /// <summary>
        /// Инвентарный номер
        /// </summary>

        public string inumber
        {
            get { return inumberValue; }
            set { inumberValue = value; }
        }


        /// <summary>
        /// Тип Cобственности
        /// </summary>
        private int typeSob;
        public void setTypeSob(int id) { this.typeSob = id; }
        public int getTypeSob() { return this.typeSob; }

       
        private string typeSobStrValue;
        /// <summary>
        /// Строковое Представления Типа Собственности
        /// </summary>
        /// 
        public string typeSobStr
        {
            get { return typeSobStrValue; }
            set { typeSobStrValue = value; }
        }


        /// <summary>
        /// Тип Cобственности
        /// </summary>
        private int place;
        public void setPlace(int id) { this.place = id; }
        public int getPlace() { return this.place; }


        private string placeStrValue;
        /// <summary>
        /// Строковое Представления Типа Собственности
        /// </summary>
        /// 
        public string placeStr
        {
            get { return placeStrValue; }
            set { placeStrValue = value; }
        }

     

        //Состояние(число)
        private int damage;
        public void setDamage(int id) { this.damage = id; }
        public int getDamage() { return this.damage; }


        private string damageStrValue;
        /// <summary>
        /// Строковое Представления Состояния
        /// </summary>
        /// 
        public string damageStr
        {
            get { return damageStrValue; }
            set { damageStrValue = value; }
        }


        //Флаг СПисания
        private int flag;
        public void setFlag(int id) { this.flag = id; }
        public int getFlag() { return this.flag; }

        //ФИО Автора
        private string fio;
        public void setFio(string id) { this.fio = id; }
        public string getFio() { return this.fio; }

        //Путь к картинке
        private string pic;
        public void setPic(string id) { this.pic = id; }
        public string getPic() { return this.pic; }

        //Путь к картинке
        private string description;
        public void setDescr(string id) { this.description = id; }
        public string getDescr() { return this.description; }



        //СОХРАНЕНИЕ В БАЗУ
        /// <summary>
        ///  Сохранение экспоната в базу
        /// </summary>
        public void save()
        {
            //INSERT INTO "KOMRAZR"."EXPONAT" ( "PK_CATEGORYEXPONAT", "PK_CATEGORYAUTHOR", 
           // "PK_CATEGORYAUDITORY", "PK_SOURCE", "INUMBER", "NAME_", "PRICE_", "DATE_GET", "TYPESOB",
          //  "DESCR", "PLACE_", "DAMAGE", "FLAG", "FIO", "PICREFERENCE", "PK_TYPE") VALUES (?, ?, ?, ?, ?
            //    , ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)


            DataSet1TableAdapters.EXPONATTableAdapter regionTableAdapter =
             new DataSet1TableAdapters.EXPONATTableAdapter();




             regionTableAdapter.InsertExp(Convert.ToDecimal(pk_categoryExp),Convert.ToDecimal(pk_categoryAut),Convert.ToDecimal(pk_categoryAud),Convert.ToDecimal(pk_source),inumber,name,Convert.ToDecimal(price),date,typeSob,description,place,damage,flag,fio,pic,pk_type);

        }

        /// <summary>
        /// Изменеие экспоната в БД
        /// </summary>
        public void update()
        {
 //          UPDATE       KOMRAZR.EXPONAT
//SET                PK_CATEGORYEXPONAT = ?, PK_CATEGORYAUTHOR = ?, PK_CATEGORYAUDITORY = ?, PK_SOURCE = ?, INUMBER = ?, NAME_ = ?, PRICE_ = ?, DATE_GET = ?, 
                      //   TYPESOB = ?, DESCR = ?, PLACE_ = ?, DAMAGE = ?, FLAG = ?, FIO = ?, PICREFERENCE = ?, PK_TYPE = ?
//WHERE        (PK_EXPONAT = ?)

            DataSet1TableAdapters.EXPONATTableAdapter expAdapter = new DataSet1TableAdapters.EXPONATTableAdapter();
            expAdapter.UpdateExp(Convert.ToDecimal(pk_categoryExp), Convert.ToDecimal(pk_categoryAut), Convert.ToDecimal(pk_categoryAud), Convert.ToDecimal(pk_source), inumber, name, Convert.ToDecimal(price), date, typeSob, description, place, damage, flag, fio, pic, pk_type,Convert.ToDecimal(pk_exponat));


        }

        /// <summary>
        /// Удаление экспоната из базы
        /// </summary>
        public void delete_()
        {
            DataSet1TableAdapters.EXPONATTableAdapter regionTableAdapter = new DataSet1TableAdapters.EXPONATTableAdapter();
            regionTableAdapter.DeleteQuery(pk_exponat);
        }

        /// <summary>
        /// Списание экспоната
        /// </summary>
        public void setFlagT()
        {
            DataSet1TableAdapters.EXPONATTableAdapter eta = new DataSet1TableAdapters.EXPONATTableAdapter();
            eta.SetFlagTrue(pk_exponat);
        }

        /// <summary>
        /// Вернуть экспонат из списанных
        /// </summary>
        public void setFlagF()
        {
            DataSet1TableAdapters.EXPONATTableAdapter eta = new DataSet1TableAdapters.EXPONATTableAdapter();
            eta.SetFlagFalse(pk_exponat);
        }
    }
}
