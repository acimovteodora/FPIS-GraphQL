using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IStudentLogic : IRepository<Student>
    {
        Task<Student> GetById(int id);
        Task<List<Student>> GetByCriteria(string criteria);
        Task<List<Student>> GetAcceptedByProject(long projectId);
    }
}
