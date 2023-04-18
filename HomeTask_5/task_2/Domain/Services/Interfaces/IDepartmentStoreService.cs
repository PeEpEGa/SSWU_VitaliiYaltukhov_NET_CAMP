using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;

namespace task5._2_sigma_.Domain.Services.Interfaces
{
    public interface IDepartmentStoreService
    {
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(Department department);
    }
}
