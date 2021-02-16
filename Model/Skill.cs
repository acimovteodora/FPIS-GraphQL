using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Skill
    {
        public long ProjectID { get; set; }
        public int DocumentID { get; set; }
        public int PhaseID { get; set; }
        public Phase Phase { get; set; }
        public int SkillID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Skill s = (Skill)obj;
            if (this.Name == s.Name && this.Description == s.Description)
                return true;
            return false;
        }
    }
}
