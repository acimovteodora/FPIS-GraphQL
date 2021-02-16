using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IPhaseLogic : IRepository<Phase>
    {
        Task<List<Phase>> GetByProjectPlan(long projectPlanId);
        Task<Phase> GetById(int phaseId);
    }
}
