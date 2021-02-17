using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class EngagementType : ObjectGraphType<Engagement>
    {
        public EngagementType(IStudentLogic studentLogic, IPhaseLogic phaseLogic)
        {
            Field(x => x.ProjectID);
            Field(x => x.StudentID);
            Field(x => x.DocumentID);
            Field(x => x.Description);
            Field(x => x.Name);
            Field(x => x.PhaseID);
            Field<StudentType>("student", resolve: context => { return studentLogic.GetById(context.Source.StudentID); });
            Field<PhaseType>("phase", resolve: context => { return phaseLogic.GetById(context.Source.PhaseID); });
        }
    }
}
