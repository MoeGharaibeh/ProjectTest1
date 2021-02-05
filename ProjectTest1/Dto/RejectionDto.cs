using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class RejectionDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Recjection Note")]
        public string RecjectionNote { get; set; }
    }
}
