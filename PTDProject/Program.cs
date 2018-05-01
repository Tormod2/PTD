using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalClasses;
using DomainPTD.DomainClasses;

namespace PTDProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FindExcelPeriodListContr find = new FindExcelPeriodListContr();
            List<Period> list = find.FindPeriodList(@"H:\ИК22 факт выполнение согл договора ГП на 07.11.2017.xlsx", 36);
            foreach(var temp in list)
            {
                Console.WriteLine(temp.Date.ToString() + " " + temp.Money.ToString());
            }
            Console.ReadKey();
        }
    }
}
