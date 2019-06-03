using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAn.Models
{
    public class Program
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime LastUpdated { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }

}