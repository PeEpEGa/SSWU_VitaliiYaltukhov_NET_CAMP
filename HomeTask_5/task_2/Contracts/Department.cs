using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5._2_sigma_.Contracts
{
    public class Department
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public int DepartmentPackage { get; set; }
        public LastDepartment? LastDepartment { get; set; }
    }
}
