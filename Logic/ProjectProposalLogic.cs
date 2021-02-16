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
    public class ProjectProposalLogic : Repository<ProjectProposal, FPISContext>, IProjectProposalLogic
    {
        public ProjectProposalLogic(FPISContext context) : base(context)
        {
        }

        public async Task<List<ProjectProposal>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<ProjectProposal>()
                        .Include(x => x.Company)
                        .Include(x => x.Company.Contacts)
                        .Include(x => x.ExternalMentor)
                        .Include(x => x.ExternalMentor.Contacts)
                        .Include(x => x.Subjects)
                        .Where(x => x.Name.Contains(criteria) || x.Description.Contains(criteria) || x.Activities.Contains(criteria) || x.Goal.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<ProjectProposal> GetById(long id)
        {
            try
            {
                return await context.Set<ProjectProposal>()
                        .Include(x => x.Company)
                        .Include(x => x.Company.Contacts)
                        .Include(x => x.ExternalMentor)
                        .Include(x => x.ExternalMentor.Contacts)
                        .Include(x => x.Subjects)
                        .FirstOrDefaultAsync(x => x.ProjectProposalID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
