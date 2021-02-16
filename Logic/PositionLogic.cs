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
    public class PositionLogic : Repository<Position, FPISContext>, IPositionLogic
    {
        public PositionLogic(FPISContext context) : base(context)
        {
        }
        public async Task<List<Position>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<Position>()
                        .Where(x => x.Name.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<Position> GetById(int id)
        {
            try
            {
                return await context.Set<Position>().FirstOrDefaultAsync(x => x.PositionID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
