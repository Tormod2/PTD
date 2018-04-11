using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainPTD.DomainInterfaces;

namespace DomainPTD.DomainClasses
{
    /// <summary>
    /// класс, описывающий данные подрядчика
    /// </summary>
    public class Contractor : IWorker
    {
        /// <summary>
        /// название компании генподрядчика
        /// </summary>
        public string Name { get; set; }
    }
}
