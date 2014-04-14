using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationControls;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

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
            try
            {
                int p = dataGridView1.SelectedCells[0].RowIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбран экспонат для отобржаения информации");
                return;
            }


            Info info = new Info(User.exponats[dataGridView1.SelectedCells[0].RowIndex].getPkExponat());
            info.ShowDialog();

            Load_Exponats();
        }

        /// <summary>
        /// Фильтр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setFilter(object sender, EventArgs e)
        {
            Filter fltr = new Filter();
            fltr.ShowDialog();

            //Вновь пофильтруем
            Load_Exponats();
           

        }

        /// <summary>
        /// Выставки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showExib(object sender, EventArgs e)
        {
            Exibition exb = new Exibition();
            exb.ShowDialog();
        }

        /// <summary>
        /// Источники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showSources(object sender, EventArgs e)
        {
            Source src = new Source();
            src.ShowDialog();

            Load_Exponats();
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchSett(object sender, EventArgs e)
        {
            mainSettings mst = new mainSettings();
            mst.ShowDialog();

            Load_Exponats();
        }

        /// <summary>
        /// Производит загружку всех экспонатов и фильтрует по заданному фильтру
        /// </summary>
        private void Load_Exponats()
        {
            User.load_exponats();
            User.filter();

            //ТУТ ДЕЛАЕМ ФИЛЬТРЕЦ

           // dataGridView1.DataSource = null;

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

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            User.typeFilter = new List<int>();
            User.categoryAuthorFilter = new List<int>();
            User.categoryAuditoryFilter = new List<int>();
            User.categoryExponatFilter = new List<int>();
            User.Checks = new List<int>();

            Load_Exponats();
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                int p = dataGridView1.SelectedCells[0].RowIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбрана строка для удаления");
                return;
            }

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            User.exponats[dataGridView1.SelectedCells[0].RowIndex].delete_();

            Load_Exponats();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int p = dataGridView1.SelectedCells[0].RowIndex;

            }
            catch (Exception ff)
            {

                MessageBox.Show("Не выбрана строка для редактирования");
                return;
            }

            Form2 f2 = new Form2(User.exponats[dataGridView1.SelectedCells[0].RowIndex].getPkExponat());
            f2.ShowDialog();
            Load_Exponats();
        }

        /// <summary>
        /// Печать...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printMethod(); 
        }

        /// <summary>
        /// Метод печати
        /// </summary>
        private void printMethod()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet = (Excel.Worksheet)xlApp.Worksheets[1];
            xlWorkSheet.Cells.ColumnWidth = 13;
            xlWorkSheet.Cells.Font.Size = 8;
            int i = 0;

            xlWorkSheet.Cells[1, 1] = "iMuseum - Список экспонатов";
            xlWorkSheet.Cells[2, 1] = DateTime.Today.Date.ToShortDateString();

            xlWorkSheet.Cells[4, 1] = "Инвентарный номер";
            xlWorkSheet.Cells[4, 2] = "Наименование";
            xlWorkSheet.Cells[4, 3] = "Источник получения";
            xlWorkSheet.Cells[4, 4] = "Тип собственности";
            xlWorkSheet.Cells[4, 5] = "Место хранения";
            xlWorkSheet.Cells[4, 6] = "Состояние";

            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewCell cell1 = dataGridView1["number", i];
                xlWorkSheet.Cells[i + 5, 1] = cell1.Value;
                xlWorkSheet.Cells[i + 5, 1].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                xlWorkSheet.Cells[i + 5, 1].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                xlWorkSheet.Cells[i + 5, 1].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                xlWorkSheet.Cells[i + 5, 1].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                DataGridViewCell cell2 = dataGridView1["title", i];
                xlWorkSheet.Cells[i + 5, 2] = cell2.Value;
                xlWorkSheet.Cells[i + 5, 2].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                xlWorkSheet.Cells[i + 5, 2].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                xlWorkSheet.Cells[i + 5, 2].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                xlWorkSheet.Cells[i + 5, 2].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                DataGridViewCell cell3 = dataGridView1["source", i];
                xlWorkSheet.Cells[i + 5, 3] = cell3.Value;
                xlWorkSheet.Cells[i + 5, 3].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                xlWorkSheet.Cells[i + 5, 3].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                xlWorkSheet.Cells[i + 5, 3].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                xlWorkSheet.Cells[i + 5, 3].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                DataGridViewCell cell4 = dataGridView1["typesob", i];
                xlWorkSheet.Cells[i + 5, 4] = cell4.Value;
                xlWorkSheet.Cells[i + 5, 4].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                xlWorkSheet.Cells[i + 5, 4].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                xlWorkSheet.Cells[i + 5, 4].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                xlWorkSheet.Cells[i + 5, 4].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                DataGridViewCell cell5 = dataGridView1["mesto", i];
                xlWorkSheet.Cells[i + 5, 5] = cell5.Value;
                xlWorkSheet.Cells[i + 5, 5].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                xlWorkSheet.Cells[i + 5, 5].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                xlWorkSheet.Cells[i + 5, 5].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                xlWorkSheet.Cells[i + 5, 5].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя

                DataGridViewCell cell6 = dataGridView1["damage", i];
                xlWorkSheet.Cells[i + 5, 6] = cell6.Value;
                xlWorkSheet.Cells[i + 5, 6].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                xlWorkSheet.Cells[i + 5, 6].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                xlWorkSheet.Cells[i + 5, 6].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                xlWorkSheet.Cells[i + 5, 6].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; // нижняя внешняя
            }

            xlApp.DisplayAlerts = false;
            xlWorkBook.SaveAs("iMuseum - Список экспонатов (" + DateTime.Today.Date.ToShortDateString() + ")", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkSheet.PrintOutEx(1, System.Type.Missing, 1, false, printDialog1.PrinterSettings.PrinterName);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
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
        /// Выход...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeApp(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
