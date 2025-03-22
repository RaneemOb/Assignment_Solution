using Assignment.Core.Models;
using Assignment.Core.Repository;
using Assignment.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infra.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task<bool> DeleteEmployee(int employeeId)
        {
             return employeeRepository.DeleteEmployee(employeeId);
        }

        public Task <List<Employees>> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public Task<bool> InsertEmployee( string firstName, string lastName, string jobTitle, string department, decimal salary)
        {
            return employeeRepository.InsertEmployee( firstName, lastName, jobTitle, department, salary);

        }

        public Task<bool> UpdateEmployee(int employeeId, string firstName, string lastName, string jobTitle, string department, decimal salary)
        {
            return employeeRepository.UpdateEmployee(employeeId, firstName, lastName, jobTitle, department, salary);
        }


    }
}
