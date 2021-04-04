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
        public PhaseType(ISkillLogic skillLogic, IEngagementLogic engagementLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.DocumentID);
            Field(x => x.PhaseID);
            Field(x => x.StartDate);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.Duration);
            FieldAsync<ListGraphType<SkillType>>("requiredSkills", resolve: async context => { return await skillLogic.GetByPhase(context.Source.PhaseID); });
            FieldAsync<ListGraphType<EngagementType>>("engagements", resolve: async context => { return await engagementLogic.GetByPhase(context.Source.PhaseID); });
        }
    }
}
