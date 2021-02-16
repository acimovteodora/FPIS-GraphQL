using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Engagement
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public long ProjectID { get; set; }
        public int DocumentID { get; set; }
        public int PhaseID { get; set; }
        public Phase Phase { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Engagement s = (Engagement)obj;
            if (this.StudentID == s.StudentID && this.PhaseID == s.PhaseID)
                return true;
            return false;
        }
    }
}
