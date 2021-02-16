using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Employee
    {
        public long EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<EmployeePosition> Positions { get; set; }
    }
}
