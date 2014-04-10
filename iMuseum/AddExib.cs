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
    public partial class AddExib : Form
    {

        DataSet1.CATEGORYDataTable catexp;
        DataSet1.CATEGORYDataTable cataut;
        DataSet1.CATEGORYDataTable cataud;
        
        DataSet1.TYPEEXPONATDataTable texp;

        List<int> ex;
        List<int> av;
        List<int> ad;
        List<int> ty;

        public AddExib()
        {
            InitializeComponent();
        }

        private void forming(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поле Наименование");
                return;
            }

            for (int i = 0; i < textBox1.Text.Length; i++)
            {

                if (((textBox1.Text[i] < 'а') || (textBox1.Text[i] > 'я')) && ((textBox1.Text[i] < 'А') || (textBox1.Text[i] > 'Я')) && (textBox1.Text[i] != ' ') && (textBox1.Text[i] != '-') && ((textBox1.Text[i] < '0') || (textBox1.Text[i] > '9')))
                {
                    MessageBox.Show("Наименование содержит только  буквы,цифры,тире и пробелы");
                    return;

                }
            }




            AddExpExb aee = new AddExpExb();
            aee.ShowDialog();
        }

        void LoadSome()
        {
            ex = new List<int>();
            av = new List<int>();
            ad = new List<int>();
            ty = new List<int>();

            //АВТОРОКАТЕГОРИЯ
            DataSet1TableAdapters.CATEGORYTableAdapter cta = new DataSet1TableAdapters.CATEGORYTableAdapter();


            cataut = cta.GetDataAut();


            foreach (DataSet1.CATEGORYRow dr in cataut.Rows)
            {


                checkBoxComboBox2.Items.Add(dr.NAME_);


                int p = Convert.ToInt32(dr.PK_CATEGORY);

                /*
                //ВЫСТАВИМ ЧЕКИ
                for (int i = 0; i < User.categoryAuthorFilter.Count; i++)
                {
                    if (User.categoryAuthorFilter[i] == p)
                    {
                        checkBoxComboBox2.CheckBoxItems[checkBoxComboBox2.CheckBoxItems.Count - 1].Checked = true;
                    }
                }
                 * */

                av.Add(p);
            }


            //AUDITROY
            DataSet1TableAdapters.CATEGORYTableAdapter cto = new DataSet1TableAdapters.CATEGORYTableAdapter();


            cataud = cto.GetDataAud();


            foreach (DataSet1.CATEGORYRow dr in cataud.Rows)
            {

                checkBoxComboBox3.Items.Add(dr.NAME_);

                int p = Convert.ToInt32(dr.PK_CATEGORY);

                /*
                //ВЫСТАВИМ ЧЕКИ
                for (int i = 0; i < User.categoryAuditoryFilter.Count; i++)
                {
                    if (User.categoryAuditoryFilter[i] == p)
                    {
                        checkBoxComboBox3.CheckBoxItems[checkBoxComboBox3.CheckBoxItems.Count - 1].Checked = true;
                    }
                }*/


                ad.Add(p);
            }

            //EXPONAT
            DataSet1TableAdapters.CATEGORYTableAdapter cte = new DataSet1TableAdapters.CATEGORYTableAdapter();


            catexp = cte.GetDataExp();


            foreach (DataSet1.CATEGORYRow dr in catexp.Rows)
            {
                checkBoxComboBox1.Items.Add(dr.NAME_);


                int p = Convert.ToInt32(dr.PK_CATEGORY);

                /*
                //ВЫСТАВИМ ЧЕКИ
                for (int i = 0; i < User.categoryExponatFilter.Count; i++)
                {
                    if (User.categoryExponatFilter[i] == p)
                    {
                        checkBoxComboBox1.CheckBoxItems[checkBoxComboBox1.CheckBoxItems.Count - 1].Checked = true;
                    }
                }*/


                ex.Add(p);
            }

            //TYPE

            DataSet1TableAdapters.TYPEEXPONATTableAdapter tta = new DataSet1TableAdapters.TYPEEXPONATTableAdapter();


            texp = tta.GetData();


            foreach (DataSet1.TYPEEXPONATRow dr in texp.Rows)
            {
                objectTypeCB.Items.Add(dr.NAME_);

                int p = (Convert.ToInt32(dr.PK_TYPE));

                /*
                //ВЫСТАВИМ ЧЕКИ
                for (int i = 0; i < User.typeFilter.Count; i++)
                {
                    if (User.typeFilter[i] == p)
                    {
                        objectTypeCB.CheckBoxItems[objectTypeCB.CheckBoxItems.Count - 1].Checked = true;
                    }
                }*/

                ty.Add(p);
            }

       


        }

        private void AddExib_Load(object sender, EventArgs e)
        {
            LoadSome();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
