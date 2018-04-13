using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalInterfaces.Behaviors;
using DomainPTD.DomainClasses;
using System.Collections.ObjectModel;
using System.IO;

namespace FuncionalPTD.FunctionalClasses
{
    /// <summary>
    /// класс, описывающий работу менеджера файлов
    /// </summary>
    public class FileManager
    {

        /// <summary>
        /// путь текущего корневого каталога
        /// </summary>
        public string CurrentReportPath { get; set; } 
        /// <summary>
        /// путь текущего проекта
        /// </summary>
        public string ReportPath { get; set; }
        /// <summary>
        /// поведение добавление файла соотношения генподрядчика и субподрядчиков
        /// </summary>
        public AddCASFileBehavior AddCASFileBehavior { get; set; }
        /// <summary>
        /// Генподрядчик в проекте
        /// </summary>
        public Contractor Contractor { get; set; }
        /// <summary>
        /// коллекция субподрядчиков в проекте
        /// </summary>
        public ObservableCollection<Subcontractor> Subcontractors { get; set; }
            = new ObservableCollection<Subcontractor>();

        /// <summary>
        /// метод создает корневой каталог по указанному пути
        /// </summary>
        /// <param name="path"></param>
        public void CreateGeneralFolder(string path, string name)
        {
            CurrentReportPath = path + '/' + name;
            Directory.CreateDirectory(CurrentReportPath);
        }

        /// <summary>
        /// метод открывает новый корневой каталог
        /// </summary>
        /// <param name="path"></param>
        public void OpenGeneralFolder(string path)
        {
            CurrentReportPath = path;
        }

        /// <summary>
        /// метод выстраивает древо каталогов при создании проекта
        /// </summary>
        /// <param name="path"></param>
        public void CreateProject(string name)
        {
            ReportPath += CurrentReportPath + '/' + name;
            Directory.CreateDirectory(ReportPath);
            Directory.CreateDirectory(ReportPath + @"/Генподрядчик");
            Directory.CreateDirectory(ReportPath + @"/Субподрядчик");
            Directory.CreateDirectory(ReportPath + @"/Ресурсы");
        }

        /// <summary>
        /// метод добавляет нового генподрядчика по указанному пути или создает в случае его отсутствия
        /// </summary>
        /// <param name="path"></param>
        public void AddContractor(string path)
        {

        }

        

        /// <summary>
        /// метод добавляет нового субподрядчика
        /// </summary>
        /// <param name="path"></param>
        public void AddSubcontractor (string path)
        {

        }

        /// <summary>
        /// метод дабавления файла соотношения генподрядчика и субподрядчика
        /// </summary>
        /// <param name="path"></param>
        public void AddCASFile(string path)
        {

        }

    }
}
