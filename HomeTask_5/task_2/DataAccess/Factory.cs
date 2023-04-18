using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.DataAccess.DepartmentSore;
using task5._2_sigma_.DataAccess.DepartmentSore.Interfaces;

namespace task5._2_sigma_.DataAccess
{
    public static class Factory
    {
        public static readonly IDepartmentStore DepartmentStore = new DepartmentStore();
    }
}
