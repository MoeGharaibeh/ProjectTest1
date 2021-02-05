using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class CreateTaskDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string DeveloperId { get; set; }
        public int SprintId { get; set; }
        public Status Status { get; set; }

    }
}
