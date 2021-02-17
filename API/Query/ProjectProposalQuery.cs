﻿using API.Type;
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
    public class ProjectProposalQuery : ObjectGraphType
    {
        public ProjectProposalQuery(IProjectProposalLogic proposalLogic)
        {
            Field<ProjectProposalType>(
                "proposalById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "id"
                }),
                resolve: context => { return proposalLogic.GetById(context.GetArgument<long>("id")); }
            );
        }
    }
}
