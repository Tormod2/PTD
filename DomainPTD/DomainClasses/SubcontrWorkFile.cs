using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainPTD.DomainInterfaces;

namespace DomainPTD.DomainClasses
{
    /// <summary>
    /// Класс, описывающий файл с работой субподрядчика
    /// </summary>
    [Serializable]
    public class SubcontrWorkFile : IWorkFile
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path { get; set; }

        public override string ToString()
        {
            return Path.Split('.')[Path.Split('.').Length - 1];
        }
    }
}
