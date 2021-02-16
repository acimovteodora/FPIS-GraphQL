using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProgressReport : Document
    {
        public string ActivityDescription { get; set; }
        public Phase Phase { get; set; }
    }
}
