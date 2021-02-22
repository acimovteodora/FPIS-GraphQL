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
            FieldAsync<StudentQuery>("studentQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<ApplicationQuery>("applicationQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<CompanyQuery>("companyQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<EmployeeQuery>("employeeQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<PhaseQuery>("phaseQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<ProjectProposalQuery>("proposalQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<ProjectQuery>("projectQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<ProjectPlanQuery>("planQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<SkillQuery>("skillQuery", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<EngagementQuery>("engagementQuery", resolve: async context => await Task.FromResult(new { }));
            //Field<StudentQuery>("studentQuery", resolve: context => new { });
            //Field<ApplicationQuery>("applicationQuery", resolve: context => new { });
            //Field<CompanyQuery>("companyQuery", resolve: context => new { });
            //Field<EmployeeQuery>("employeeQuery", resolve: context => new { });
            //Field<PhaseQuery>("phaseQuery", resolve: context => new { });
            //Field<ProjectProposalQuery>("proposalQuery", resolve: context => new { });
            //Field<ProjectQuery>("projectQuery", resolve: context => new { });
            //Field<ProjectPlanQuery>("planQuery", resolve: context => new { });
            //Field<SkillQuery>("skillQuery", resolve: context => new { });
            //Field<EngagementQuery>("engagementQuery", resolve: context => new { });
        }
    }
}
