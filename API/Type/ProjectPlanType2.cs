using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class ProjectPlanType2 : ObjectGraphType<ProjectPlan>
    {
        public ProjectPlanType2(IPhaseLogic phaseLogic, IStudentLogic studentLogic, IProjectLogic projectLogic, IProjectPlanLogic projectPlanLogic)
        {
            Field(x => x.ProjectID);
            //Field(x => x.DocumentID);
            //Field(x => x.Title);
            //Field(x => x.Note);
            //Field(x => x.EstimatedStartDate);
            //Field(x => x.Duration);
            //Field(x => x.DateOfCompilation);
            FieldAsync<ProjectPlanType>("projectPlan", resolve: async context => { return await projectPlanLogic.GetByProject(context.Source.ProjectID); });
            FieldAsync<ProjectType>("project", resolve: async context => { return await projectLogic.GetById(context.Source.ProjectID); });
            //Field<EmployeeType>("employee", resolve: context => { return employeeLogic.GetByID(context.Source.ComposedBy.EmployeeID); }); //IZMENI, nema objekat composed by
            FieldAsync<ListGraphType<PhaseType>>("phases", resolve: async context => { return await phaseLogic.GetByProjectPlan(context.Source.DocumentID); });
            FieldAsync<ListGraphType<StudentType>>("students", resolve: async context => { return await studentLogic.GetAcceptedByProject(context.Source.ProjectID); });
        }
    }
}
