using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Domain.Builders;
using task5._2_sigma_.Domain.Services.Interfaces;
using task5._2_sigma_.Presenters.Interfaces;

using DomainFactory = task5._2_sigma_.Domain.Factory;

namespace task5._2_sigma_.Presenters
{
    internal class CreateDepartmentNamePresenter : IPresenter
    {
        private readonly DepartmentBuilder _departmentBuilder;

        public CreateDepartmentNamePresenter(DepartmentBuilder departmentBuilder)
        {
            _departmentBuilder = departmentBuilder;
        }

        public IPresenter Action()
        {
            while (true)
            {
                try
                {
                    var name = Console.ReadLine();
                    _departmentBuilder.AddDepartment(name);
                    return new CreateDepartmentPresenter(_departmentBuilder, DomainFactory.DepartmentStoreService);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Enter department name:");
        }
    }
}
