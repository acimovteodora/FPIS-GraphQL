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
        public ProjectType( IApplicationLogic applicationLogic, IProjectProposalLogic projectProposalLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.AdoptionDate);
            Field(x => x.Note);
            Field(x => x.Description);
            //Field<EmployeeType>("internalMentor", resolve: context => { return employeeLogic.GetByID(context.Source.InternalMentor.EmployeeID); });
            //Field<EmployeeType>("decisionMaker", resolve: context => { return employeeLogic.GetByID(context.Source.DecisionMaker.EmployeeID); });
            FieldAsync<ProjectProposalType>("projectProposal", resolve: async context => { return await projectProposalLogic.GetByProjectId(context.Source.ProjectID); });
            FieldAsync<ListGraphType<ApplicationType>>("applications", resolve: async context => { return await applicationLogic.GetAllForProject(context.Source.ProjectID); });
        }
    }
}
