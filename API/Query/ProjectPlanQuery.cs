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
    public class ProjectPlanQuery : ObjectGraphType
    {
        public ProjectPlanQuery(IProjectPlanLogic projectPlanLogic)
        {
            Field<ProjectPlanType>(
                "planByDocument",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "documentId"
                }),
                resolve: context => { return projectPlanLogic.GetById(context.GetArgument<int>("documentId")); }
            );
            Field<ProjectPlanType>(
                "planByProject",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }),
                resolve: context => { return projectPlanLogic.GetByProject(context.GetArgument<long>("projectId")); }
            );
        }
    }
}
