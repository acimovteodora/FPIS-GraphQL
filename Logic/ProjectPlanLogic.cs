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
    public class ProjectPlanLogic : Repository<ProjectPlan, FPISContext>, IProjectPlanLogic
    {
        public ProjectPlanLogic(FPISContext context, IStudentLogic studentLogic) : base(context)
        {
        }

        public async Task<List<ProjectPlan>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<ProjectPlan>()
                        .Include(x => x.ComposedBy)
                        .Include(x => x.Phases)
                                .Include(x => x.Phases).ThenInclude(x => x.RequiredSkills)
                                .Include(x => x.Phases).ThenInclude(x => x.Engagements)
                        .Where(x => x.Title.Contains(criteria) || x.Note.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<ProjectPlan> GetById(int documentId)
        {
            try
            {
                return await context.Set<ProjectPlan>()
                        .Include(x => x.ComposedBy)
                        .Include(x => x.Phases)
                                .Include(x => x.Phases).ThenInclude(x => x.RequiredSkills)
                                .Include(x => x.Phases).ThenInclude(x => x.Engagements)
                        .FirstOrDefaultAsync(x => x.DocumentID == documentId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<ProjectPlan> GetByProject(long projectId)
        {
            try
            {
                return await context.Set<ProjectPlan>()
                        .Include(x => x.ComposedBy)
                        .Include(x => x.Phases).ThenInclude(x => x.RequiredSkills)
                        .Include(x => x.Phases).ThenInclude(x => x.Engagements).ThenInclude(x => x.Student)
                        .FirstOrDefaultAsync(x => x.ProjectID == projectId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async override Task<bool> Insert(ProjectPlan entity)
        {
            try
            {
                entity.ComposedBy = await context.Set<Employee>().FirstOrDefaultAsync(x => x.EmployeeID == entity.ComposedBy.EmployeeID);
                foreach (var phase in entity.Phases)
                {
                    if (phase.Engagements != null)
                    {
                        foreach (var eng in phase.Engagements)
                        {
                            eng.Student = await context.Set<Student>().FirstOrDefaultAsync(x => x.StudentID == eng.StudentID);
                            eng.Phase = phase;
                        }
                    }
                    if (phase.RequiredSkills != null)
                    {
                        foreach (var skill in phase.RequiredSkills)
                        {
                            skill.Phase = phase;
                        } 
                    }
                }
                await context.Set<ProjectPlan>().AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>> " + ex.Message);
                return false;
            }
        }

        public override async Task<bool> Update(ProjectPlan entity)
        {
            try
            {
                var planFromDb = await context.Set<ProjectPlan>()
                        .Include(x => x.ComposedBy)
                        .Include(x => x.Phases).ThenInclude(x => x.RequiredSkills)
                        .Include(x => x.Phases).ThenInclude(x => x.Engagements)
                        .FirstOrDefaultAsync(x => x.DocumentID == entity.DocumentID);
                if (planFromDb == null)
                    return false;
                //planFromDb.DateOfCompilation = entity.DateOfCompilation;
                planFromDb.Title = entity.Title;
                planFromDb.Duration = entity.Duration;
                planFromDb.EstimatedStartDate = entity.EstimatedStartDate;
                planFromDb.Note = entity.Note;

                List<Phase> phasesToDelete = new List<Phase>();
                foreach (var phase in planFromDb.Phases)
                {
                    if (!entity.Phases.Any(x => x.PhaseID == phase.PhaseID))
                    {
                        phasesToDelete.Add(phase);
                        continue;
                    }
                    foreach (var phase2 in entity.Phases)
                    {
                        if (phase.PhaseID == phase2.PhaseID)
                        {
                            if (!phase.Equals(phase2))
                            {
                                phase.Name = phase2.Name;
                                phase.StartDate = phase2.StartDate;
                                phase.Description = phase2.Description;
                                phase.Duration = phase2.Duration;
                            }

                            List<Skill> skillsToDelete = new List<Skill>();

                            foreach (var skill in phase.RequiredSkills)
                            {
                                if (!phase2.RequiredSkills.Any(x => x.SkillID == skill.SkillID))
                                {
                                    skillsToDelete.Add(skill);
                                    continue;
                                }
                                foreach (var skill2 in phase2.RequiredSkills)
                                {
                                    if (skill.SkillID == skill2.SkillID)
                                    {
                                        if (!skill2.Equals(skill))
                                        {
                                            skill.Name = skill2.Name;
                                            skill.Description = skill.Description;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (skillsToDelete.Count != 0)
                            {
                                foreach (var skill in skillsToDelete)
                                {
                                     phase.RequiredSkills.Remove(skill);
                                }
                            }

                            /* Dodavanje novih vestina*/
                            foreach (var skill in phase2.RequiredSkills)
                            {
                                if (!phase.RequiredSkills.Contains(skill))
                                    phase.RequiredSkills.Add(skill);
                            }

                            List<Engagement> engsToDelete = new List<Engagement>();

                            foreach (var eng in phase.Engagements)
                            {
                                if (!phase2.Engagements.Any(x => x.PhaseID == eng.PhaseID && x.StudentID == eng.StudentID))
                                {
                                    //phase.Engagements.Remove(eng);
                                    //if (phase.Engagements == null || phase.Engagements.Count == 0)
                                    //    break;
                                    engsToDelete.Add(eng);
                                    continue;
                                }
                            }
                            if(engsToDelete.Count != 0)
                            {
                                foreach (var eng in engsToDelete)
                                {
                                    phase.Engagements.Remove(eng);
                                }
                            }

                            /* Dodavanje novih zaduzenja*/
                            foreach (var eng in phase2.Engagements)
                            {
                                if (!phase.Engagements.Contains(eng))
                                    phase.Engagements.Add(eng);
                            }
                            break;
                        }
                    }
                }
                if(phasesToDelete.Count != 0)
                {
                    foreach (var phase in phasesToDelete)
                    {
                        planFromDb.Phases.Remove(phase);
                    }
                }

                /* Dodavanje novih faza */
                foreach (var phase in entity.Phases)
                {
                    if (!planFromDb.Phases.Contains(phase))
                        planFromDb.Phases.Add(phase);
                }

                context.Set<ProjectPlan>().Update(planFromDb);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return false;
            }
        }
    }
}
