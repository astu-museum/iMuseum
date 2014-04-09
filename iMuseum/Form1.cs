using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationControls;

namespace iMuseum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Добавление нового экспоната
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewExp(object sender, EventArgs e)
        {

         

            Form2 f2 = new Form2();
            f2.ShowDialog();


            //Вдруг доабвили что-то подходящее под фильтр?Надо вывести
            Load_Exponats();

        }
        /// <summary>
        /// Подробнее об экспонате
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void infoExp(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void setFilter(object sender, EventArgs e)
        {
            Filter fltr = new Filter();
            fltr.ShowDialog();

            //Вновь пофильтруем
            Load_Exponats();
        }

        private void showExib(object sender, EventArgs e)
        {
            Exibition exb = new Exibition();
            exb.ShowDialog();
        }

        private void showSources(object sender, EventArgs e)
        {
            Source src = new Source();
            src.ShowDialog();
        }

        private void searchSett(object sender, EventArgs e)
        {
            mainSettings mst = new mainSettings();
            mst.ShowDialog();
        }

        /// <summary>
        /// Производит загружку всех экспонатов и фильтрует по заданному фильтру
        /// </summary>
        private void Load_Exponats()
        {
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
                currentCustomer.name = customerRow.DESCR;
                currentCustomer.price = Convert.ToDouble(customerRow.PRICE_);
                

                //ПРОВЕРКА,ЧТО НЕ СПИСАН???А НАДО?
                if (currentCustomer.getFlag()==0)
                {
                    User.exponats.Add(currentCustomer);
               }
                
              

            }


            //ТУТ ДЕЛАЕМ ФИЛЬТРЕЦ

            dataGridView1.DataSource = null;

            number.DataPropertyName = "inumber";
            title.DataPropertyName = "name";
            source.DataPropertyName = "sourceValue";
            date.DataPropertyName = "date";
            typesob.DataPropertyName = "typeSobStr";
            mesto.DataPropertyName = "placeStr";
            damage.DataPropertyName = "damageStr";
            price.DataPropertyName = "price";


            dataGridView1.DataSource = User.exponats;
          

        }

        private void Form1_Load(object sender, EventArgs e)
        {



            Load_Exponats();

         
          

           
        }
    }
}
