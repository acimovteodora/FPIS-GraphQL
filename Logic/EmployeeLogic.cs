using DataAccessLayer;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EmployeeLogic : Repository<Employee, FPISContext>, IEmployeeLogic
    {
        public EmployeeLogic(FPISContext context) : base(context)
        {
        }
        public async Task<Employee> GetByID(long id)
        {
            try
            {
                return await context.Set<Employee>().FirstOrDefaultAsync(x => x.EmployeeID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Employee>> GetObjectByName(string value)
        {
            try
            {
                return await context.Set<Employee>()
                        .Where(x => x.Name.Contains(value) || x.Surname.Contains(value))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<Employee> Login(string username, string password)
        {
            try
            {
                var user = await context.Set<Employee>().FirstOrDefaultAsync(x => x.Username == username);
                if (user == null)
                    return null;
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;
                return user;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }

        public async Task<bool> UserExists(string username)
        {
            try
            {
                if (await context.Set<Employee>().AnyAsync(x => x.Username == username))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return false;
            }
        }

        public async Task<Employee> GetObjectByUsername(string username)
        {
            try
            {
                if (!await UserExists(username))
                    return null;
                return await context.Set<Employee>().FirstOrDefaultAsync(x => x.Username == username);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        
        //public async Task<Employee> Register(Employee employee, string password)
        //{
        //    try
        //    {
        //        byte[] passwordHash, passwordSalt;
        //        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //        employee.PasswordHash = passwordHash;
        //        employee.PasswordSalt = passwordSalt;

        //        //await _context.Employees.AddAsync(employee);
        //        await context.SaveChangesAsync();

        //        return employee;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(">>>> " + ex.Message);
        //        return null;
        //    }
        //}

        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}
    }
}
