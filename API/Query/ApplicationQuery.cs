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
    public class ApplicationQuery : ObjectGraphType
    {
        public ApplicationQuery(IApplicationLogic applicationLogic)
        {
            FieldAsync<ApplicationType>(
                "applicationByIds",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }, new QueryArgument<IntGraphType>
                {
                    Name = "studentId"
                }),
                resolve: async context => { return await applicationLogic.GetById(context.GetArgument<long>("projectId"), context.GetArgument<int>("studentId")); }
            );
            FieldAsync<ListGraphType<ApplicationType>>(
                "applicationsByProject",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }),
                resolve: async context => { return await applicationLogic.GetAllForProject(context.GetArgument<long>("projectId")); }
            );
            FieldAsync<ListGraphType<ApplicationType>>(
                "applicationsByProjectAccepted",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }),
                resolve: async context => { return await applicationLogic.GetAllForProjectAccepted(context.GetArgument<long>("projectId")); }
            );
            FieldAsync<ListGraphType<ApplicationType>>(
                "applicationsByCriteria",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }, new QueryArgument<StringGraphType>
                {
                    Name = "criteria"
                }),
                resolve: async context => { return await applicationLogic.GetByCriteriaForProject(context.GetArgument<long>("projectId"), context.GetArgument<string>("criteria")); }
            );
        }
    }
}
