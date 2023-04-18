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
    internal class AddItems : IPresenter
    {
        private readonly IDepartmentStoreService _departmentService;

        public AddItems(IDepartmentStoreService departmentService)
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
                if (result.Length != 2)
                {
                    throw new Exception("Incorrect Entrance.");
                }

                //format('departmentToFind' a,1,2,3;b,7,5,2;c,3,8,4;) name heigth width length
                string departmentToFind = result[0];
                var itemsToAdd = result[1].Split(';', StringSplitOptions.RemoveEmptyEntries);
                var departments = _departmentService.GetAllDepartments();

                List<Item> items = new List<Item>();
                for (int i = 0; i < itemsToAdd.Length; i++)
                {
                    var item = itemsToAdd[i].Split(',',StringSplitOptions.RemoveEmptyEntries);
                    items.Add(new Item
                    {
                        NameOfTheItem = item[0],
                        Height = Int32.Parse(item[1]),
                        Width = Int32.Parse(item[2]),
                        Length = Int32.Parse(item[3])
                    });
                }

                printed = AddProducts(departments.ToList(), departmentToFind, items);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            if (printed)
            {
                Console.WriteLine("Products added successfully.");
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

        private bool AddProducts(List<Department> departments, string departmentName, List<Item> items)
        {
            bool added = false;
            int length = departments.Count;
            if (length == 0)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                var possibleDepartment = departments.FirstOrDefault(n => n.LastDepartment != null && n.LastDepartment.Name == departmentName);
                if (possibleDepartment != null)
                {
                    possibleDepartment.LastDepartment.Products = items;
                    return true;
                }
                var dep = departments[i].Departments;
                added = AddProducts(dep, departmentName, items);
            }
            return added;
        }
    }
}
