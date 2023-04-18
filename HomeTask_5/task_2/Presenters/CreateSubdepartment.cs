using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;
using task5._2_sigma_.Domain.Builders;
using task5._2_sigma_.Domain.Services.Interfaces;
using task5._2_sigma_.Presenters.Interfaces;

namespace task5._2_sigma_.Presenters
{
    internal class CreateSubdepartment : IPresenter
    {
        private readonly IDepartmentStoreService _departmentService;

        public CreateSubdepartment(IDepartmentStoreService departmentService)
        {
            _departmentService = departmentService;
        }

        public IPresenter Action()
        {
            bool printed = false;
            try
            {
                var name = Console.ReadLine();
                var result = name.Split(' ');
                if(result.Length != 2)
                {
                    throw new Exception("Incorrect entrance");
                }
                string departmentToFind = result[0];
                string nameOfDepartment = result[1];
                var departments = _departmentService.GetAllDepartments();
                
                Department dep = new Department { Name = nameOfDepartment, Departments = new List<Department>() };
                printed = AddDepartment(departments.ToList(), departmentToFind, dep);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            if (printed)
            {
                Console.WriteLine("Department added successfully.");
            }
            else
            {
                Console.WriteLine("No such Department.");
            }

            Console.ReadKey();
            Console.WriteLine("Press any key to continue...");
            return new MainMenuPresenter();
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Enter existing department name first then enter space and name of department to create:");
        }

        private bool AddDepartment(List<Department> departments, string departmentName, Department department)
        {
            bool added = false;
            int length = departments.Count;
            if(length == 0)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                var possibleDepartment = departments.FirstOrDefault(n => n.Name == departmentName);
                if (possibleDepartment != null)
                {
                    possibleDepartment.Departments.Add(department);
                    return true;
                }
                var dep = departments[i].Departments;
                added = AddDepartment(dep, departmentName, department);
            }
            return added;
        }
    }
}
