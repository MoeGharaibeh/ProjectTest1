using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status status { get; set; }

        //**********
        public TeamLeader TeamLeader { get; set; }
        public string TeamleaderId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }

        public List<SprintTask> SprintTasks { get; set;}

        

    }
    
}
