using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Phase
    {
        public long ProjectID { get; set; }
        public int DocumentID { get; set; }
        public ProjectPlan ProjectPlan { get; set; }
        public int PhaseID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public List<Engagement> Engagements { get; set; }
        public List<Skill> RequiredSkills { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Phase s = (Phase)obj;
            if (this.Name == s.Name && this.Description == s.Description && s.Duration == this.Duration
                && this.StartDate == s.StartDate)
                return true;
            return false;
        }
    }
}
