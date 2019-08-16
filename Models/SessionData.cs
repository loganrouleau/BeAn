using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAn.Models
{
    public class SessionData
    {
        public int Id { get; set; }

        public int Data { get; set; }

        public int TrialNumber { get; set; }

        public DateTime LastUpdated { get; set; }

        public int PromptId { get; set; }

        [ForeignKey("PromptId")]
        public virtual Prompt Prompt { get; set; }

        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }
    }

}