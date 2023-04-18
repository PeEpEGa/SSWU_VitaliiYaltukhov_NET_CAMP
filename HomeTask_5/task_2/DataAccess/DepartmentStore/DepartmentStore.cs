using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;
using task5._2_sigma_.DataAccess.DepartmentSore.Interfaces;

namespace task5._2_sigma_.DataAccess.DepartmentSore
{
    internal class DepartmentStore : IDepartmentStore
    {
        //probably to list
        private List<Department> _departments = new List<Department>();

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departments;
        }
    }
}