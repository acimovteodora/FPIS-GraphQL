using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IPositionLogic : IRepository<Position>
    {
        Task<Position> GetById(int id);
        Task<List<Position>> GetByCriteria(string criteria);
    }
}
