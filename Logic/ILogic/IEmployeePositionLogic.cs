using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IEmployeePositionLogic : IRepository<EmployeePosition>
    {
        Task<List<EmployeePosition>> GetById(int employeeId);
        Task<EmployeePosition> Find(int employeeId, int positionId);
    }
}
