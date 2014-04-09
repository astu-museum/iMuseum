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
        public static List<Type> typeFilter;
        public static List<Category> categoryExponatFilter;
        public static List<Category> categoryAuthorFilter;
        public static List<Category> categoryAuditoryFilter;


        //Строковые представления того,что хранися в виде Интовых Чисел
        public static List<string> typeSobString = new List<string>(5) { "Собственность музея","На временном пользовании"};
        public static List<string> placeString = new List<string>(5) { "Выставка", "Резерв","На хранении у стороненго лица" };
        public static List<string> damageString = new List<string>(5) { "Отличное", "Хорошее","Удовлетворительное","Неудовлетворительное" };
        public static List<string> numberString = new List<string>(5) {"Категория экспоната", "Категория автора", "Целевая аудитория" };

        //Создадим адаптер,шоб шифроваться
        public static DataSet1.SOURCEDataTable dtrip;
    }
}
