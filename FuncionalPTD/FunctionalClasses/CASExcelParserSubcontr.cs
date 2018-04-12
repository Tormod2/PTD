using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalInterfaces;
using FuncionalPTD.FunctionalInterfaces.Behaviors;

namespace FuncionalPTD.FunctionalClasses
{
    /// <summary>
    /// Класс парсера файлов генподрядчика
    /// </summary>
    public class CASExcelParserSubcontr : ICASParser
    {
        public FindTitleBehavior FindTitleBehavior { get; set; }
        public FindPeriodListBehavior FindPeriodListBehavior { get; set; }
        public FindAllocMoneyBehavior FindAllocMoneyBehavior { get; set; }

        public CASExcelParserSubcontr()
        {
            FindTitleBehavior = new FindExcelTitleSubcontr();
            FindPeriodListBehavior = new FindExcelPeriodListSubcontr();
            FindAllocMoneyBehavior = new DefaultExcelFindAllocMoney();
        }

        /// <summary>
        /// Поиск названия работы в файле субподрядчика
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string FindTitle(string path, int index)
        {
            return "";
        }

        /// <summary>
        /// Поиск сроков выполнения работы в файле субподрядчика
        /// </summary>
        /// <param name="path"></param>
        /// <param name="workTitle"></param>
        /// <returns></returns>
        public List<string> FindPeriodList(string path, string workTitle)
        {
            return new List<string>();
        }

        /// <summary>
        /// Поиск выделенных дна работу денег в файле субподрядчика
        /// </summary>
        /// <param name="path"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        public string FindAllocMoney(string path, string work)
        {
            return "";
        }
    }
}
