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
    public class EngagementLogic : Repository<Engagement, FPISContext>, IEngagementLogic
    {
        public EngagementLogic(FPISContext context) : base(context)
        {
        }

        public async Task<List<Engagement>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<Engagement>()
                        .Include(x => x.Phase)
                        .Include(x => x.Student)
                        .Where(x => x.Name.Contains(criteria) || x.Description.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<Engagement> GetById(int phaseId, int studentId)
        {
            try
            {
                return await context.Set<Engagement>()
                        .Include(x => x.Phase)
                        .Include(x => x.Student)
                        .FirstOrDefaultAsync(x => x.PhaseID == phaseId && x.StudentID == studentId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Engagement>> GetByPhase(int phaseId)
        {
            try
            {
                return await context.Set<Engagement>()
                        .Include(x => x.Phase)
                        .Include(x => x.Student)
                        .Where(x => x.PhaseID == phaseId)
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
