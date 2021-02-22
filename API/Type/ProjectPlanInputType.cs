using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class ProjectPlanInputType : InputObjectGraphType
    {
        public ProjectPlanInputType()
        {
            Field<IntGraphType>("duration");
            Field<IntGraphType>("documentID");
            Field<LongGraphType>("projectID");
            Field<StringGraphType>("title");
            Field<StringGraphType>("note");
            Field<DateTimeGraphType>("estimatedStartDate");
            Field<DateTimeGraphType>("dateOfCompilation");
            Field<EmployeeInputType>("composedBy");
            Field<ListGraphType<PhaseInputType>>("phases");
        }
    }
}
