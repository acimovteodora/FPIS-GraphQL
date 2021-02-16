using DataAccessLayer;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ExternalMentorLogic : Repository<ExternalMentor, FPISContext>, IExternalMentorLogic
    {
        public ExternalMentorLogic(FPISContext context) : base(context)
        {
        }

        public async Task<List<ExternalMentor>> GetByCriteria(string criteria)
        {
            return await context.Set<ExternalMentor>()
                .Include(x => x.Contacts)
                .Where(x => x.Name.Contains(criteria) || x.Surname.Contains(criteria))
                .ToListAsync();
        }

        public async Task<ExternalMentor> GetById(int id)
        {
            return await context.Set<ExternalMentor>()
                .Include(x => x.Contacts).
                FirstOrDefaultAsync(x => x.MentorID == id);
        }
    }
}
