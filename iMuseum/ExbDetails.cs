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
    public partial class ExbDetails : Form
    {
        int pk;

        public ExbDetails()
        {
            InitializeComponent();
            pk = 0;
        }

        public ExbDetails(int pk1)
        {
            InitializeComponent();
            pk = pk1;
        }

        private void addEE(object sender, EventArgs e)
        {

         
            //ОТСЕЧЬ ИМЕЮЩИЕСЯ

            User.load_exponats();
            User.filterExh();
            //ОТСЕКАЕМ ИМЕЮЩКИ
            User.exhibitions[0].getExponats().Clear();

            User.Checks.Clear();


            AddExpExb aee = new AddExpExb();
            aee.ShowDialog();


            

            Load_Some();
            Anothre();
            
        }

        void Load_Some()
        {
            User.load_exhibitionsp(pk);

            label1.Text = User.exhibitions[0].name;
            this.Text = label1.Text;

            string startday, endday, startmonth, endmonth;

            //Вычисляем номера дня месяца
            if (User.exhibitions[0].datestart.Day < 10)
                startday = "0" + User.exhibitions[0].datestart.Day;
            else startday = User.exhibitions[0].datestart.Day.ToString();

            if (User.exhibitions[0].dateend.Day < 10)
                endday = "0" + User.exhibitions[0].dateend.Day;
            else endday = User.exhibitions[0].dateend.Day.ToString();

            //Вычисляем номера месяца
            if (User.exhibitions[0].datestart.Month < 10)
                startmonth = "0" + User.exhibitions[0].datestart.Month;
            else startmonth = User.exhibitions[0].datestart.Month.ToString();

            if (User.exhibitions[0].dateend.Month < 10)
                endmonth = "0" + User.exhibitions[0].dateend.Month;
            else endmonth = User.exhibitions[0].dateend.Month.ToString();

            //Отображаем период проведения выставки
            label2.Text = startday + "." + startmonth + "." + User.exhibitions[0].datestart.Year +
                        " - " + endday + "." + endmonth + "." + User.exhibitions[0].dateend.Year;
            label3.Text = "Категории выставки:";

            for (int i = 0; i < User.exhibitions[0].getCnames().Count; i++)
            {
                label3.Text+=User.exhibitions[0].getCnames()[i];
                 label3.Text+=", ";

            }

        }

        //Закидываем все экспонато-ключи в выставку
        void evil_Filler()
        {

            User.exhibitions[0].getExponats().Clear();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                User.exhibitions[0].addExponat(Convert.ToInt32(dataGridView1.Rows[i].Cells["a"].Value));
              //  MessageBox.Show(Convert.ToInt32(dataGridView1.Rows[i].Cells["a"].Value).ToString());
            }

        }

        void Anothre()
        {
            DataSet1TableAdapters.EXPONATTableAdapter ta = new DataSet1TableAdapters.EXPONATTableAdapter();

       

         //  a.DataPropertyName = "tt";

            DataTable dt = ta.FC(pk);



            title.DataPropertyName = "name";
            categoryexp.DataPropertyName = "aa";
            autcat.DataPropertyName = "aut";
            audcat.DataPropertyName = "q";
            typeexp.DataPropertyName = "aaa";
            //damae.DataPropertyName = "ee";
            a.DataPropertyName = "pk_exponat";
            b.DataPropertyName = "pk_categoryexponat";
            c.DataPropertyName = "pk_categoryauthor";
            d.DataPropertyName = "pk_categoryauditory";
            e.DataPropertyName = "pk_source";
            f.DataPropertyName = "pk_type";
            aa.DataPropertyName = "inumber";
            ab.DataPropertyName = "price_";
            ac.DataPropertyName = "date_get";
            ad.DataPropertyName = "typesob";
            ae.DataPropertyName = "descr";
            af.DataPropertyName = "place_";
            ba.DataPropertyName = "fio";
            bb.DataPropertyName = "picreference";
            bc.DataPropertyName = "flag";
           bd.DataPropertyName = "name_";
           be.DataPropertyName = "damage";
            bf.DataPropertyName = "ee";

            dataGridView1.DataSource = dt;

           // string asdasdas="";
         //  damae.ValueType = typeof(System.String);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

               
                //dataGridView1.Rows[i].Cells["damae"].Value = 14;

               dataGridView1.Rows[i].Cells["damae"].Value = (User.damageString[Convert.ToInt32(dataGridView1.Rows[i].Cells["bf"].Value.ToString())]).ToString();
            }

            evil_Filler();


            /*
            foreach (DataSet1.EXPONATRow aRow in dt)
            {
                currentCustomer.sourceValue = aRow.NAME_;
            }*/
        }

        private void ExbDetails_Load(object sender, EventArgs e)
        {
           

            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.CATEGORY". При необходимости она может быть перемещена или удалена.
            //this.cATEGORYTableAdapter.Fill(this.dataSet1.CATEGORY.);
            Load_Some();
            Anothre();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 100, dataGridView1.Size.Height + 100);
          //  bmp = new Bitmap(

            Rectangle cs = new Rectangle(100,200,dataGridView1.Width+500,dataGridView1.Height+500);

            cs = new Rectangle(new Point(0, 0), new Size(dataGridView1.Width + 500, dataGridView1.Height + 500));
            this.DrawToBitmap(bmp,cs);

         //   dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
             
            e.Graphics.DrawImage(bmp,0,0);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button3_Click(object sender, EventArgs e)
        {


      
                try
                {
                    int p = dataGridView1.SelectedCells[0].RowIndex;

                }
                catch(Exception ff){
                   
                    MessageBox.Show("Не выбрана строка для удаления");
                    return;
                }

                if (MessageBox.Show("УДАЛИТЬ ЗАПИСЬ", "УДАЛЕНИЕ", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }


                DataSet1TableAdapters.CATEGORYEXPONATTableAdapter regionTableAdapter =
                new DataSet1TableAdapters.CATEGORYEXPONATTableAdapter();




                regionTableAdapter.DeleteCatExp(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["a"].Value, User.exhibitions[0].getPkExhibition());


                // User.exponats[dataGridView1.SelectedCells[0].RowIndex].delete_();


                Load_Some();
                Anothre();
       
        }


    }
}
