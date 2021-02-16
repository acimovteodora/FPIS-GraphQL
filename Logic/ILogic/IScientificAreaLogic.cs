using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IScientificAreaLogic : IRepository<ScientificArea>
    {
        Task<List<ScientificArea>> GetByCriteria(string criteria);
        Task<ScientificArea> GetById(long scientificAreaId);
    }
}
