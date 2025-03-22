using Assignment.Core.Models;
using Assignment.Core.Repository;
using Assignment.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }



        public async Task<LoginResult> Login(string username, string password)
        {
            return await userRepository.Login(username, password);
        }



      

        async Task<int> IUserService.SignUp(string username, string password, string role)
        {
            return await userRepository.SignUp(username, password, role);
        }
    }
}
