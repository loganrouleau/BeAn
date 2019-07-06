using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAn.Models
{
    public class SessionData
    {
        public int Id { get; set; }

        public int Data { get; set; }

        public DateTime LastUpdated { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }

        [ForeignKey("ProgramId")]
        public virtual Program Program { get; set; }

        [ForeignKey("TargetId")]
        public virtual Target Target { get; set; }

    }

}