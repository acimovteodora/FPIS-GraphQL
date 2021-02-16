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
    public class CompanyLogic : Repository<Company, FPISContext>, ICompanyLogic
    {
        public CompanyLogic(FPISContext context) : base(context)
        {
        }
        public async Task<List<Company>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<Company>()
                        .Include(x => x.Contacts)
                        .Include(x => x.Locations)
                        .Include(x => x.Mentors)
                        .Where(x => x.Name.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<Company> GetById(long id)
        {
            try
            {
                return await context.Set<Company>()
                        .Include(x => x.Contacts)
                        .Include(x => x.Locations)
                        .Include(x => x.Mentors)
                        .FirstOrDefaultAsync(x => x.CompanyID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
