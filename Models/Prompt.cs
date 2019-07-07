using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAn.Models
{
    public class Prompt
    {
        public int Id { get; set; }

        public int Level { get; set; }

        public string Description { get; set; }

        public int PromptLevelComplete { get; set; }

        public int ConsecutiveSuccessfulSession { get; set; }

        public DateTime LastUpdated { get; set; }

        [ForeignKey("TargetId")] // TODO: Annotation may not be necessary
        public virtual Target Target { get; set; }
    }

}