using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Document
    {
        public long ProjectID { get; set; }
        public int DocumentID { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public string Note { get; set; }
        public Employee ComposedBy { get; set; }
    }
}
