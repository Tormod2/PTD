﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalInterfaces.Behaviors;

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
        public List<string> FindPeriodList(string path, string workTitle)
        {
            return new List<string>();
        }
    }
}