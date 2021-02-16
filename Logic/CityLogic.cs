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
    public class CityLogic : Repository<City,FPISContext>, ICityLogic
    {
        public CityLogic(FPISContext context) : base(context)
        {
        }

        public async Task<List<City>> GetByCriteria(string criteria)
        {
            try
            {
                return await context.Set<City>()
                        .Where(x => x.Name.Contains(criteria) || x.PostalCode.Contains(criteria))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<City> GetById(float id)
        {
            try
            {
                return await context.Set<City>().FirstOrDefaultAsync(x => x.CityID == id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
