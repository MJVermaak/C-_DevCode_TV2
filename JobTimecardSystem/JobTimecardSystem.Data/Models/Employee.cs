using System;
using System.Collections.Generic;
using System.Text;

namespace JobTimecardSystem.Data.Models
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string EmployeeCode { get; set; } = string.Empty;
        public virtual string FirstName { get; set; } = string.Empty;
        public virtual string LastName { get; set; } = string.Empty;
        public virtual string Role { get; set; } = string.Empty;
        public virtual string Email { get; set; } = string.Empty;

        public virtual string FullName => $"{FirstName} {LastName}".Trim();
    }
}