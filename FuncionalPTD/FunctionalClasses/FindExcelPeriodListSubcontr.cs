using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalInterfaces.Behaviors;
using DomainPTD.DomainClasses;

namespace FuncionalPTD.FunctionalClasses
{
    /// <summary>
    /// класс нахождения периодов в Excel файле генподрядчика
    /// </summary>
    public class FindExcelPeriodListSubcontr : FindPeriodListBehavior
    {
        /// <summary>
        /// метод нахождения периодов в Excel файле субподрядчика
        /// </summary>
        /// <param name="path"></param>
        public List<Period> FindPeriodList(string path, int index)
        {
            return new List<Period>();
        }
    }
}
