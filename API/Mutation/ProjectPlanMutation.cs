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
    public class ProjectPlanMutation : ObjectGraphType
    {
        public ProjectPlanMutation(IProjectPlanLogic projectPlanLogic)
        {
            FieldAsync<BooleanGraphType>(
                "addProjectPlan",
                arguments: new QueryArguments(new QueryArgument<ProjectPlanInputType>
                {
                    Name = "plan"
                }),
                resolve: async context => { return await projectPlanLogic.Insert(context.GetArgument<ProjectPlan>("plan")); }
            );
            FieldAsync<BooleanGraphType>(
                "editProjectPlan",
                arguments: new QueryArguments(new QueryArgument<ProjectPlanInputType>
                {
                    Name = "plan"
                }),
                resolve: async context => { return await projectPlanLogic.Update(context.GetArgument<ProjectPlan>("plan")); }
            );
            FieldAsync<BooleanGraphType>(
                "deleteProjectPlan",
                arguments: new QueryArguments(new QueryArgument<ProjectPlanInputType>
                {
                    Name = "plan"
                }),
                resolve: async context => { return await projectPlanLogic.Delete(context.GetArgument<ProjectPlan>("plan")); }
            );
        }
    }
}
