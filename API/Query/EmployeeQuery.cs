using API.Type;
using GraphQL;
using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Query
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeLogic employeeLogic)
        {
            FieldAsync<EmployeeType>(
                "employeeById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "id"
                }),
                resolve: async context => { return await employeeLogic.GetByID(context.GetArgument<long>("id")); }
            );
        }
    }
}
