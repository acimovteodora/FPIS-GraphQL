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
    public class StudentQuery : ObjectGraphType
    {
        public StudentQuery(IStudentLogic studentLogic)
        {
            Field<ListGraphType<StudentType>>("allStudents", resolve: context => { return studentLogic.GetAll(); });
            Field<StudentType>(
                "studentById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "id"
                }),
                resolve: context => { return studentLogic.GetById(context.GetArgument<int>("id")); }
            );
            Field<ListGraphType<StudentType>>(
                "studentByCriteria",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>
                {
                    Name = "criteria"
                }),
                resolve: context => { return studentLogic.GetByCriteria(context.GetArgument<string>("criteria")); }
            );
            Field<ListGraphType<StudentType>>(
                "acceptedStudents",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectId"
                }),
                resolve: context => { return studentLogic.GetAcceptedByProject(context.GetArgument<long>("projectId")); }
            );
        }
    }
}
