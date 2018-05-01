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
    /// класс нахождения названия компании в Excel-файле генподрядчика
    /// </summary>
    public class FindExcelTitleContr : FindTitleBehavior
    {
        /// <summary>
        /// метод нахождения названия компании в Excel-файле генподрядчика
        /// </summary>
        /// <returns></returns>
        public string FindTitle(string path, int index)
        {
            Excel.Application TempImportExcel = new Excel.Application(); ;
            Excel.Workbook TempWoorkBook = TempImportExcel.Application.Workbooks.Open(path);
            Excel.Worksheet TempWorkSheet = TempWoorkBook.Worksheets.get_Item(1);
            TempImportExcel.DisplayAlerts = false;

            int WorkIndex = 3;
            int CountingLine = 0;

            for (int i = CountingLine + 1; i < TempWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row; i++)
            {
                if (TempWorkSheet.Cells[i, WorkIndex - 1].Text == "1")
                {
                    CountingLine = i;
                    break;
                }
            }

            for (int i = CountingLine + 1; i < TempWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row; i++)
            {
                if (TempWorkSheet.Cells[i, WorkIndex - 1].Text == "1")
                {
                    CountingLine = i;
                    break;
                }
            }

            string Return = null;
            Return = TempWorkSheet.Cells[CountingLine - 1 + index, WorkIndex].Text.ToString();
            TempImportExcel.Application.Workbooks.Close();
            return Return;
        }
    }
}
