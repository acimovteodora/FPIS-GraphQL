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
    public class ProjectLogic : Repository<Project, FPISContext>, IProjectLogic
    {
        public ProjectLogic(FPISContext context) : base(context)
        {
        }

        public async override Task<List<Project>> GetAll()
        {
            try
            {
                return await context.Set<Project>()
                        .Include(x => x.ProjectProposal)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
        public async Task<List<Project>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<Project>()
                        .Include(x => x.Documents)
                        .Include(x => x.DecisionMaker)
                        .Include(x => x.InternalMentor)
                        .Include(x => x.ProjectProposal)
                        .Include(x => x.ProjectProposal.Company)
                        .Include(x => x.ProjectProposal.Company.Contacts)
                        .Include(x => x.ProjectProposal.Subjects)
                        .Include(x => x.ProjectProposal.ExternalMentor)
                        .Where(x => x.Note.Contains(criteria) || x.Description.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<Project> GetById(long id)
        {
            try
            {
                return await context.Set<Project>()
                        .Include(x => x.Documents)
                        .Include(x => x.DecisionMaker)
                        .Include(x => x.InternalMentor)
                        .Include(x => x.ProjectProposal)
                        .Include(x => x.ProjectProposal.Company)
                        .Include(x => x.ProjectProposal.Company.Contacts)
                        .Include(x => x.ProjectProposal.Subjects)
                        .Include(x => x.ProjectProposal.ExternalMentor)
                        .FirstOrDefaultAsync(x => x.ProjectID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
