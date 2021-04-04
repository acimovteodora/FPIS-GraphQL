using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class EngagementInputType : InputObjectGraphType
    {
        public EngagementInputType()
        {
            Field<IntGraphType>("studentID");
            Field<IntGraphType>("phaseID");
            Field<LongGraphType>("projectID");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            FieldAsync<StudentInputType>("student");
        }
    }
}
