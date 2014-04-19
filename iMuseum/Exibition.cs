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
    public partial class Exibition : Form
    {


        DataSet1.EXHIBITIONDataTable texh;

        public Exibition()
        {
            InitializeComponent();
        }

        private void showDetails(object sender, EventArgs e)
        {
            //Передадим первичник нужной выставки
            int t = Convert.ToInt32(texh.Rows[listBox1.SelectedIndex]["pk_exhibition"].ToString());
            ExbDetails exbdt = new ExbDetails(t);

           
           // MessageBox.Show(t.ToString());

            exbdt.ShowDialog();
            Load_Exh();
        }

        private void addExb(object sender, EventArgs e)
        {
            AddExib addex = new AddExib();
            addex.ShowDialog();
            Load_Exh();
        }

        //начальная загрузка
        void Load_Exh()
        {
            

            DataSet1TableAdapters.EXHIBITIONTableAdapter exhTableAdapter = new DataSet1TableAdapters.EXHIBITIONTableAdapter();

            texh = exhTableAdapter.GetData();



            listBox1.DataSource = texh;
            listBox1.ValueMember = "NAME_";
            listBox1.BindingContext = this.BindingContext;


        }

        private void Exibition_Load(object sender, EventArgs e)
        {

            Load_Exh();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрана выставка для удаления");
                return;

            }

            try
            {
                int p = listBox1.SelectedIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбрана строка для удаления");
                return;
            }


            int t = Convert.ToInt32(texh.Rows[listBox1.SelectedIndex]["pk_exhibition"].ToString());

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            DataSet1TableAdapters.EXHIBITIONTableAdapter regionTableAdapter = new DataSet1TableAdapters.EXHIBITIONTableAdapter();

            regionTableAdapter.DeleteQuery(t);




            Load_Exh();
        }
    }
}
