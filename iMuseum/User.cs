using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMuseum
{
    class User
    {
        //Массивы для привязок к Датагридам
        public static List<Exponat> exponats;
        public static List<Category> categories;
        public static List<Type> types;
        public static List<Sauce> sources;
        public static List<Exhibition> exhibitions;

        //Фильтровочные списки
        public static List<int> typeFilter;
        public static List<int> categoryExponatFilter;
        public static List<int> categoryAuthorFilter;
        public static List<int> categoryAuditoryFilter;

        //Поискостыль
      public static string name0,source0,inumber0;
      public static int place0, damage0, typesob0;
      public static double pricefrom, priceto;
      public static DateTime datestart, dateend;


        //Строковые представления того,что хранися в виде Интовых Чисел
        public static List<string> typeSobString = new List<string>(5) { "Собственность музея","На временном пользовании"};
        public static List<string> placeString = new List<string>(5) { "Выставка", "Резерв","На хранении у стороненго лица" };
        public static List<string> damageString = new List<string>(5) { "Отличное", "Хорошее","Удовлетворительное","Неудовлетворительное" };
        public static List<string> numberString = new List<string>(5) {"Категория экспоната", "Категория автора", "Целевая аудитория" };

        //Создадим адаптер,шоб шифроваться
        public static DataSet1.SOURCEDataTable dtrip;


        //Массив отметок,МУХАХАХА
        public static List<int> Checks;


        //Генерашки
        public static void generate(int count)
        {

            Checks = new List<int>();

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; (i < exponats.Count)&&(count>0); i++)
                {
                    if(exponats[i].getDamage()==j){
                        Checks.Add(i);
                        count--;
                    }

                }
            }

        }

        /// <summary>
        /// Поиск экспонатов
        /// </summary>
        public static void find_exponats()
        {

            for (int i = 0; i < exponats.Count; i++)
            {
                if (!exponats[i].name.ToUpper().Contains(name0.ToUpper()))
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (!exponats[i].inumber.ToUpper().Contains(inumber0.ToUpper()))
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (!exponats[i].sourceValue.ToUpper().Contains(source0.ToUpper()))
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }


                if (exponats[i].getDamage() != damage0&&damage0!=-1)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (exponats[i].getTypeSob() != typesob0&&typesob0!=-1)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (exponats[i].getPlace() != place0&&place0!=-1)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (exponats[i].price < pricefrom || exponats[i].price > priceto)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }


                if (exponats[i].date < datestart ||exponats[i].date > dateend)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }


            }


        }

        /// <summary>
        /// Поиск экспонатов по выставке
        /// </summary>
        public static void find_exponats_exhibition()
        {

            for (int i = 0; i < exponats.Count; i++)
            {
                if (!exponats[i].name.ToUpper().Contains(name0.ToUpper()))
                {

                    //Выкидываем метку и сдвигаем остальные
                   for(int j = 0;j < Checks.Count;j++){
                        if (Checks[j] == i)
                        {
                           Checks.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            if (Checks[j] > i)
                            {
                                Checks[j]--;
                            }

                        }
                    }

                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (exponats[i].getDamage()!=damage0&&damage0!=-1)
                {

                    for (int j = 0; j < Checks.Count; j++)
                    {
                        if (Checks[j] == i)
                        {
                            Checks.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            if (Checks[j] > i)
                            {
                                Checks[j]--;
                            }

                        }
                    }

                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (exponats[i].getPlace() != place0&&place0!=-1)
                {

                    for (int j = 0; j < Checks.Count; j++)
                    {
                        if (Checks[j] == i)
                        {
                            Checks.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            if (Checks[j] > i)
                            {
                                Checks[j]--;
                            }

                        }
                    }


                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                if (exponats[i].price < pricefrom || exponats[i].price > priceto)
                {

                    for (int j = 0; j < Checks.Count; j++)
                    {
                        if (Checks[j] == i)
                        {
                            Checks.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            if (Checks[j] > i)
                            {
                                Checks[j]--;
                            }

                        }
                    }

                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }


            }



        }

        /// <summary>
        /// Поиск источников получения
        /// </summary>
        public static void sourceSearch(string s)
        {
            for (int i = 0; i < sources.Count; i++)
            {
                if(!sources[i].name.ToUpper().Contains(s.ToUpper())){
                    sources.RemoveAt(i);
                    i--;
                    continue;
                }
            }
        }

   

        /// <summary>
        /// Фильтр
        /// </summary>
        public static void filter()
        {
            for (int i = 0; i < exponats.Count; i++)
            {

                //Проверка соответствия типа
                bool flag = false;

                if (typeFilter.Count == 0)
                {
                    flag = true;
                }
                else
                {
                    for (int j = 0; (j < typeFilter.Count)&&!flag; j++)
                    {
                        if (exponats[i].getPkType() == typeFilter[j])
                        {
                            flag = true;
                        }
                    }
                }

                if (!flag)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    flag = false;
                }

                //Проверка категории экспоната
                if (categoryExponatFilter.Count == 0)
                {
                    flag = true;
                }
                else
                {
                    for (int j = 0; (j < categoryExponatFilter.Count) && !flag; j++)
                    {
                        if (exponats[i].getPkCategoryExp() == categoryExponatFilter[j])
                        {
                            flag = true;
                        }
                    }
                }

                if (!flag)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    flag = false;
                }


                //Проверка категории Автора
                if (categoryAuthorFilter.Count == 0)
                {
                    flag = true;
                }
                else
                {
                    for (int j = 0; (j < categoryAuthorFilter.Count) && !flag; j++)
                    {
                        if (exponats[i].getPkCategoryAut() == categoryAuthorFilter[j])
                        {
                            flag = true;
                        }
                    }
                }

                if (!flag)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    flag = false;
                }


                //Проверка категории Аудитории
                if (categoryAuditoryFilter.Count == 0)
                {
                    flag = true;
                }
                else
                {

                    //Возможно дуткие объявления
                    int  mini =  20000000;
                    DataSet1.CATEGORYDataTable dtt;
                    DataSet1TableAdapters.CATEGORYTableAdapter cta;

                    for (int j = 0; (j < categoryAuditoryFilter.Count) && !flag; j++)
                    {

                        //ОСОБЫЕ НОВОВВЕДЕНИЯ....ПРОВЕРЯЕМ,ЧТО ЭКПОНАТ НЕ НИЖЕ НИЖНЕЙ ПЛАНКИ

                        //ВПЛЕТЕНИЕ ИСТОЧНИКА
                     cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


                     dtt = cta.GetCategByPK(categoryAuditoryFilter[j]);

                        foreach (DataSet1.CATEGORYRow secRow in dtt)
                        {
                            string s =secRow.NAME_ ;

                            string s1 = s.Substring(0, s.Length - 1);
                            int p = Convert.ToInt32(s1);

                            if (p < mini) mini = p;
                        }


                        /*
                        if (exponats[i].getPkCategoryAud() == categoryAuditoryFilter[j])
                        {
                            flag = true;
                        }
                         * */
                    }


                    //ПРОВЕРКА ЭКСПОНАТА НА НЕПРЫВЫШЕНИЕ ЦЕНЗА
                     cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


                       dtt = cta.GetCategByPK(exponats[i].getPkCategoryAud());

                       foreach (DataSet1.CATEGORYRow secRow in dtt)
                       {
                           string s = secRow.NAME_;

                           string s1 = s.Substring(0, s.Length - 1);
                           int p = Convert.ToInt32(s1);

                           if (p >= mini) flag = true;
                       }

                }

                   

                if (!flag)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    flag = false;
                }





            }

        }


        //СПЕЦИАЛЬНАЯ ПРОВЕРКА ДЛЯ ВЫСТАВОК
        //FILTER

        /// <summary>
        /// Выборка экспонатов для выставки
        /// </summary>
        public static void filterExh()
        {
            for (int i = 0; i < exponats.Count; i++)
            {

                //Проверка соответствия типа
                bool flag = false;

               
                /*
                if (exhibitions[0].getTypes().Count == 0)
                {
                    flag = true;
                }
                else
                {
                    for (int j = 0; (j < exhibitions[0].getTypes().Count) && !flag; j++)
                    {
                        if (exponats[i].getPkType() == exhibitions[0].getTypes(j))
                        {
                            flag = true;
                        }
                    }
                }

                if (!flag)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    flag = false;
                }
                 * */




                //Проверка категории экспоната
             //  if (exhibitions[0].getCategories().Count == 0)
           //     {
            //        flag = true;
            //    }
            //    else
           //     {
                    for (int j = 0; (j < exhibitions[0].getCategories().Count) && !flag; j++)
                    {
                        if (exponats[i].getPkCategoryExp() == exhibitions[0].getCategories()[j])
                        {
                            flag = true;
                        }
                    }
             //   }

                    if (!flag)
                    {
                        exponats.RemoveAt(i);
                        i--;
                        continue;
                    }
                    else
                    {
                        flag = false;
                    }




                //Проверка категории Автора
           //     if (exhibitions[0].getCategories().Count == 0)
          //      {
          //          flag = true;
          //      }
            //    else
          //      {
                    for (int j = 0; (j < exhibitions[0].getCategories().Count) && !flag; j++)
                    {
                        if (exponats[i].getPkCategoryAut() == exhibitions[0].getCategories()[j])
                        {
                            flag = true;
                        }
                    }
           //     }


                    if (!flag)
                    {
                        exponats.RemoveAt(i);
                        i--;
                        continue;
                    }
                    else
                    {
                        flag = false;
                    }


                //Проверка категории Аудитории
         //       if (exhibitions[0].getCategories().Count == 0)
         //       {
          //          flag = true;
          //      }
        //        else
        //        {
                    
             
            //    }
                    //Возможно дуткие объявления
                    int mini = 20000000;
                    DataSet1.CATEGORYDataTable dtt;
                    DataSet1TableAdapters.CATEGORYTableAdapter cta;

                    for (int j = 0; (j < exhibitions[0].getCategories().Count) && !flag; j++)
                    {

                        //ОСОБЫЕ НОВОВВЕДЕНИЯ....ПРОВЕРЯЕМ,ЧТО ЭКПОНАТ НЕ НИЖЕ НИЖНЕЙ ПЛАНКИ

                        //ВПЛЕТЕНИЕ ИСТОЧНИКА
                        cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


                        dtt = cta.GetCategByPK(exhibitions[0].getCategories()[j]);

                        foreach (DataSet1.CATEGORYRow secRow in dtt)
                        {
                            if (secRow.NUMBER_ == 3)
                            {
                                string s = secRow.NAME_;

                                string s1 = s.Substring(0, s.Length - 1);
                                int p = Convert.ToInt32(s1);

                                if (p < mini) mini = p;
                            }
                        }


                        /*
                        if (exponats[i].getPkCategoryAud() == categoryAuditoryFilter[j])
                        {
                            flag = true;
                        }
                         * */
                    }


                    //ПРОВЕРКА ЭКСПОНАТА НА НЕПРЫВЫШЕНИЕ ЦЕНЗА
                    cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


                    dtt = cta.GetCategByPK(exponats[i].getPkCategoryAud());

                    foreach (DataSet1.CATEGORYRow secRow in dtt)
                    {
                        string s = secRow.NAME_;

                        string s1 = s.Substring(0, s.Length - 1);
                        int p = Convert.ToInt32(s1);

                        if (p >= mini) flag = true;
                    }



                if (!flag)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }
                else
                {
                    flag = false;
                }


                if (exponats[i].date > exhibitions[0].dateend)
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                }

                DataSet1TableAdapters.CATEGORYEXPONATTableAdapter eta = new DataSet1TableAdapters.CATEGORYEXPONATTableAdapter();
                if (eta.WTF(exponats[i].getPkExponat(), exhibitions[0].datestart, exhibitions[0].datestart, exhibitions[0].dateend, exhibitions[0].dateend).ToString() != "0")
                {
                    exponats.RemoveAt(i);
                    i--;
                    continue;
                    
                }

                

              


            }

        }

        /// <summary>
        /// Выгрузка выставки с ключом pk
        /// </summary>
        /// <param name="pk">ключ</param>
        /// 
        public static void load_exhibitionsp(int pk)
        {
            DataSet1TableAdapters.EXHIBITIONTableAdapter ta = new DataSet1TableAdapters.EXHIBITIONTableAdapter();


            DataSet1.EXHIBITIONDataTable dt = ta.GetDataByPk(pk);

           exhibitions = new List<Exhibition>();

            foreach (DataSet1.EXHIBITIONRow customerRow in dt)
            {
                Exhibition currentCustomer = new Exhibition();

                //Ключи и неотражаемая в гриде ересь
                currentCustomer.setPkExhibition(Convert.ToInt32(customerRow.PK_EXHIBITION));



                //Просто отображаемые части
                currentCustomer.datestart = customerRow.DATESTART;
                currentCustomer.dateend = customerRow.DATEEND;
                currentCustomer.name = customerRow.NAME_;


                

                /*
                    //ОПАСНОЕ ВПЛЕТЕНИЕ ИСТОЧНИКА
                DataSet1TableAdapters.SOURCETableAdapter ta = new DataSet1TableAdapters.SOURCETableAdapter();


                DataSet1.SOURCEDataTable dt = ta.HitlerSource(currentCustomer.getPkSource());

                foreach (DataSet1.SOURCERow sRow in dt)
                {
                    currentCustomer.sourceValue = sRow.NAME_;
                }

           
                */


                //СЮДА ВГРУЗИТЬ КАТЕГОРИИ
                DataSet1TableAdapters.CATEGORYTableAdapter vict = new DataSet1TableAdapters.CATEGORYTableAdapter();


                DataSet1.CATEGORYDataTable cdt = vict.GetCateg(pk);

                foreach (DataSet1.CATEGORYRow sam in cdt)
                {
                    currentCustomer.addCategory(Convert.ToInt32(sam.PK_CATEGORY));
                    currentCustomer.addCname(sam.NAME_);
                }


                User.exhibitions.Add(currentCustomer);
            }
        }



       

        /// <summary>
        /// Выгрузка выставки с ключом pk
        /// </summary>
        /// <param name="pk">ключ</param>
        /// 
        public static void load_sourcesp(int pk)
        {
            sources = new List<Sauce>();         
   
                    //ОПАСНОЕ ВПЛЕТЕНИЕ ИСТОЧНИКА
                DataSet1TableAdapters.SOURCETableAdapter ta = new DataSet1TableAdapters.SOURCETableAdapter();


                DataSet1.SOURCEDataTable dt = ta.HitlerSource(pk);

                foreach (DataSet1.SOURCERow sRow in dt)
                {
                    Sauce currentCustomer = new Sauce();

                    currentCustomer.setPkSource(Convert.ToInt32(sRow.PK_SOURCE));
                    currentCustomer.name = sRow.NAME_;
                    currentCustomer.address = sRow.ADDRESSS;

                    User.sources.Add(currentCustomer);
                }


        }



       /// <summary>
       /// Загрузка всех выставок
       /// </summary>
        public static void load_exhibitions()
        {

            User.exhibitions = new List<Exhibition>();

            DataSet1TableAdapters.EXHIBITIONTableAdapter exponatTableAdapter = new DataSet1TableAdapters.EXHIBITIONTableAdapter();


            DataSet1.EXHIBITIONDataTable customerData = exponatTableAdapter.GetData();


            foreach (DataSet1.EXHIBITIONRow customerRow in customerData)
            {
                Exhibition currentCustomer = new Exhibition();

                //Ключи и неотражаемая в гриде ересь
                currentCustomer.setPkExhibition(Convert.ToInt32(customerRow.PK_EXHIBITION));



                //Просто отображаемые части
                currentCustomer.datestart = customerRow.DATESTART;
                currentCustomer.dateend = customerRow.DATEEND;
                currentCustomer.name = customerRow.NAME_;


                /*
                    //ОПАСНОЕ ВПЛЕТЕНИЕ ИСТОЧНИКА
                DataSet1TableAdapters.SOURCETableAdapter ta = new DataSet1TableAdapters.SOURCETableAdapter();


                DataSet1.SOURCEDataTable dt = ta.HitlerSource(currentCustomer.getPkSource());

                foreach (DataSet1.SOURCERow sRow in dt)
                {
                    currentCustomer.sourceValue = sRow.NAME_;
                }

                */

               

                    User.exhibitions.Add(currentCustomer);
                



            }

        }


        /// <summary>
        /// Загрузка всех источников
        /// </summary>
        public static void load_sources()
        {
            //Обнуляем
            User.sources = new List<Sauce>();
            DataSet1TableAdapters.SOURCETableAdapter sourceTableAdapter = new DataSet1TableAdapters.SOURCETableAdapter();

            DataSet1.SOURCEDataTable sourceData = sourceTableAdapter.GetData();

            foreach (DataSet1.SOURCERow srcRow in sourceData)
            {
                //Создаем новый источник
                Sauce currentSRC = new Sauce();

                //Первичный ключ
                currentSRC.setPkSource(Convert.ToInt32(srcRow.PK_SOURCE));

                //Данные
                currentSRC.address = srcRow.ADDRESSS;
                currentSRC.name = srcRow.NAME_;
                
                //Добавлеяем в список Источник
                User.sources.Add(currentSRC);
            }
        }

        /// <summary>
        /// Загрузка всех экспонатов
        /// </summary>
        public static void load_exponats(){
            //Обнулили
            User.exponats = new List<Exponat>();
            DataSet1TableAdapters.EXPONATTableAdapter exponatTableAdapter = new DataSet1TableAdapters.EXPONATTableAdapter();
            DataSet1.EXPONATDataTable customerData = exponatTableAdapter.GetData();
            foreach (DataSet1.EXPONATRow customerRow in customerData)
            {
                Exponat currentCustomer = new Exponat();

                //Ключи и неотражаемая в гриде ересь
                currentCustomer.setPkExponat(Convert.ToInt32(customerRow.PK_EXPONAT));
                currentCustomer.setPkSource (Convert.ToInt32(customerRow.PK_SOURCE));
                currentCustomer.setPkCategoryExp(Convert.ToInt32(customerRow.PK_CATEGORYEXPONAT));
                currentCustomer.setPkCategoryAut(Convert.ToInt32(customerRow.PK_CATEGORYAUTHOR));
                currentCustomer.setPkCategoryAud(Convert.ToInt32(customerRow.PK_CATEGORYAUDITORY));
                currentCustomer.setPkType(Convert.ToInt32(customerRow.PK_TYPE));

                currentCustomer.setFlag(Convert.ToInt32(customerRow.FLAG));
                currentCustomer.setDescr(customerRow.DESCR);
                currentCustomer.setFio(customerRow.FIO);
                currentCustomer.setPic(customerRow.PICREFERENCE);


                //Нужен перевод в строковую форму
                currentCustomer.setTypeSob(Convert.ToInt32(customerRow.TYPESOB));
                currentCustomer.typeSobStr = User.typeSobString[currentCustomer.getTypeSob()];
                currentCustomer.setPlace(Convert.ToInt32(customerRow.PLACE_));
                currentCustomer.placeStr = User.placeString[currentCustomer.getPlace()];
                currentCustomer.setDamage(Convert.ToInt32(customerRow.DAMAGE));
                currentCustomer.damageStr = User.damageString[currentCustomer.getDamage()];

                //currentCustomer.sourceValue ="";
                //ВПЛЕТЕНИЕ ИСТОЧНИКА
                DataSet1TableAdapters.SOURCETableAdapter ta = new DataSet1TableAdapters.SOURCETableAdapter();


                DataSet1.SOURCEDataTable dt = ta.HitlerSource(currentCustomer.getPkSource());

                foreach (DataSet1.SOURCERow sRow in dt)
                {
                    currentCustomer.sourceValue=sRow.NAME_;
                }


                //Просто отображаемые части
                currentCustomer.date = customerRow.DATE_GET;
                currentCustomer.inumber=customerRow.INUMBER;
                currentCustomer.name = customerRow.NAME_;
                currentCustomer.price = Convert.ToDouble(customerRow.PRICE_);
                

                //ПРОВЕРКА,ЧТО НЕ СПИСАН???А НАДО?
                if (currentCustomer.getFlag()==0)
                {
                    User.exponats.Add(currentCustomer);
               }
                
              

            }
        }


        /// <summary>
        /// Загрузка Экспоната по ПК
        /// </summary>
        public static void load_exponatsp(int pk)
        {
            //Обнулили
            User.exponats = new List<Exponat>();
            DataSet1TableAdapters.EXPONATTableAdapter exponatTableAdapter = new DataSet1TableAdapters.EXPONATTableAdapter();
            DataSet1.EXPONATDataTable customerData = exponatTableAdapter.GetExponatByPk(pk);
            foreach (DataSet1.EXPONATRow customerRow in customerData)
            {
                Exponat currentCustomer = new Exponat();

                //Ключи и неотражаемая в гриде ересь
                currentCustomer.setPkExponat(Convert.ToInt32(customerRow.PK_EXPONAT));
                currentCustomer.setPkSource(Convert.ToInt32(customerRow.PK_SOURCE));
                currentCustomer.setPkCategoryExp(Convert.ToInt32(customerRow.PK_CATEGORYEXPONAT));
                currentCustomer.setPkCategoryAut(Convert.ToInt32(customerRow.PK_CATEGORYAUTHOR));
                currentCustomer.setPkCategoryAud(Convert.ToInt32(customerRow.PK_CATEGORYAUDITORY));
                currentCustomer.setPkType(Convert.ToInt32(customerRow.PK_TYPE));

                currentCustomer.setFlag(Convert.ToInt32(customerRow.FLAG));
                currentCustomer.setDescr(customerRow.DESCR);
                currentCustomer.setFio(customerRow.FIO);
                currentCustomer.setPic(customerRow.PICREFERENCE);


                //Нужен перевод в строковую форму
                currentCustomer.setTypeSob(Convert.ToInt32(customerRow.TYPESOB));
                currentCustomer.typeSobStr = User.typeSobString[currentCustomer.getTypeSob()];
                currentCustomer.setPlace(Convert.ToInt32(customerRow.PLACE_));
                currentCustomer.placeStr = User.placeString[currentCustomer.getPlace()];
                currentCustomer.setDamage(Convert.ToInt32(customerRow.DAMAGE));
                currentCustomer.damageStr = User.damageString[currentCustomer.getDamage()];

                //currentCustomer.sourceValue ="";
                //ВПЛЕТЕНИЕ ИСТОЧНИКА
                DataSet1TableAdapters.SOURCETableAdapter ta = new DataSet1TableAdapters.SOURCETableAdapter();


                DataSet1.SOURCEDataTable dt = ta.HitlerSource(currentCustomer.getPkSource());

                foreach (DataSet1.SOURCERow sRow in dt)
                {
                    currentCustomer.sourceValue = sRow.NAME_;
                }


                //Просто отображаемые части
                currentCustomer.date = customerRow.DATE_GET;
                currentCustomer.inumber = customerRow.INUMBER;
                currentCustomer.name = customerRow.NAME_;
                currentCustomer.price = Convert.ToDouble(customerRow.PRICE_);


                //ПРОВЕРКА,ЧТО НЕ СПИСАН???А НАДО?
                if (currentCustomer.getFlag() == 0)
                {
                    User.exponats.Add(currentCustomer);
                }



            }
        }





    }
}
