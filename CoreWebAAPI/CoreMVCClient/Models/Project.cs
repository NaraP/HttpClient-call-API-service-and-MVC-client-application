using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCClient.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsActive { get; set; }
    }
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsActive { get; set; }
    }
}
