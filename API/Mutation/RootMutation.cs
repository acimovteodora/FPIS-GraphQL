using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            FieldAsync<ApplicationMutation>("applicationMutation", resolve: async context => await Task.FromResult(new { }));
            FieldAsync<ProjectPlanMutation>("projectPlanMutation", resolve: async context => await Task.FromResult(new { }));
            //Field<ApplicationMutation>("applicationMutation", resolve: context => new { }); 
            //Field<ProjectPlanMutation>("projectPlanMutation", resolve: context => new { }); 
        }
    }
}
