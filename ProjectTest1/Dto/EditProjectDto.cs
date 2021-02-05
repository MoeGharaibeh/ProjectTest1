using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class EditProjectDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="please Enter the Title")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string TeamLeaderId { get; set; }
        public List<string> DeveloperIds { get; set; }

        //public string ProjectManagerId { get; set; }
    }
}
