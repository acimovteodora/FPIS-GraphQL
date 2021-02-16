using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IEngagementLogic : IRepository<Engagement>
    {
        Task<List<Engagement>> GetByPhase(int phaseId);
        Task<List<Engagement>> GetByCriteria(string criteria);
        Task<Engagement> GetById(int phaseId, int studentId);
    }
}
