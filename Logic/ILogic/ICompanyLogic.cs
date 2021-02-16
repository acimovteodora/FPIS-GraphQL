using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICompanyLogic : IRepository<Company>
    {
        Task<List<Company>> GetByCriteria(string criteria);
        Task<Company> GetById(long id);
    }
}
