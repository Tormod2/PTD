﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionalPTD.FunctionalInterfaces.Behaviors
{
    /// <summary>
    /// поведение нахождения названия компании
    /// </summary>
    public interface FindTitleBehavior
    {
        /// <summary>
        /// метод нахождения названия компании в файле
        /// </summary>
        /// <returns></returns>
        string FindTitle(string path, int index);
    }
}