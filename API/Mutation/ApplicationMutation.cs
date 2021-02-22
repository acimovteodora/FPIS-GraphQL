using API.Type;
using GraphQL;
using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mutation
{
    public class ApplicationMutation : ObjectGraphType
    {
        public ApplicationMutation(IApplicationLogic applicationLogic)
        {
            FieldAsync<BooleanGraphType>(
                "addApplication",
                arguments: new QueryArguments(new QueryArgument<ApplicationInputType>
                {
                    Name = "app"
                }),
                resolve: async context => { return await applicationLogic.Insert(context.GetArgument<Application>("app")); }
            );
            FieldAsync<BooleanGraphType>(
                "editApplication",
                arguments: new QueryArguments(new QueryArgument<ApplicationInputType>
                {
                    Name = "app"
                }),
                resolve: async context => { return await applicationLogic.Update(context.GetArgument<Application>("app")); }
            );
            FieldAsync<BooleanGraphType>(
                "deleteApplication",
                arguments: new QueryArguments(new QueryArgument<ApplicationInputType>
                {
                    Name = "app"
                }),
                resolve: async context => { return await applicationLogic.Delete(context.GetArgument<Application>("app")); }
            );
        }
    }
}
