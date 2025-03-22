using Assignment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Repository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employees>> GetAllEmployees();
        public Task<bool> UpdateEmployee(int employeeId, string firstName, string lastName, string jobTitle, string department, decimal salary);
        public  Task<bool> DeleteEmployee(int employeeId);

        public  Task<bool> InsertEmployee( string firstName, string lastName, string jobTitle, string department, decimal salary);
        

        }


}
