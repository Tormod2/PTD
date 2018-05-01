﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainPTD.DomainClasses;

namespace FuncionalPTD.FunctionalInterfaces.Behaviors
{
    /// <summary>
    /// поведение нахождения периодов в файле
    /// </summary>
    public interface FindPeriodListBehavior
    {
        /// <summary>
        /// метод нахождения периодов в файле
        /// </summary>
        /// <param name="path"></param>
        /// /// <param name="workTitle"></param>
        /// <returns></returns>
        List<Period> FindPeriodList(string path, int index);
    }
}
