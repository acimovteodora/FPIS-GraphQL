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
    public class PhaseLogic : Repository<Phase, FPISContext>, IPhaseLogic
    {
        public PhaseLogic(FPISContext context) : base(context)
        {
        }

        public async Task<Phase> GetById(int phaseId)
        {
            try
            {
                return await context.Set<Phase>()
                        .Include(x => x.RequiredSkills)
                        .Include(x => x.Engagements).ThenInclude(x => x.Student)
                        .FirstOrDefaultAsync(x => x.PhaseID == phaseId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Phase>> GetByProjectPlan(long projectId)
        {
            try
            {
                return await context.Set<Phase>()
                        .Include(x => x.Engagements).ThenInclude(x => x.Student)
                        .Include(x => x.ProjectPlan)
                        .Include(x => x.RequiredSkills)
                        .Where(x => x.DocumentID == projectId)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
