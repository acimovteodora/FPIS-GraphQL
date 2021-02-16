using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProjectLogic : IRepository<Project>
    {
        Task<List<Project>> GetByCriteria(string criteria);
        Task<Project> GetById(long id);
    }
}
