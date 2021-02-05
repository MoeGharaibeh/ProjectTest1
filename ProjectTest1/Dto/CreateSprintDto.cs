using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class CreateSprintDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
 
        public DateTime StartDate { get; set; }
        [Required]

        [DataType(DataType.Date)]
       
        public DateTime EndDate { get; set; }

        public int ProjectId { get; set; }
        public string TeamleaderId { get; set; }

        public Status Status { get; set; }
    }
}
