using API.Type;
using GraphQL;
using GraphQL.Types;
using Logic.ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Query
{
    public class ProjectPlanQuery : ObjectGraphType
    {
        public ProjectPlanQuery(IProjectPlanLogic projectPlanLogic)
        {
            FieldAsync<ProjectPlanType>(
                "planByDocument",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "documentId"
                }),
                resolve: async context => { return await projectPlanLogic.GetById(context.GetArgument<int>("documentId")); }
            );
            FieldAsync<ProjectPlanType2>(
                "planByProject",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectID"
                }),
                resolve: async context => { var plans = await projectPlanLogic.GetByProject(context.GetArgument<long>("projectID"));
                    return plans; }
            );
        }
    }
}
