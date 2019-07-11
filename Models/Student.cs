using System;
using System.Collections.Generic;

namespace BeAn.Models
{

    public class Student
    {
        public int Id { get; set; }

        public string StudentId { get; set; }

        public string StudentInitials { get; set; }

        public string Remark { get; set; }

        public DateTime LastUpdated { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }

}