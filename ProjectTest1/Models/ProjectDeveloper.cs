using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Models
{
    public class ProjectDeveloper
    {

        public Developer Developer { get; set; }
        public string DeveloperId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
