using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class StudentInputType : InputObjectGraphType
    {
        public StudentInputType()
        {
            Field<IntGraphType>("studentID");
            Field<StringGraphType>("name");
            Field<StringGraphType>("surname");
            Field<StringGraphType>("index");
        }
    }
}
