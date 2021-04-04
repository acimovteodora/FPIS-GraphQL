using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.ProjectPlanDTO
{
    public class ProjectPlanInsert : Document
    {
        public int EmployeeId { get; set; }
        public int Duration { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public List<Phase> Phases { get; set; }
    }
}
