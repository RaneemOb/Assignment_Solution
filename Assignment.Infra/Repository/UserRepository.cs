using Assignment.Core.Common;
using Assignment.Core.Models;
using Assignment.Core.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly My_First_DatabaseContext _context;

        public UserRepository(My_First_DatabaseContext context)
        {
            _context = context;
        }
        public async Task<LoginResult> Login(string username, string password)
        {
            
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                var parameters = new SqlParameter[]
                {
            new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
            new SqlParameter("@Password", SqlDbType.NVarChar) { Value = hashedPassword }
                };

                
                var loginResults = await _context.LoginResult
                    .FromSqlRaw("EXEC dbo.LoginUser @Username, @Password", parameters)
                    .ToListAsync(); 

                var loginResult = loginResults.FirstOrDefault(); 

                return loginResult; 
            }
        }


        public async Task<int> SignUp(string username, string password, string role)
        {
            var parameters = new[]
            {
        new SqlParameter("@Username", username),
        new SqlParameter("@Password", password),
        new SqlParameter("@Role", role)
    };

            return await _context.Database.ExecuteSqlRawAsync("EXEC dbo.SignUpUser @Username, @Password, @Role", parameters);
        }


    }
}
    

