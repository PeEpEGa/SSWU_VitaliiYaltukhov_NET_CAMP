using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;

namespace task5._2_sigma_.Domain.Builders
{
    public class DepartmentBuilder
    {
        private string _name;

        public DepartmentBuilder AddDepartment(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Room name should be not null or empty");
            }

            _name = name;
            return this;
        }

        public Department Build()
        {
            return new Department
            {
                Name = _name,
                Departments = new List<Department>()
            };
        }
    }
}