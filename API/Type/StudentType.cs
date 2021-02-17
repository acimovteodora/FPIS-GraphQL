using GraphQL.Types;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Type
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(x => x.StudentID);
            Field(x => x.Name);
            Field(x => x.Surname);
            Field(x => x.Index);
            Field(x => x.YearOfStudy);
            Field(x => x.Department);
        }
    }
}
