using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class SkillType : ObjectGraphType<Skill>
    {
        public SkillType()
        {
            Field(x => x.DocumentID);
            Field(x => x.ProjectID);
            Field(x => x.PhaseID);
            Field(x => x.SkillID);
            Field(x => x.Name);
            Field(x => x.Description);
        }
    }
}
