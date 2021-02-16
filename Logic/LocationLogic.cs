using DataAccessLayer;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LocationLogic : Repository<Location, FPISContext>, ILocationLogic
    {
        public LocationLogic(FPISContext context) : base(context)
        {
        }
        public async Task<Location> GetById(long companyId, long cityId)
        {
            return await context.Set<Location>().FirstOrDefaultAsync(x => x.CompanyID == companyId && x.CityID == cityId);
        }
    }
}
