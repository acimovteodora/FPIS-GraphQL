using DataTransferObjects.ProjectProposalDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.ProjectDTO
{
    public class ProjectForList
    {
        public long ProjectID { get; set; }
        public ProjectProposallForListDTO ProjectProposal { get; set; }
    }
}
