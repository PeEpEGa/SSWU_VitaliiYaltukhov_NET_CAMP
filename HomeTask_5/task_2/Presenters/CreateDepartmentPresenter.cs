using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Domain.Builders;
using task5._2_sigma_.Domain.Services.Interfaces;
using task5._2_sigma_.Presenters.Interfaces;

namespace task5._2_sigma_.Presenters
{
    internal class CreateDepartmentPresenter : IPresenter
    {
        private readonly DepartmentBuilder _departmentBuilder;
        private readonly IDepartmentStoreService _departmentService;

        public CreateDepartmentPresenter(DepartmentBuilder departmentBuilder, IDepartmentStoreService departmentService)
        {
            _departmentBuilder = departmentBuilder;
            _departmentService = departmentService;
        }

        public IPresenter Action()
        {
            try
            {
                var department = _departmentBuilder.Build();
                _departmentService.AddDepartment(department);

                Console.WriteLine("Department successfully created!");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            return new MainMenuPresenter();
        }

        public void Show()
        {
            Console.Clear();
        }
    }
}
