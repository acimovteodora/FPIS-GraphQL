using DataAccessLayer;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public class StudentLogic : Repository<Student,FPISContext>, IStudentLogic
    {
        public StudentLogic(FPISContext context) : base(context)
        {
        }
        public async Task<Student> GetById(int id)
        {
            try
            {
                return await context.Set<Student>().FirstOrDefaultAsync(s => s.StudentID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Student>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<Student>()
                        .Where(s => s.Name.Contains(criteria) || s.Surname.Contains(criteria) || s.Index.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Student>> GetAcceptedByProject(long projectId)
        {
            try
            {
                var applications = await context.Set<Application>()
                        .Include(a => a.Student)
                        .Where(a => a.ProjectID == projectId && a.Accepted == true)
                        .ToListAsync();
                List<Student> students = new List<Student>();
                foreach (Application application in applications)
                {
                    students.Add(application.Student);
                }
                return students;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
