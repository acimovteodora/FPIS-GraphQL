using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IExternalMentorContactLogic : IRepository<ExternalMentorContact>
    {
        Task<List<ExternalMentorContact>> GetContactsForMentor(int mentorId);
        Task<List<ExternalMentorContact>> GetByIds(int mentorId, string value);
    }
}
