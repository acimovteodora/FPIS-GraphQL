using API.Type;
using GraphQL;
using GraphQL.Types;
using Logic.ILogic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Query
{
    public class ProjectQuery : ObjectGraphType
    {
        public ProjectQuery(IProjectLogic projectLogic)
        {
            FieldAsync<ProjectType>(
                "projectById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectID"
                }),
                resolve: async context => { return await projectLogic.GetById(context.GetArgument<long>("projectID")); }
            );
            FieldAsync<ListGraphType<ProjectType>>("projects", resolve: async context => { return await projectLogic.GetAll(); } );
            //FieldAsync<ListGraphType<ProjectType>>("projects", resolve: async context =>
            //{
            //    using (var dc = dataContext())
            //        return await dc
            //            .Projects
            //            .Include(x => x.ProjectProposal)
            //            .ToListAsync();
            //});
        }
    }
}
