using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ILocationLogic : IRepository<Location>
    {
        Task<Location> GetById(long companyId, long cityId);
    }
}
