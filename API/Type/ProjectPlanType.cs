using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class ProjectPlanType : ObjectGraphType<ProjectPlan>
    {
        public ProjectPlanType(IEmployeeLogic employeeLogic,  IPhaseLogic phaseLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.DocumentID);
            Field(x => x.Title);
            Field(x => x.Note);
            Field(x => x.EstimatedStartDate);
            Field(x => x.Duration);
            Field(x => x.DateOfCompilation);
            //Field<EmployeeType>("employee", resolve: context => { return employeeLogic.GetByID(context.Source.ComposedBy.EmployeeID); }); //IZMENI, nema objekat composed by
            Field<ListGraphType<PhaseType>>("phases", resolve: context => { return phaseLogic.GetByProjectPlan(context.Source.DocumentID); });
        }
    }
}
