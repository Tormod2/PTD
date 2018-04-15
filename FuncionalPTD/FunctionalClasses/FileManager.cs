using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalInterfaces.Behaviors;
using DomainPTD.DomainClasses;
using DomainPTD.DomainInterfaces;
using System.Collections.ObjectModel;
using System.IO;

namespace FuncionalPTD.FunctionalClasses
{
    /// <summary>
    /// класс, описывающий работу менеджера файлов
    /// </summary>
    public class FileManager
    {

        private const string ContractorFolderName = "Генподрядчик";
        private const string SubcontractorFolderName = "Субподрядчик";
        private const string ResourcesFolderName = "Ресурсы";
        private const string ContractorInfoFile = "ContractorSave.txt";

        /// <summary>
        /// путь текущего корневого каталога
        /// </summary>
        public string CurrentReportPath { get; set; } 
        /// <summary>
        /// путь текущего проекта
        /// </summary>
        public string ReportPath { get; set; }
        /// <summary>
        /// путь к данным о текущем проекте
        /// </summary>
        public string CurrentResourcesPath { get; set; }
        /// <summary>
        /// поведение добавление файла соотношения генподрядчика и субподрядчиков
        /// </summary>
        public AddCASFileBehavior AddCASFileBehavior { get; set; }
        /// <summary>
        /// Генподрядчик в проекте
        /// </summary>
        public ContrWorkFile Contractor { get; set; } 
            = new ContrWorkFile();
        /// <summary>
        /// коллекция субподрядчиков в проекте
        /// </summary>
        public ObservableCollection<SubcontrWorkFile> Subcontractors { get; set; }
            = new ObservableCollection<SubcontrWorkFile>();

        public FileManager()            //TODO
        {
            
            string[] splitPath = typeof(IWorker).Assembly.Location.Split('\\');
            string infoFolder = splitPath[0] + '\\' + Path.Combine(splitPath[1], splitPath[2]) + "Documents";

            DirectoryInfo info = new DirectoryInfo(infoFolder);

            StreamReader reader = new StreamReader(Path.Combine(CurrentResourcesPath, ContractorInfoFile));
            Contractor.Path = reader.ReadLine();
        }

        /// <summary>
        /// метод создает корневой каталог по указанному пути
        /// </summary>
        /// <param name="path"></param>
        public void CreateGeneralFolder(string path, string name)
        {
            CurrentReportPath = Path.Combine(path, name);
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
            CurrentResourcesPath = name + " info";
            ReportPath += Path.Combine(CurrentReportPath, name);
            Directory.CreateDirectory(CurrentResourcesPath);
            Directory.CreateDirectory(ReportPath);
            Directory.CreateDirectory(Path.Combine(ReportPath, ContractorFolderName));
            Directory.CreateDirectory(Path.Combine(ReportPath, SubcontractorFolderName));
            Directory.CreateDirectory(Path.Combine(ReportPath, ResourcesFolderName));
        }

        /// <summary>
        /// метод добавляет нового генподрядчика по указанному пути или создает в случае его отсутствия
        /// </summary>
        /// <param name="path"></param>
        public void AddContractor(string path)          //TODO
        {
            if (Contractor.Path != null)
            {
                File.Delete(Contractor.Path);
            }
            Contractor.Path = Path.Combine(ReportPath, ContractorFolderName, findFullName(path));
            File.Copy(path, Contractor.Path);
            using (StreamWriter writer =
                new StreamWriter(Path.Combine(CurrentResourcesPath, ContractorInfoFile), false))
            {
                writer.Write(Contractor.Path);
            }
        }

        public bool ContractorFolserIsEmpty()
        {
            if (Directory.GetFiles(Path.Combine(ReportPath, ContractorFolderName)).Length == 0)
                return false;
            else
                return true;
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

        public bool IsContractorFileExist()
        {
            if (Contractor != null)
                return false;
            else
                return true;
        }

        private string findName(string path)
        {
            string result = "";
            string[] splitList = findFullName(path).Split('.');
            for (int i = 0; i < findFullName(path).Split('.').Length - 1; i++)
            {
                result += splitList[i];
            }
            return result;
        }

        private string findFullName(string path)
        {
            string result = path.Split('\\', '/')[path.Split('\\', '/').Length - 1];
            return result;
        }
    }
}
