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
        public ProjectPlanType(IPhaseLogic phaseLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.DocumentID);
            Field(x => x.Title);
            Field(x => x.Note);
            Field(x => x.EstimatedStartDate);
            Field(x => x.Duration);
            Field(x => x.DateOfCompilation);
            //Field<EmployeeType>("employee", resolve: context => { return employeeLogic.GetByID(context.Source.ComposedBy.EmployeeID); }); //IZMENI, nema objekat composed by
            FieldAsync<ListGraphType<PhaseType>>("phases", resolve: async context => { return await phaseLogic.GetByProjectPlan(context.Source.DocumentID); });
        }
    }
}
