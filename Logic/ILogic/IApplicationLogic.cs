using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IApplicationLogic : IRepository<Application>
    {
        Task<List<Application>> GetAllForProject(long projectId);
        Task<List<Application>> GetAllForProjectAccepted(long projectId);
        Task<List<Application>> GetByCriteriaForProject(long projectId, string criteria);
        Task<Application> GetById(long projectId, int studentId);
        Task<List<Application>> GetAccepted(long projectId);
    }
}
