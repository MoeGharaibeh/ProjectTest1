using Microsoft.AspNetCore.Http;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Dto
{
    public class CreateWorkDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public WorkStatus workStatus { get; set; }
        public int SprintTaskId { get; set; }
        public string DeveloperId { get; set; }
        public IFormFile TheFile { get; set; }
        //public List<IFormFile> TheFile { get; set; }
    }
}
