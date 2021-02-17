using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(x => x.EmployeeID);
            Field(x => x.Name);
            Field(x => x.Surname);
            Field(x => x.PasswordHash);
            Field(x => x.PasswordSalt);
            Field(x => x.Username);
        }
    }
}
