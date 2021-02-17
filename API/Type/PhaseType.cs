using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class PhaseType : ObjectGraphType<Phase>
    {
        public PhaseType(ISkillLogic skillLogic, IProjectLogic projectLogic, IEngagementLogic engagementLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.DocumentID);
            Field(x => x.PhaseID);
            Field(x => x.StartDate);
            Field(x => x.Description);
            Field(x => x.Duration);
            Field<ListGraphType<SkillType>>("skills", resolve: context => { return skillLogic.GetByPhase(context.Source.PhaseID); });
            Field<ListGraphType<EngagementType>>("engagements", resolve: context => { return engagementLogic.GetByPhase(context.Source.PhaseID); });
        }
    }
}
