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
    public partial class Filter : Form
    {
        public Filter()
        {
           
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
          
            //FILL ARRAYS OF FILTER


            User.typeFilter.Clear();
            User.categoryExponatFilter.Clear();
            User.categoryAuthorFilter.Clear();
            User.categoryAuditoryFilter.Clear();


            for (int i = 1; i < checkBoxComboBox1.Items.Count; i++)
            {
               // MessageBox.Show(checkBoxComboBox1.Items[i].ToString());
                  if (checkBoxComboBox1.CheckBoxItems[i].Checked)
                  {
                      User.categoryExponatFilter.Add(ex[i-1]);
                  }
               

            }

            
            for (int i = 1; i < checkBoxComboBox2.Items.Count; i++)
            {
               
              //  MessageBox.Show(checkBoxComboBox2.Items[i].ToString());
                if (checkBoxComboBox2.CheckBoxItems[i].Checked)
                {
                    User.categoryAuthorFilter.Add(av[i-1]);
                }
        

            }

            
            for (int i = 1; i < checkBoxComboBox3.Items.Count; i++)
            {
                if (checkBoxComboBox3.CheckBoxItems[i].Checked)
                {
                    User.categoryAuditoryFilter.Add(ad[i-1]);
                }


            }


            for (int i = 1; i < objectTypeCB.Items.Count; i++)
            {
                if (objectTypeCB.CheckBoxItems[i].Checked)
                {
                    User.typeFilter.Add(ty[i-1]);
                }


            }


            this.Close();




          
        }


        DataSet1.CATEGORYDataTable catexp;
        DataSet1.CATEGORYDataTable cataut;
        DataSet1.CATEGORYDataTable cataud;


        
        DataSet1.TYPEEXPONATDataTable texp;


        //Левак для ключей
        List<int> ex;
        List<int> av;
        List<int> ad;
        List<int> ty;

        void LoadSome()
        {
           ex = new List<int>(); 
             av = new List<int>(); 
             ad = new List<int>();
             ty = new List<int>();
           
            //АВТОРОКАТЕГОРИЯ
            DataSet1TableAdapters.CATEGORYTableAdapter cta = new DataSet1TableAdapters.CATEGORYTableAdapter();

            
            cataut = cta.GetDataAut();


            foreach (DataSet1.CATEGORYRow  dr in cataut.Rows) {

               
                checkBoxComboBox2.Items.Add(dr.NAME_);

           
                int p = Convert.ToInt32(dr.PK_CATEGORY);
               
                //ВЫСТАВИМ ЧЕКИ
                for(int i =0;i < User.categoryAuthorFilter.Count;i++){
                    if(User.categoryAuthorFilter[i]==p){
                        checkBoxComboBox2.CheckBoxItems[checkBoxComboBox2.CheckBoxItems.Count-1].Checked = true;
                    }
                }
                    
                av.Add(p);
            }

          
            //AUDITROY
            DataSet1TableAdapters.CATEGORYTableAdapter cto = new DataSet1TableAdapters.CATEGORYTableAdapter();


            cataud = cto.GetDataAud();


            foreach (DataSet1.CATEGORYRow dr in cataud.Rows)
            {
              
                checkBoxComboBox3.Items.Add(dr.NAME_);

                int p = Convert.ToInt32(dr.PK_CATEGORY);


                //ВЫСТАВИМ ЧЕКИ
                for (int i = 0; i < User.categoryAuditoryFilter.Count; i++)
                {
                    if (User.categoryAuditoryFilter[i] == p)
                    {
                        checkBoxComboBox3.CheckBoxItems[checkBoxComboBox3.CheckBoxItems.Count - 1].Checked = true;
                    }
                }


                ad.Add(p);
            }

            //EXPONAT
            DataSet1TableAdapters.CATEGORYTableAdapter cte = new DataSet1TableAdapters.CATEGORYTableAdapter();


            catexp = cte.GetDataExp();


            foreach (DataSet1.CATEGORYRow dr in catexp.Rows)
            {
                checkBoxComboBox1.Items.Add(dr.NAME_);


                int p = Convert.ToInt32(dr.PK_CATEGORY);

                //ВЫСТАВИМ ЧЕКИ
                for (int i = 0; i < User.categoryExponatFilter.Count; i++)
                {
                    if (User.categoryExponatFilter[i] == p)
                    {
                        checkBoxComboBox1.CheckBoxItems[checkBoxComboBox1.CheckBoxItems.Count - 1].Checked = true;
                    }
                }


                ex.Add(p);
            }

            //TYPE

            DataSet1TableAdapters.TYPEEXPONATTableAdapter tta = new DataSet1TableAdapters.TYPEEXPONATTableAdapter();


            texp = tta.GetData();


            foreach (DataSet1.TYPEEXPONATRow dr in texp.Rows)
            {
               objectTypeCB.Items.Add(dr.NAME_);

                int p = (Convert.ToInt32(dr.PK_TYPE));

                //ВЫСТАВИМ ЧЕКИ
                for (int i = 0; i < User.typeFilter.Count; i++)
                {
                    if (User.typeFilter[i] == p)
                    {
                        objectTypeCB.CheckBoxItems[objectTypeCB.CheckBoxItems.Count - 1].Checked = true;
                    }
                }

                ty.Add(p);
            }

       
        
            

        }

        //ОЧИСТИМ СОРТИРОВОЧНЫЕ МАССИВ
        private void button1_Click(object sender, EventArgs e)
        {
           
             User.typeFilter.Clear();
      User.categoryExponatFilter.Clear();
       User.categoryAuthorFilter.Clear();
        User.categoryAuditoryFilter.Clear();


            for(int i= 0;i < checkBoxComboBox1.Items.Count;i++){
       
                checkBoxComboBox1.CheckBoxItems[i].Checked = false;

            }

            for (int i = 0; i < checkBoxComboBox2.Items.Count; i++)
            {
               
                checkBoxComboBox2.CheckBoxItems[i].Checked = false;

            }

            for (int i = 0; i < checkBoxComboBox3.Items.Count; i++)
            {

                checkBoxComboBox3.CheckBoxItems[i].Checked = false;

            }

            for (int i = 0; i < objectTypeCB.Items.Count; i++)
            {

                objectTypeCB.CheckBoxItems[i].Checked = false;

            }

          //  this.Close();


        


        }

        private void Filter_Load(object sender, EventArgs e)
        {
            
            //Проведём выгрузку всей ереси
            LoadSome();
        }

        private void cATEGORYBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
