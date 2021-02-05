using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class CreateProjectDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TeamLeaderId { get; set; }
        [Required]
        public string ProjectManagerId { get; set; }
        [Required]
        public List<string> DeveloperIds { get; set; }

        public Status status { get; set; }
    }

  


}
