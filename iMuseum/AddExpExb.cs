using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iMuseum
{
    public partial class AddExpExb : Form
    {

       

        //Параметры для сохранения
        List<Exponat> saveExp;
        List<int> saveCheck;

        //СЕКРЕТНЫЙ ЧЕКО САВЕР
        Hashtable mapPk = new Hashtable();


        public AddExpExb()
        {
            InitializeComponent();
        }

        private void search(object sender, EventArgs e)
        {

            

            Check_Load();


  
            User.exponats = new List<Exponat>(saveExp);
          //  User.Checks = new List<int>(saveCheck);

         

            sourceSettings srccc = new sourceSettings();
            srccc.ShowDialog();

           User.find_exponats_exhibition();
           //Load_some();
           Load_Other();
        }



        //СУПЕР ЗАГРУЗКА ЧЕКОВ
        void Check_Load()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                //  MessageBox.Show(User.exponats[i].getPkExponat().ToString());

                if (dataGridView1.Rows[i].Cells[0].Value != null && (bool)dataGridView1.Rows[i].Cells[0].Value)
                {
                    mapPk[User.exponats[i].getPkExponat()] = true;
                    //  MessageBox.Show(User.exponats[i].getPkExponat().ToString());
                }
                else
                {
                    mapPk[User.exponats[i].getPkExponat()] = false;

                }
            }
        }

        //Загрузка после поиска
        private void Load_Other()
        {
            title.DataPropertyName = "name";
            mesto.DataPropertyName = "placeStr";
            damage.DataPropertyName = "damageStr";
            price.DataPropertyName = "price";


            a.DataPropertyName = "inumber";
            b.DataPropertyName = "sourceValue";
            c.DataPropertyName = "date";
            d.DataPropertyName = "typeSobStr";


            dataGridView1.DataSource = User.exponats;//User.exponats;



            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                dataGridView1.Rows[i].Cells[0].Value = false;

            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                

                    dataGridView1.Rows[i].Cells[0].Value = mapPk[User.exponats[i].getPkExponat()];
          

            }


        }
     

        private void Load_some()
        {
         //   MessageBox.Show(User.exponats.Count.ToString());

           // dataGridView1.DataSource = null;

            

           // List<Exponat> ls = User.exponats;
            title.DataPropertyName = "name";
            mesto.DataPropertyName = "placeStr";
            damage.DataPropertyName = "damageStr";
            price.DataPropertyName = "price";


            a.DataPropertyName = "inumber";
            b.DataPropertyName = "sourceValue";
            c.DataPropertyName = "date";
            d.DataPropertyName = "typeSobStr";


            dataGridView1.DataSource = User.exponats;//User.exponats;

         //   if (User.exponats.Count != 0)
          //  {
          

             
          //  }
             //   MessageBox.Show(dataGridView1.Rows.Count.ToString());


             //  MessageBox.Show(  dataGridView1.Rows.Count.ToString());

            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
             
                dataGridView1.Rows[i].Cells[0].Value = false;


                //Внулим все чеки
                mapPk.Add(User.exponats[i].getPkExponat(), false);
            }
  
            for (int i = 0; i < User.Checks.Count; i++)
            {
            

                dataGridView1.Rows[User.Checks[i]].Cells[0].Value = true;


                //ПРоставим некоторые чеки

              //  mapPk[User.exponats[User.Checks[i]].getPkExponat()] = true;
            }


        }
        

        private void AddExpExb_Load(object sender, EventArgs e)
        {
            User.name0 = "";
            User.pricefrom = -1;
            User.priceto = -1;
            User.damage0 = -1;
            User.place0 = -1;

            saveExp = new List<Exponat>(User.exponats);
            saveCheck = new List<int>(User.Checks);

            //НАДО ПОМНИТЬ ВСЕ ЧЕКИ ПО ПК ЭКСПОНАТА

            Load_some();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* for (int i = 0; i < dataGridView1.Rows.Count;i++ )
            {

                if (dataGridView1.Rows[i].Cells[0].Value != null && (bool)dataGridView1.Rows[i].Cells[0].Value)
                {
                  //  MessageBox.Show(i.ToString());

                    User.exhibitions[0].addExponat(User.exponats[i].getPkExponat());
                  //  MessageBox.Show(User.exponats[i].name);
                }
            }*/

            Check_Load();



            foreach (DictionaryEntry de in mapPk)
            {
                if((bool)de.Value){
                    User.exhibitions[0].addExponat((int)de.Key);
                }

           //     Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }




                User.exhibitions[0].save();
            this.Close();
        }
    }
}
