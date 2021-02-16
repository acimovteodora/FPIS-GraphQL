using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IExternalMentorLogic : IRepository<ExternalMentor>
    {
        Task<ExternalMentor> GetById(int id);
        Task<List<ExternalMentor>> GetByCriteria(string criteria);
    }
}
