﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainPTD.DomainInterfaces;
using System.ComponentModel.DataAnnotations;

namespace DomainPTD.DomainClasses
{
    /// <summary>
    /// Класс, описывающий файл с работой генподрядчика
    /// </summary>
    [Serializable]
    public class ContrWorkFile : IWorkFile
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
