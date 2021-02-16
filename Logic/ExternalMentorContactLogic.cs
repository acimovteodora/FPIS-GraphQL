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
    public class ExternalMentorContactLogic : Repository<ExternalMentorContact, FPISContext>, IExternalMentorContactLogic
    {
        public ExternalMentorContactLogic(FPISContext context) : base(context)
        {
        }

        public async Task<List<ExternalMentorContact>> GetByIds(int mentorId, string value)
        {
            return await context.Set<ExternalMentorContact>()
                .Where(x => x.ExternalMentorMentorID == mentorId && x.Value.Contains(value))
                .ToListAsync();
        }

        public async Task<List<ExternalMentorContact>> GetContactsForMentor(int mentorId)
        {
            return await context.Set<ExternalMentorContact>()
                .Where(x => x.ExternalMentorMentorID == mentorId)
                .ToListAsync();
        }
    }
}
