using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class ApplicationType : ObjectGraphType<Application>
    {
        public ApplicationType(IStudentLogic studentLogic, IProjectLogic projectLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.StudentID);
            Field(x => x.Accepted);
            Field(x => x.StartDate, nullable: true);
            Field(x => x.EndDate, nullable: true);
            Field(x => x.ExperienceInPreviousProjects);
            Field(x => x.Reason);
            Field<StudentType>("student", resolve: context => { return studentLogic.GetById(context.Source.StudentID); });
            Field<ProjectPlanType>("projectPlan", resolve: context => { return projectLogic.GetById(context.Source.ProjectID); });
        }
    }
}
