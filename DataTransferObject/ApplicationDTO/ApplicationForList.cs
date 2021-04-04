using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.ApplicationDTO
{
    public class ApplicationForList
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public long ProjectID { get; set; }
    }
}
