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
            FieldAsync<ListGraphType<StudentType>>("allStudents", resolve: async context => { return await studentLogic.GetAll(); });
            FieldAsync<StudentType>(
                "studentById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "id"
                }),
                resolve: async context => { return await studentLogic.GetById(context.GetArgument<int>("id")); }
            );
            FieldAsync<ListGraphType<StudentType>>(
                "studentByCriteria",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>
                {
                    Name = "criteria"
                }),
                resolve: async context => { return await studentLogic.GetByCriteria(context.GetArgument<string>("criteria")); }
            );
            FieldAsync<ListGraphType<StudentType>>(
                "acceptedStudents",
                arguments: new QueryArguments(new QueryArgument<LongGraphType>
                {
                    Name = "projectID"
                }),
                resolve: async context => { return await studentLogic.GetAcceptedByProject(context.GetArgument<long>("projectID")); }
            );
        }
    }
}
