using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class ApplicationInputType : InputObjectGraphType
    {
        public ApplicationInputType()
        {
            Field<IntGraphType>("studentID");
            Field<IntGraphType>("projectID");
            Field<BooleanGraphType>("experienceInPreviousProjects");
            Field<BooleanGraphType>("accepted");
            Field<StringGraphType>("reason");
            Field<DateTimeGraphType>("startDate");
            Field<DateTimeGraphType>("endDate");
        }
    }
}
