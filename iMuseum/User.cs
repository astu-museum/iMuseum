﻿using System;
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


        //Строковые представления того,что хранися в виде Интовых Чисел
        public static List<string> typeSobString = new List<string>(5) { "Собственность музея","На временном пользовании"};
        public static List<string> placeString = new List<string>(5) { "Выставка", "Резерв","На хранении у стороненго лица" };
        public static List<string> damageString = new List<string>(5) { "Отличное", "Хорошее","Удовлетворительное","Неудовлетворительное" };
        public static List<string> numberString = new List<string>(5) {"Категория экспоната", "Категория автора", "Целевая аудитория" };

        //Создадим адаптер,шоб шифроваться
        public static DataSet1.SOURCEDataTable dtrip;

        //FILTER
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
                    for (int j = 0; (j < categoryAuditoryFilter.Count) && !flag; j++)
                    {
                        if (exponats[i].getPkCategoryAud() == categoryAuditoryFilter[j])
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





            }

        }


        //Загузка всех экснатв
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
                //ОПАСНОЕ ВПЛЕТЕНИЕ ИСТОЧНИКА
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
