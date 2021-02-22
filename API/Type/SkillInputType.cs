using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class SkillInputType : InputObjectGraphType
    {
        public SkillInputType()
        {
            Field<LongGraphType>("projectID");
            Field<IntGraphType>("skillID");
            Field<IntGraphType>("phaseID");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
        }
    }
}
