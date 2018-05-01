using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalInterfaces.Behaviors;
using Excel = Microsoft.Office.Interop.Excel;
using DomainPTD.DomainClasses;
using System.Text.RegularExpressions;

namespace FuncionalPTD.FunctionalClasses
{
    /// <summary>
    /// класс нахождения периодов в Excel файле генподрядчика
    /// </summary>
    public class FindExcelPeriodListContr : FindPeriodListBehavior
    {
        private List<string> monthList { set; get; }
            = new List<string>()
            {
                "январь", "янв",
                "февраль", "фев",
                "март", "мар",
                "апрель", "апр",
                "май", "май",
                "июнь", "июн",
                "июль", "июль",
                "август", "авг",
                "сентябрь", "сен",
                "октябрь", "окт",
                "ноябрь", "ноя",
                "декабрь", "дек"
            };

        private Excel.Application TempImportExcel;
        private Excel.Workbook TempWoorkBook;
        private Excel.Worksheet TempWorkSheet;

        /// <summary>
        /// метод нахождения периодов в Excel файле генподрядчика
        /// </summary>
        /// <param name="path"></param>
        public List<Period> FindPeriodList(string path, int index)
        {
            TempImportExcel = new Excel.Application(); ;
            TempWoorkBook = TempImportExcel.Application.Workbooks.Open(path);
            TempWorkSheet = TempWoorkBook.Worksheets.get_Item(1);
            TempImportExcel.DisplayAlerts = false;

            int CountingColumn = 2;
            int CountingPeriodLine = 1;
            int CountingMoneyLine;

            while (TempWorkSheet.Cells[CountingPeriodLine + 1, CountingColumn].Text != "1")
                CountingPeriodLine++;

            CountingMoneyLine = CountingPeriodLine + 2;

            while (TempWorkSheet.Cells[CountingMoneyLine + 1, CountingColumn].Text != "1")
                CountingMoneyLine++;

            List<DateTime> resultDateList = new List<DateTime>();
            List<decimal> resultMoneyList = new List<decimal>();

            for (int i = 0; findCell(CountingPeriodLine, CountingColumn + i).Value != null;
                i ++)
            {
                int month = findMounth(findCell(CountingPeriodLine, CountingColumn + i));
                if (month > 0)
                {
                    int year = findYear(findCell(CountingPeriodLine, CountingColumn + i));
                    resultDateList.Add(new DateTime(year, month, 1));

                    if (TempWorkSheet.Cells[CountingMoneyLine + index, CountingColumn + i].Value != null)
                        resultMoneyList.Add(
                            (decimal)TempWorkSheet.Cells[CountingMoneyLine + index, CountingColumn + i].Value);
                    else resultMoneyList.Add(0);
                }
            }

            for (int i = 1; i < resultDateList.Count; i++)
            {
                if (resultDateList[i].Year == resultDateList[i - 1].Year
                    && resultDateList[i].Month == resultDateList[i - 1].Month)
                {
                    resultMoneyList[i] += resultMoneyList[i - 1];
                    resultDateList.RemoveAt(i - 1);
                    resultMoneyList.RemoveAt(i - 1);
                    i--;
                }
            }

            List<Period> result = new List<Period>();

            for (int i = 0; i < resultMoneyList.Count; i++)
                result.Add(
                    new Period { Date = resultDateList[i], Money = resultMoneyList[i] });

            TempWoorkBook.Close(false);
            TempImportExcel.Quit();
            TempImportExcel = null;
            TempWoorkBook = null;
            TempWorkSheet = null;
            GC.Collect();
            return result;
        }

        private Excel.Range findCell(int row, int column) =>
            TempWorkSheet.Cells[TempWorkSheet.Cells[row, column].MergeArea.Row,
                TempWorkSheet.Cells[row, column].MergeArea.Column];

        private int findMounth(Excel.Range period)
        {
            if (period.Value.GetType() == typeof(DateTime))
                return period.Value.Month;
            else if (period.Value.GetType() == typeof(string))
            {
                var month = from temp in monthList
                            where period.Text.ToLower().Contains(temp)
                            select (monthList.IndexOf(temp) + 1) / 2
                            + ((monthList.IndexOf(temp) + 1) % 2 == 0 ? 0 : 1);
                if (month.Count() != 0)
                {
                    return month.Last();
                }
            }
            return -1;
        }

        private int findYear(Excel.Range period)
        {
            int newRow = TempWorkSheet.Cells[period.MergeArea.Row - 1, period.Column].MergeArea.Row;
            int newColumn = TempWorkSheet.Cells[newRow, period.Column].MergeArea.Column;
            Regex regex = new Regex("[0-9]");
            string[] strSplit = TempWorkSheet.Cells[newRow, newColumn].Text.Split(' ');
            foreach (var temp in strSplit)
            {
                if (regex.IsMatch(temp) && temp.Length == 4)
                    return int.Parse(temp);
            }
            return 0;
        }
    }
}
