using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

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
            }

        }

        void Anothre()
        {
            DataSet1TableAdapters.EXPONATTableAdapter ta = new DataSet1TableAdapters.EXPONATTableAdapter();

            DataTable dt = ta.FC(pk);

            title.DataPropertyName = "name";
            categoryexp.DataPropertyName = "aa";
            autcat.DataPropertyName = "aut";
            audcat.DataPropertyName = "q";
            typeexp.DataPropertyName = "aaa";
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

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
               dataGridView1.Rows[i].Cells["damae"].Value = (User.damageString[Convert.ToInt32(dataGridView1.Rows[i].Cells["bf"].Value.ToString())]).ToString();
            }

            evil_Filler();
        }

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExbDetails_Load(object sender, EventArgs e)
        {
            Load_Some();
            Anothre();
        }


        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                if (MessageBox.Show("Удалить экспонат?", "Удаление экспоната из выставки", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }


                DataSet1TableAdapters.CATEGORYEXPONATTableAdapter regionTableAdapter =
                new DataSet1TableAdapters.CATEGORYEXPONATTableAdapter();

                regionTableAdapter.DeleteCatExp(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["a"].Value, User.exhibitions[0].getPkExhibition());

                Load_Some();
                Anothre();
       
        }

        /// <summary>
        /// Вызов печати
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printExb(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
                printMethod(); 
        }

        /// <summary>
        /// Печать
        /// </summary>
        private void printMethod()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet = (Excel.Worksheet)xlApp.Worksheets[1];
                xlWorkSheet.Cells.ColumnWidth = 13;
                xlWorkSheet.Cells.Font.Size = 8;
                int i = 0;

                xlWorkSheet.Cells[1, 1] = "Выставка:";
                xlWorkSheet.Cells[1, 2] = this.Text;
                xlWorkSheet.Cells[2, 1] = "Дата начала:";
                xlWorkSheet.Cells[2, 2] = label2.Text.Substring(0, 10);
                xlWorkSheet.Cells[3, 1] = "Дата окончания:";
                xlWorkSheet.Cells[3, 2] = label2.Text.Substring(13);

                xlWorkSheet.Cells[5, 1] = "Наименование";
                xlWorkSheet.Cells[5, 2] = "Тип экспоната";
                xlWorkSheet.Cells[5, 3] = "Категория автора";
                xlWorkSheet.Cells[5, 4] = "Целевая аудитория";
                xlWorkSheet.Cells[5, 5] = "Состояние";
                xlWorkSheet.Cells[5, 6] = "Категория экспоната";

                for (i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewCell cell1 = dataGridView1["title", i];
                    xlWorkSheet.Cells[i + 6, 1] = cell1.Value;
                    xlWorkSheet.Cells[i + 6, 1].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                    xlWorkSheet.Cells[i + 6, 1].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                    xlWorkSheet.Cells[i + 6, 1].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                    xlWorkSheet.Cells[i + 6, 1].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                    DataGridViewCell cell2 = dataGridView1["typeexp", i];
                    xlWorkSheet.Cells[i + 6, 2] = cell2.Value;
                    xlWorkSheet.Cells[i + 6, 2].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                    xlWorkSheet.Cells[i + 6, 2].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                    xlWorkSheet.Cells[i + 6, 2].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                    xlWorkSheet.Cells[i + 6, 2].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                    DataGridViewCell cell3 = dataGridView1["autcat", i];
                    xlWorkSheet.Cells[i + 6, 3] = cell3.Value;
                    xlWorkSheet.Cells[i + 6, 3].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                    xlWorkSheet.Cells[i + 6, 3].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                    xlWorkSheet.Cells[i + 6, 3].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                    xlWorkSheet.Cells[i + 6, 3].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                    DataGridViewCell cell4 = dataGridView1["audcat", i];
                    xlWorkSheet.Cells[i + 6, 4] = cell4.Value;
                    xlWorkSheet.Cells[i + 6, 4].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                    xlWorkSheet.Cells[i + 6, 4].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                    xlWorkSheet.Cells[i + 6, 4].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                    xlWorkSheet.Cells[i + 6, 4].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                    DataGridViewCell cell5 = dataGridView1["damae", i];
                    xlWorkSheet.Cells[i + 6, 5] = cell5.Value;
                    xlWorkSheet.Cells[i + 6, 5].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                    xlWorkSheet.Cells[i + 6, 5].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                    xlWorkSheet.Cells[i + 6, 5].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                    xlWorkSheet.Cells[i + 6, 5].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                    DataGridViewCell cell6 = dataGridView1["categoryexp", i];
                    xlWorkSheet.Cells[i + 6, 6] = cell6.Value;
                    xlWorkSheet.Cells[i + 6, 6].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                    xlWorkSheet.Cells[i + 6, 6].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                    xlWorkSheet.Cells[i + 6, 6].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                    xlWorkSheet.Cells[i + 6, 6].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя
                }

                xlApp.DisplayAlerts = false;
                xlWorkBook.SaveAs(this.Text + "(" + label2.Text + ")", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkSheet.PrintOutEx(1, System.Type.Missing, 1, false, printDialog.PrinterSettings.PrinterName);

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception)
            {
                MessageBox.Show("Приложению не удалось найти Microsoft Excel на данном компьютере.\nПечать невозможна.", "Microsoft Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Очистка памяти
        /// </summary>
        /// <param name="obj"></param>
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Закрытие по нажатию клавиши ESC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeByEsc(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
