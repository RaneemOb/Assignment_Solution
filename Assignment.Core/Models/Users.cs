﻿using System;
using System.Collections.Generic;

namespace Assignment.Core.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
