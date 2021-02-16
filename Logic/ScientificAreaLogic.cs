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
    public class ScientificAreaLogic : Repository<ScientificArea, FPISContext>, IScientificAreaLogic
    {
        public ScientificAreaLogic(FPISContext context) : base(context)
        {
        }

        public async Task<List<ScientificArea>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<ScientificArea>()
                        .Where(x => x.Name.Contains(criteria) || x.Description.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<ScientificArea> GetById(long id)
        {
            try
            {
                return await context.Set<ScientificArea>().FirstOrDefaultAsync(x => x.ScientificAreaID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
