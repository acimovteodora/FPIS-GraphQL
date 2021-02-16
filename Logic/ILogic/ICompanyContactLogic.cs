using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICompanyContactLogic : IRepository<Contact>
    {
        Task<List<Contact>> GetCompanysContacts(long companyId);
        Task<Contact> GetByIds(long companyId, long contactId);
    }
}
