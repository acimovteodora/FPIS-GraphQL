using DataAccessLayer;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EmployeePositionLogic : Repository<EmployeePosition, FPISContext>, IEmployeePositionLogic
    {
        public EmployeePositionLogic(FPISContext context) : base(context)
        {
        }

        public async Task<EmployeePosition> Find(int employeeId, int positionId)
        {
            try
            {
                return await context.Set<EmployeePosition>()
                        .Include(emp => emp.Employee)
                        .Include(pos => pos.Position)
                        .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<EmployeePosition>> GetById(int employeeId)
        {
            try
            {
                return await context.Set<EmployeePosition>()
                        .Include(emp => emp.Employee)
                        .Include(pos => pos.Position)
                        .Where(x => x.EmployeeID == employeeId)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

    }
}
