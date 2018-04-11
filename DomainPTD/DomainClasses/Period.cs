using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainPTD.DomainInterfaces
{
    /// <summary>
    /// класс, описывающий информацию о сроках работы
    /// </summary>
    public class Period
    {
        /// <summary>
        /// дата срока
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// деньги, потраченные за срок
        /// </summary>
        public decimal Money { get; set; }
    }
}
