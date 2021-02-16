using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProjectProposalLogic : IRepository<ProjectProposal>
    {
        Task<List<ProjectProposal>> GetByCriteria(string criteria);
        Task<ProjectProposal> GetById(long id);
    }
}
