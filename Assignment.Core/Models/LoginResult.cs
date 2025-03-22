using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Core.Models
{
    public class LoginResult
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
