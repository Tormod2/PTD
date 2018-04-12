using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainPTD.DomainClasses;
using FuncionalPTD.FunctionalInterfaces;

namespace FuncionalPTD.FunctionalClasses
{
    /// <summary>
    /// Класс составления информации о работе в файле субподрядчика
    /// </summary>
    public class SubcontrWorkMaker : IWorkInfoMaker
    {
        /// <summary>
        /// метод составляет информацию по работе (из файла)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public Work MakeInfo(string path, int index)
        {
            return new Work();
        }

        /// <summary>
        /// метод составления информации о названии работы
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string makeTitle(string path, int index)
        {
            return "";
        }

        /// <summary>
        /// метод составления информации о периодах работы (из файла)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private List<Period> makePeriodList(string path, int index)
        {
            return new List<Period>();
        }

        /// <summary>
        /// метод составления информации о выделенных на работу деньгах (из файла)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private decimal makeAllocMoney(string path, int index)
        {
            return 0;
        }
    }
}
