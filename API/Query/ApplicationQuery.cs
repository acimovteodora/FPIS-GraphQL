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
            Field<ApplicationType>(
                "applicationByIds",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }, new QueryArgument<IntGraphType>
                {
                    Name = "studentId"
                }),
                resolve: context => { return applicationLogic.GetById(context.GetArgument<long>("projectId"), context.GetArgument<int>("studentId")); }
            );
            Field<ListGraphType<ApplicationType>>(
                "applicationsByProject",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }),
                resolve: context => { return applicationLogic.GetAllForProject(context.GetArgument<long>("projectId")); }
            );
            Field<ListGraphType<ApplicationType>>(
                "applicationsByProjectAccepted",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }),
                resolve: context => { return applicationLogic.GetAllForProjectAccepted(context.GetArgument<long>("projectId")); }
            );
            Field<ListGraphType<ApplicationType>>(
                "applicationsByCriteria",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }, new QueryArgument<StringGraphType>
                {
                    Name = "criteria"
                }),
                resolve: context => { return applicationLogic.GetByCriteriaForProject(context.GetArgument<long>("projectId"), context.GetArgument<string>("criteria")); }
            );
        }
    }
}
