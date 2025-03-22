using System;
using System.Collections.Generic;

namespace Assignment.Core.Models
{
    public class EmployeeView
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public decimal? Salary { get; set; }
    }
}
