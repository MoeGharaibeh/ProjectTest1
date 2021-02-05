using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Models
{
    public class File
    {
        public int Id { get; set; }
        public Byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public Work Work { get; set; }
        public int WorkId { get; set; }
    }
}
