using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalClasses;
using DomainPTD.DomainClasses;
using Excel = Microsoft.Office.Interop.Excel;

namespace PTDProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application TempImportExcel = new Excel.Application(); ;
            Excel.Workbook TempWoorkBook =
                TempImportExcel.Application.Workbooks.Open(@"H:/ИК22 факт выполнение согл договора ГП на 07.11.2017.xlsx");
            Excel.Worksheet TempWorkSheet = TempWoorkBook.Worksheets.get_Item(1);
            TempImportExcel.DisplayAlerts = false;
            FindExcelTitleContr find = new FindExcelTitleContr();
            FindExcelPeriodListContr findPeriod = new FindExcelPeriodListContr();
            FindExcelAllocMoneyContr findMoney = new FindExcelAllocMoneyContr();
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(find.FindTitle(TempImportExcel, i));
                Console.WriteLine(findMoney.FindAllocMoney(TempImportExcel, i));
                Console.WriteLine();
                foreach (var temp in findPeriod.FindPeriodList(TempImportExcel, i))
                {
                    Console.WriteLine(temp.Date + " " + temp.Money);
                }
            }
            Console.ReadKey();
            TempWoorkBook.Close(false);
            TempImportExcel.Quit();
            TempImportExcel = null;
            TempWoorkBook = null;
            TempWorkSheet = null;
            GC.Collect();
        }
    }
}
