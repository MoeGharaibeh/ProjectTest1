using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkStatus workStatus { get; set; }
        public string RecjectionNote { get; set; } //note

        public SprintTask SprintTask { get; set; }
        public int SprintTaskId { get; set; }
        public Developer Developer { get; set; }
        public string DeveloperId { get; set; }


        public List<File> Files { get; set; }
        //upload more than file
  


    }
}
