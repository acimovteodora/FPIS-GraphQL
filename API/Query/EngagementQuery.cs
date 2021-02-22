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
    public class EngagementQuery : ObjectGraphType
    {
        public EngagementQuery(IEngagementLogic engagementLogic)
        {
            FieldAsync<EngagementType>(
                "engagementByIds",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "phaseId"
                }, new QueryArgument<IntGraphType>
                {
                    Name = "studentId"
                }),
                resolve: async context => { return await engagementLogic.GetById(context.GetArgument<int>("phaseId"), context.GetArgument<int>("studentId")); }
            );
            FieldAsync<ListGraphType<EngagementType>>(
                "engagementByPhase",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "phaseId"
                }),
                resolve: async context => { return await engagementLogic.GetByPhase(context.GetArgument<int>("phaseId")); }
            );
        }
    }
}
