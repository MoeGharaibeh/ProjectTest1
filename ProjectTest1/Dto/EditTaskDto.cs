using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class EditTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DeveloperId { get; set; }
        public int SprintId { get; set; }
        public Status Status { get; set; }
    }
}
