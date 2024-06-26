﻿using RentalShopApp.Data.Entities;
using RentalShopApp.Data.Repositories;

namespace RentalShopApp.Components.DataProviders
{
    public class EmployeesProvider : IEmployeesProvider
    {
        private readonly IRepository<Employee> _employeesRepository;
        public EmployeesProvider(IRepository<Employee> employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public List<Employee> GetEmployeeByAge(int age)
        {
            var filteredEmployees = _employeesRepository.GetAll().Where(employee => employee.Age == age);
            return filteredEmployees.ToList();
        }

        public List<Employee> GetEmployeeByFirstName(string firstname)
        {
            var filteredEmployees = _employeesRepository.GetAll().Where(employee => employee.FirstName.ToLower() == firstname.ToLower());
            return filteredEmployees.ToList();
        }

        public List<Employee> GetEmployeeByLastName(string lastname)
        {
            var filteredEmployees = _employeesRepository.GetAll().Where(employee => employee.LastName.ToLower() == lastname.ToLower());
            return filteredEmployees.ToList();
        }

        public List<Employee> GetEmployeeByWorkType(string typeofwork)
        {
            var filteredEmployees = _employeesRepository.GetAll().Where(employee => employee.TypeOfWork.ToLower() == typeofwork.ToLower());
            return filteredEmployees.ToList();
        }
    }
}
