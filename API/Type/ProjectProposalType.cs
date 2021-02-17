using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class ProjectProposalType : ObjectGraphType<ProjectProposal>
    {
        public ProjectProposalType(IEmployeeLogic employeeLogic,  ICompanyLogic companyLogic)
        {
            Field(x => x.ProjectProposalID);
            Field(x => x.Name);
            Field(x => x.Goal);
            Field(x => x.ProposalDate);
            Field(x => x.DaysDuration);
            Field(x => x.Description);
            Field(x => x.Activities);
            Field<CompanyType>("company", resolve: context => { return companyLogic.GetByProjectProposalId(context.Source.ProjectProposalID); });
            //Field<ListGraphType<PhaseType>>("phases", resolve: context => { return phaseLogic.GetByProjectPlan(context.Source.DocumentID); }); PROJECT COVERING SUBJECTS
        }
    }
}
