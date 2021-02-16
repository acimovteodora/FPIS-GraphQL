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
    public class SkillLogic : Repository<Skill, FPISContext>, ISkillLogic
    {
        public SkillLogic(FPISContext context) : base(context)
        {
        }

        public async Task<Skill> GetById(int skillId)
        {
            try
            {
                return await context.Set<Skill>().FirstOrDefaultAsync(x => x.SkillID == skillId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Skill>> GetByPhase(int phaseId)
        {
            try
            {
                return await context.Set<Skill>().Where(x => x.PhaseID == phaseId).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
