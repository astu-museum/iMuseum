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

        //Фил


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

        //ВЫГРЗУКА ВЫСТАВКИ в ex0 ДЛЯ просмотра инфы о выставке 
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


        //Загрузка всех выставок
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
            

            //вытаскиваем
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




    }
}
