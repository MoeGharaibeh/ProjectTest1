using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class AddWorkAPIDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public WorkStatus workStatus { get; set; }
        public int SprintTaskId { get; set; }
        public string DeveloperId { get; set; }
    }
}
