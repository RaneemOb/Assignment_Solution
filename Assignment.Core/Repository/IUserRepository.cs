
using Assignment.Core.Models;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Core.Repository
{
    public interface IUserRepository
    {
        public  Task<LoginResult> Login(string username, string password);
        public  Task<int> SignUp(string username, string password, string role);
    }
}
