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
    public class CompanyQuery : ObjectGraphType
    {
        public CompanyQuery(ICompanyLogic companyLogic)
        {
            FieldAsync<CompanyType>(
                "companyById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "id"
                }),
                resolve: async context => { return await companyLogic.GetById(context.GetArgument<long>("id")); }
            );
        }
    }
}
