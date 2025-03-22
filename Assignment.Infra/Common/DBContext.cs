using Assignment.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.SqlClient;
namespace Assignment.Infra.Common
{
    public class DBContext : DbContext, IDBContext
    {
        private DbConnection _Connection;
        private readonly IConfiguration _configuration;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
                    _Connection.Open();
                }
                else if (_Connection.State != ConnectionState.Open)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }

        public bool TestConnection()
        {
            using (var conn = new SqlConnection("Server=DESKTOP-U38IROU;Database=My_First_Database;Integrated Security=True;TrustServerCertificate=True;"))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection successful!");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Connection failed: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
