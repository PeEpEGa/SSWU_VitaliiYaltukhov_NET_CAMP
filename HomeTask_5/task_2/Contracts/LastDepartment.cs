using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5._2_sigma_.Contracts
{
    public class LastDepartment
    {
        public string Name { get; set; }
        public List<Item> Products { get; set; }
        public int LastDepartmentPackage { get; set; }
    }
}
