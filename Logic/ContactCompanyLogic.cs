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
    public class ContactCompanyLogic : Repository<Contact, FPISContext>, ICompanyContactLogic
    {
        public ContactCompanyLogic(FPISContext context) : base(context)
        {
        }

        public async Task<Contact> GetByIds(long companyId, long contactId)
        {
            try
            {
                return await context.Set<Contact>()
                            .FirstOrDefaultAsync(x => x.CompanyID == companyId && x.ContactID == contactId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }

        public async Task<List<Contact>> GetCompanysContacts(long companyId)
        {
            try
            {
                return await context.Set<Contact>().Where(x => x.CompanyID == companyId).ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">>>> " + ex.Message);
                return null;
            }
        }
    }
}
