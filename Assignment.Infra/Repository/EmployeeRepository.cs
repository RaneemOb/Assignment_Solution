using Assignment.Core.Models;
using Assignment.Core.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infra.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly My_First_DatabaseContext _context;

        public EmployeeRepository(My_First_DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Employees>> GetAllEmployees()
        {
            var result = await _context.Employees
         .FromSqlRaw("EXEC dbo.SelectAllEmployees")
         .ToListAsync();  

            return result;
        }

        public async Task<bool> UpdateEmployee(int employeeId, string firstName, string lastName, string jobTitle, string department, decimal salary)
        {
            var parameters = new SqlParameter[]
            {
        new SqlParameter("@EmployeeID", SqlDbType.Int) { Value = employeeId },
        new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = firstName },
        new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = lastName },
        new SqlParameter("@JobTitle", SqlDbType.NVarChar) { Value = jobTitle },
        new SqlParameter("@Department", SqlDbType.NVarChar) { Value = department },
        new SqlParameter("@Salary", SqlDbType.Decimal) { Value = salary }
            };

            
            int rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.UpdateEmployee @EmployeeID, @FirstName, @LastName, @JobTitle, @Department, @Salary",
                parameters
            );

            
            return rowsAffected > 0;
        }
        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var parameter = new SqlParameter("@EmployeeID", SqlDbType.Int) { Value = employeeId };

           
            int rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.DeleteEmployee @EmployeeID",
                parameter
            );

    
            return rowsAffected > 0;
        }
        public async Task<bool> InsertEmployee( string firstName, string lastName, string jobTitle, string department, decimal salary)
        {
            var parameters = new SqlParameter[]
            {
       
        new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = firstName },
        new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = lastName },
        new SqlParameter("@JobTitle", SqlDbType.NVarChar) { Value = jobTitle },
        new SqlParameter("@Department", SqlDbType.NVarChar) { Value = department },
        new SqlParameter("@Salary", SqlDbType.Decimal) { Value = salary }
            };

 
            int rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.InsertEmployee  @FirstName, @LastName, @JobTitle, @Department, @Salary",
                parameters
            );

            return rowsAffected > 0;
        }


    }
}
