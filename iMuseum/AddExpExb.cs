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

        //Параметры для передачи

        public AddExpExb()
        {
            InitializeComponent();
        }

        private void search(object sender, EventArgs e)
        {
  
            sourceSettings srccc = new sourceSettings();
            srccc.ShowDialog();

        }


        private void Load_some()
        {

        

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

            for (int i = 0; i < User.Checks.Count; i++)
            {
                dataGridView1.Rows[User.Checks[i]].Cells[0].Value = true;
            }


        }
        

        private void AddExpExb_Load(object sender, EventArgs e)
        {
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
