using System;
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

        public AddExpExb()
        {
            InitializeComponent();
        }

        private void search(object sender, EventArgs e)
        {
  
            User.exponats = new List<Exponat>(saveExp);
            User.Checks = new List<int>(saveCheck);


            sourceSettings srccc = new sourceSettings();
            srccc.ShowDialog();

           User.find_exponats_exhibition();
           Load_some();
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
               // MessageBox.Show("dafaq");
                dataGridView1.Rows[i].Cells[0].Value = false;
            }
  
            for (int i = 0; i < User.Checks.Count; i++)
            {
              //  MessageBox.Show("maniga");
                dataGridView1.Rows[User.Checks[i]].Cells[0].Value = true;
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

            Load_some();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count;i++ )
            {

                if (dataGridView1.Rows[i].Cells[0].Value != null && (bool)dataGridView1.Rows[i].Cells[0].Value)
                {
                  //  MessageBox.Show(i.ToString());

                    User.exhibitions[0].addExponat(User.exponats[i].getPkExponat());
                  //  MessageBox.Show(User.exponats[i].name);
                }
            }

            User.exhibitions[0].save();
            this.Close();
        }
    }
}
