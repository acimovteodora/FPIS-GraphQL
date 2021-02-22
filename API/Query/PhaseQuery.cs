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
    public class PhaseQuery : ObjectGraphType
    {
        public PhaseQuery(IPhaseLogic phaseLogic)
        {
            FieldAsync<PhaseType>(
                "phasetById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "id"
                }),
                resolve: async context => { return await phaseLogic.GetById(context.GetArgument<int>("id")); }
            );
            FieldAsync<ListGraphType<PhaseType>>(
                "phasesByProjectPlan",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectPlanId"
                }),
                resolve: async context => { return await phaseLogic.GetByProjectPlan(context.GetArgument<long>("projectPlanId")); }
            );
        }
    }
}
