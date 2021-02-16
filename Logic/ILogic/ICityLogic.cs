using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICityLogic : IRepository<City>
    {
        Task<City> GetById(float id);
        Task<List<City>> GetByCriteria(string criteria);
    }
}
