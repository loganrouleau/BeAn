using BeAn.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAn.Models
{

    public class Target
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        // TODO: Delete this column? This information is stored with the prompt
        public string PromptLevel { get; set; }

        public int MinTrial { get; set; }

        public int MaxTrial { get; set; }

        public DateTime LastUpdated { get; set; }

        public int ProgramId { get; set; }

        [ForeignKey("ProgramId")]
        public virtual Program Program { get; set; }

        public virtual ICollection<Prompt> Prompts { get; set; }
    }

}