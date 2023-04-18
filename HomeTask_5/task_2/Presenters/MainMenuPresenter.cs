using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Domain.Builders;
using task5._2_sigma_.Presenters.Interfaces;

using DomainFactory = task5._2_sigma_.Domain;

namespace task5._2_sigma_.Presenters
{
    internal class MainMenuPresenter : IPresenter
    {
        public IPresenter Action()
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return new CreateDepartmentNamePresenter(new DepartmentBuilder());
                case ConsoleKey.D2:
                    return new ShowDepartmentStoreStructure(DomainFactory.Factory.DepartmentStoreService);
                case ConsoleKey.D3:
                    return new CreateSubdepartment(DomainFactory.Factory.DepartmentStoreService);
                case ConsoleKey.D4:
                    return new AddLastDepartment(DomainFactory.Factory.DepartmentStoreService);
                case ConsoleKey.D5:
                    return new AddItems(DomainFactory.Factory.DepartmentStoreService);
                case ConsoleKey.D6:
                    return new PackItems(DomainFactory.Factory.DepartmentStoreService);
                case ConsoleKey.D0:
                    return null;
                default:
                    return this;
            }
        }

        public void Show()
        {
            Console.Clear();

            Console.WriteLine("Store Department Structure Creation");
            Console.WriteLine();
            Console.WriteLine("1 - Create department");
            Console.WriteLine("2 - Show store structure");
            Console.WriteLine("3 - Create subdepartment");
            Console.WriteLine("4 - Create last department");
            Console.WriteLine("5 - Add items");
            Console.WriteLine("6 - Pack items");
            Console.WriteLine("0 - Exit");
        }
    }
}
