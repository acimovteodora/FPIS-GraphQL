using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Query
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<StudentQuery>("studentQuery", resolve: context => new { });
            Field<ApplicationQuery>("applicationQuery", resolve: context => new { });
            Field<CompanyQuery>("companyQuery", resolve: context => new { });
            Field<EmployeeQuery>("employeeQuery", resolve: context => new { });
            Field<PhaseQuery>("phaseQuery", resolve: context => new { });
            Field<ProjectProposalQuery>("proposalQuery", resolve: context => new { });
            Field<ProjectQuery>("projectQuery", resolve: context => new { });
            Field<ProjectPlanQuery>("planQuery", resolve: context => new { });
            Field<SkillQuery>("skillQuery", resolve: context => new { });
            Field<EngagementQuery>("engagementQuery", resolve: context => new { });
        }
    }
}
