using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;

namespace task5._2_sigma_.DataAccess.DepartmentSore.Interfaces
{
    public interface IDepartmentStore
    {
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(Department department);
    }
}
