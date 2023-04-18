using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;
using task5._2_sigma_.Domain.Services.Interfaces;
using task5._2_sigma_.Presenters.Interfaces;

namespace task5._2_sigma_.Presenters
{
    internal class PackItems : IPresenter
    {
        private readonly IDepartmentStoreService _departmentService;

        public PackItems(IDepartmentStoreService departmentService)
        {
            _departmentService = departmentService;
        }

        public IPresenter Action()
        {
            bool exist = false;
            try
            {
                var name = Console.ReadLine();
                
                //format(a b c) name of items
                var itemsToFind = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var departments = _departmentService.GetAllDepartments();

                exist = FindProducts(departments.ToList(), itemsToFind.ToList());
                int packageHeight = PackageHeight(departments.ToList());
                Console.WriteLine($"Height of package: {packageHeight}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
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

        private bool FindProducts(List<Department> departments, List<string> items)
        {
            bool exist = false;
            int length = departments.Count;
            if (length == 0)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                if(departments[i].LastDepartment != null)
                {
                    departments[i].LastDepartment.Products.Any(n => items.Contains(n.NameOfTheItem));
                    var lastDepartment = departments[i].LastDepartment;
                    for (int j = 0; j < lastDepartment.Products.Count; j++)
                    {
                        for (int q = 0; q < items.Count; q++)
                        {
                            if (lastDepartment.Products[j].NameOfTheItem == items[q])
                            {
                                int packageLength = lastDepartment.LastDepartmentPackage += lastDepartment.Products[j].Height;
                                departments[i].DepartmentPackage += packageLength;
                                exist = true;
                            }
                        }
                    }
                }
                var dep = departments[i].Departments;
                exist = FindProducts(dep, items);
            }
            return exist;
        }

        private int PackageHeight(List<Department> departments)
        {
            if (departments.Count == 0)
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < departments.Count; i++)
            {
                result += departments[i].DepartmentPackage + PackageHeight(departments[i].Departments); 
            }
            return result;
        }
    }
}