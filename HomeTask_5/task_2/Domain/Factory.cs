using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Domain.Services.Interfaces;
using task5._2_sigma_.Domain.Services;

using DataAccessFactory = task5._2_sigma_.DataAccess.Factory;

namespace task5._2_sigma_.Domain
{
    internal class Factory
    {
        public static readonly IDepartmentStoreService DepartmentStoreService = new DepartmentStoreService(DataAccessFactory.DepartmentStore);
    }
}