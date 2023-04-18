using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;
using task5._2_sigma_.Domain.Services.Interfaces;
using task5._2_sigma_.Presenters.Interfaces;

namespace task5._2_sigma_.Presenters
{
    internal class ShowDepartmentStoreStructure : IPresenter
    {
        private readonly IDepartmentStoreService _departmentService;

        public ShowDepartmentStoreStructure(IDepartmentStoreService departmentService)
        {
            _departmentService = departmentService;
        }

        public IPresenter Action()
        {
            Console.ReadKey();
            return new MainMenuPresenter();
        }

        public void Show()
        {
            Console.Clear();

            PrintAllDepartments(_departmentService.GetAllDepartments().ToList(), 0);


            Console.WriteLine("Press any key to continue...");
        }


        private void PrintAllDepartments(List<Department> departments, int space)
        {
            if (departments.Count == 0)
            {
                return;
            }
            Console.WriteLine();
            for (int i = 0; i < departments.Count; i++)
            {
                PrintEntetity(departments[i].Name.ToString(), space - i, '|');

                if (departments[i].LastDepartment != null)
                {
                    PrintEntetity(departments[i].LastDepartment.Name.ToString(), space - i, '/');
                }
                PrintAllDepartments(departments[i].Departments, ++space + 2);
            }
        }

        private void PrintEntetity(string toPrint, int space, char separator)
        {
            string spaceToAdd = new string(' ', space);
            Console.WriteLine(spaceToAdd + "  " + separator);
            Console.WriteLine(spaceToAdd + "  " + separator + "---" + toPrint + " ");
            Console.Write(spaceToAdd + "  " + separator);
            Console.WriteLine();
        }
    }
}
