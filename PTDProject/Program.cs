using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuncionalPTD.FunctionalClasses;

namespace PTDProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager manager = new FileManager();
            manager.OpenGeneralFolder(@"C:\Users\Владимир\Desktop\newFolder");
            manager.OpenProject("newFolder");
            //manager.CreateGeneralFolder(@"C:\Users\Владимир\Desktop", "newFolder");
            //manager.CreateProject("newFolder");
            manager.AddContractor(@"C:\Users\Владимир\Desktop\перемещаемый.txt");
            manager.AddSubcontractor(@"C:\Users\Владимир\Desktop\перемещаемый.txt");
            manager.Serialize();
        }
    }
}
