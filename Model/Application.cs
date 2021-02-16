using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Application
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public long ProjectID { get; set; }
        public Project Project { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool ExperienceInPreviousProjects { get; set; }
        public bool Accepted { get; set; }
        public string Reason { get; set; }
    }
}
