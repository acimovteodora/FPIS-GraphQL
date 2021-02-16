using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProjectPlan : Document
    {
        public int Duration { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public List<Phase> Phases { get; set; }
    }
}
