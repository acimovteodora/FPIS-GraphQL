using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ISkillLogic : IRepository<Skill>
    {
        Task<List<Skill>> GetByPhase(int phaseId);
        Task<Skill> GetById(int skillId);
    }
}
