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
            FieldAsync<StudentType>("student", resolve: async context => { return await studentLogic.GetById(context.Source.StudentID); });
            FieldAsync<PhaseType>("phase", resolve: async context => { return await phaseLogic.GetById(context.Source.PhaseID); });
        }
    }
}
