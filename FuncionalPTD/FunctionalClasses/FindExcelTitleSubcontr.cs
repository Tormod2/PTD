using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalInterfaces.Behaviors;
using Excel = Microsoft.Office.Interop.Excel;

namespace FuncionalPTD.FunctionalClasses
{
    /// <summary>
    /// класс нахождения названия компании в Excel-файле субподрядчика
    /// </summary>
    public class FindExcelTitleSubcontr : FindTitleBehavior
    {
        /// <summary>
        /// метод нахождения названия компании в Excel-файле субподрядчика
        /// </summary>
        /// <returns></returns>
        Excel.Application TempImportExcel;
        Excel.Workbook TempWoorkBook;
        Excel.Worksheet TempWorkSheet;
        public string FindTitle(string path, int index)
        {
            TempImportExcel = new Excel.Application();
            TempWoorkBook = TempImportExcel.Application.Workbooks.Open(path);
            TempWorkSheet = TempWoorkBook.Worksheets.get_Item(1);
            TempImportExcel.DisplayAlerts = false;

            int WorkIndex = 3;
            int CountingLine = 0;
            for (int i = CountingLine + 1; i < TempWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row; i++)
            {
                if (TempWorkSheet.Cells[i, WorkIndex - 2].Text == "1")
                {
                    CountingLine = i;
                    break;
                }
            }

            for (int i = CountingLine + 1; i < TempWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row; i++)
            {
                if (TempWorkSheet.Cells[i, WorkIndex - 2].Text == "1")
                {
                    CountingLine = i;
                    break;
                }
            }
;
            string Return = null;
            int j = 0;
            for (int i = CountingLine; i < TempWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row; i++)
            {
                if (TempWorkSheet.Cells[i, WorkIndex - 1].Text != "" && TempWorkSheet.Cells[i, WorkIndex - 2].Text != "")
                {
                    j++;
                    if (index == j)
                    {
                        Return = TempWorkSheet.Cells[i, WorkIndex].Text;
                    }
                }
            }
            TempImportExcel.Application.Workbooks.Close();
            return Return;
        }
    }
}
