using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Project
    {
        public long ProjectID { get; set; }
        public DateTime AdoptionDate { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public Employee InternalMentor { get; set; }
        public Employee DecisionMaker { get; set; }
        public ProjectProposal ProjectProposal { get; set; }
        public List<Document> Documents { get; set; }
        public List<Application> Applications { get; set; }
    }
}
