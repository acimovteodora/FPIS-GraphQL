using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class PhaseInputType : InputObjectGraphType
    {
        public PhaseInputType()
        {
            Field<IntGraphType>("documentID");
            Field<IntGraphType>("phaseID");
            Field<LongGraphType>("projectID");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<IntGraphType>("duration");
            Field<DateTimeGraphType>("startDate");
            Field<ListGraphType<SkillInputType>>("requiredSkills");
            Field<ListGraphType<EngagementInputType>>("engagements");
        }
    }
}
