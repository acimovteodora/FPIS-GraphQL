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
    public class ApplicationLogic : Repository<Application, FPISContext>, IApplicationLogic
    {
        public ApplicationLogic(FPISContext context, IStudentLogic studentLogic, IProjectLogic projectLogic) : base(context)
        {
        }

        public async Task<List<Application>> GetAccepted(long projectId)
        {
            return await context.Set<Application>()
                .Include(x => x.Project)
                .Include(x => x.Student)
                .Where(x => x.ProjectID == projectId && x.Accepted == true)
                .ToListAsync();
        }

        public async Task<List<Application>> GetAllForProject(long projectId)
        {
            return await context.Set<Application>()
                .Include(x => x.Project)
                .Include(x => x.Student)
                .Where(x => x.ProjectID == projectId)
                .ToListAsync();
        }

        public async Task<List<Application>> GetAllForProjectAccepted(long projectId)
        {
            return await context.Set<Application>()
                .Include(x => x.Student)
                .Where(x => x.ProjectID == projectId && x.Accepted == true)
                .ToListAsync();
        }

        public async Task<List<Application>> GetByCriteriaForProject(long projectId,string criteria)
        {
            return await context.Set<Application>()
                .Include(x => x.Student)
                .Where(x => x.ProjectID == projectId 
                        && (x.Student.Name.Contains(criteria) || x.Student.Surname.Contains(criteria) || x.Student.Index.Contains(criteria)))
                .ToListAsync();
        }

        public async Task<Application> GetById(long projectId, int studentId)
        {
            return await context.Set<Application>()
                .Include(x => x.Project)
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.ProjectID == projectId && x.StudentID == studentId);
        }

        public override async Task<bool> Insert(Application entity)
        {
            try
            {
                entity.Student = await context.Set<Student>().FirstOrDefaultAsync(x => x.StudentID == entity.StudentID);
                entity.Project = await context.Set<Project>()
                    .Include(x => x.Documents)
                    .Include(x => x.DecisionMaker)
                    .Include(x => x.InternalMentor)
                    .Include(x => x.ProjectProposal)
                    .Include(x => x.ProjectProposal.Company)
                    .Include(x => x.ProjectProposal.Company.Contacts)
                    .Include(x => x.ProjectProposal.Subjects)
                    .Include(x => x.ProjectProposal.ExternalMentor)
                    .FirstOrDefaultAsync(x => x.ProjectID == entity.ProjectID);
                entity.ExperienceInPreviousProjects = hasExperience(entity.StudentID);
                await context.Set<Application>().AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
                return false;
            }
        }

        private bool hasExperience(int id)
        {
            var experience = context.Set<Application>()
                .Where(a => a.StudentID == id && a.Accepted == true)
                .ToListAsync();
            if (experience.AsyncState == null)
                return false;
            return true;
        }

        public async override Task<bool> Delete(Application entity)
        {
            try
            {
                var engagement = await context.Set<Engagement>().FirstOrDefaultAsync(x => x.ProjectID == entity.ProjectID && x.StudentID == entity.StudentID);
                if (engagement != null)
                    context.Set<Engagement>().Remove(engagement);
                context.Set<Application>().Remove(entity);
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>>" + ex.Message);
                return false;
            }
        }
    }
}
