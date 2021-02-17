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
    public class SkillQuery : ObjectGraphType
    {
        public SkillQuery(ISkillLogic skillLogic)
        {
            Field<SkillType>(
                "skillById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "id"
                }),
                resolve: context => { return skillLogic.GetById(context.GetArgument<int>("id")); }
            );
            Field<ListGraphType<SkillType>>(
                "skillsByPhase",
                arguments: new QueryArguments(new QueryArgument<IntGraphType>
                {
                    Name = "phaseId"
                }),
                resolve: context => { return skillLogic.GetByPhase(context.GetArgument<int>("phaseId")); }
            );
        }
    }
}
