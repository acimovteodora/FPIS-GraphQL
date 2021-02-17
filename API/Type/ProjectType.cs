using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class ProjectType : ObjectGraphType<Project>
    {
        public ProjectType(IEmployeeLogic employeeLogic,  IApplicationLogic applicationLogic, IProjectProposalLogic projectProposalLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.AdoptionDate);
            Field(x => x.Note);
            Field(x => x.Description);
            //Field<EmployeeType>("internalMentor", resolve: context => { return employeeLogic.GetByID(context.Source.InternalMentor.EmployeeID); });
            //Field<EmployeeType>("decisionMaker", resolve: context => { return employeeLogic.GetByID(context.Source.DecisionMaker.EmployeeID); });
            Field<ProjectProposalType>("projectProposal", resolve: context => { return projectProposalLogic.GetByProjectId(context.Source.ProjectID); });
            Field<ListGraphType<ApplicationType>>("applications", resolve: context => { return applicationLogic.GetAllForProject(context.Source.ProjectID); });
        }
    }
}
