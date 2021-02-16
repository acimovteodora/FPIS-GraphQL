using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IEmployeeLogic : IRepository<Employee>
    {
        Task<List<Employee>> GetObjectByName(string value);
        Task<Employee> GetByID(long id);
        Task<bool> UserExists(string username);
        //Task<Employee> Register(Employee employee, string password);
        Task<Employee> Login(string username, string password);
        Task<Employee> GetObjectByUsername(string username);
    }
}
