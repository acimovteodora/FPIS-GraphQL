using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.ProjectPlanDTO
{
    public class ProjectPlanForUpdate
    {
        public int EmployeeID { get; set; }
        public int DocumentID { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public string Note { get; set; }
        public int Duration { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public List<Phase> Phases { get; set; }
    }
}
