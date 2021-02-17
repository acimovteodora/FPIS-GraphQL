using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class CompanyType : ObjectGraphType<Company>
    {
        public CompanyType()
        {
            Field(x => x.CompanyID);
            Field(x => x.CompanyUsername);
            Field(x => x.Name);
            Field(x => x.PasswordHash);
            Field(x => x.PasswordSalt);
        }
    }
}
