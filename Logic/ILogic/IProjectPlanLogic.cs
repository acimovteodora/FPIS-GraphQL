using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProjectPlanLogic : IRepository<ProjectPlan>
    {
        Task<ProjectPlan> GetByProject(long projectId);
        Task<List<ProjectPlan>> GetByCriteria(string criteria);
        Task<ProjectPlan> GetById(int documentId);
    }
}
