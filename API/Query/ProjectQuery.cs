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
            Field<ProjectType>(
                "projectById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "id"
                }),
                resolve: context => { return projectLogic.GetById(context.GetArgument<long>("id")); }
            );
            Field<ListGraphType<ProjectType>>("projects", resolve: context => { return projectLogic.GetAll(); } );
        }
    }
}
