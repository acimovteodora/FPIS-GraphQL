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
            Field<PhaseType>(
                "phasetById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "id"
                }),
                resolve: context => { return phaseLogic.GetById(context.GetArgument<int>("id")); }
            );
            Field<ListGraphType<PhaseType>>(
                "phasesByProjectPlan",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectPlanId"
                }),
                resolve: context => { return phaseLogic.GetByProjectPlan(context.GetArgument<long>("projectPlanId")); }
            );
        }
    }
}
