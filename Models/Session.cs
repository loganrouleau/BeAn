using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAn.Models
{
    public class Session
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        [ForeignKey("StudentId")] // TODO: Annotation may not be necessary
        public virtual Student Student { get; set; }

        public virtual ICollection<SessionData> SessionDatas { get; set; }
    }

}