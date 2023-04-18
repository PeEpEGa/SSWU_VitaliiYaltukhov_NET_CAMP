using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task5._2_sigma_.Contracts;
using task5._2_sigma_.DataAccess.DepartmentSore.Interfaces;
using task5._2_sigma_.Domain.Services.Interfaces;

namespace task5._2_sigma_.Domain.Services
{
    internal class DepartmentStoreService : IDepartmentStoreService
    {
        private readonly IDepartmentStore _store;

        public DepartmentStoreService(IDepartmentStore repository)
        {
            _store = repository;
        }

        public void AddDepartment(Department department)
        {
            _store.AddDepartment(department);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _store.GetAllDepartments();
        }
    }
}
