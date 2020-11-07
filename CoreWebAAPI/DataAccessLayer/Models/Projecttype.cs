using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Projecttype
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsActive { get; set; }
        public Guid CreateUser { get; set; }
        public DateTime CreateTs { get; set; }
        public Guid UpdateUser { get; set; }
        public DateTime UpdateTs { get; set; }
    }
}
