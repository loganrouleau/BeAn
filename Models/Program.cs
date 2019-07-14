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

        //0="incomplete"; 1="complete"
        public int ProgramComplete { get; set; }

        //1="more than"; 2="less than" 
        public int MasteryCriteriaCompareType { get; set; }

        public double MasteryCriteriaCompareTo { get; set; }

        public int MasteryCriteriaConsecutiveSessions { get; set; }

        public DateTime LastUpdated { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")] // TODO: Annotation may not be necessary
        public virtual Student Student { get; set; }

        public virtual ICollection<Target> Targets { get; set; }
    }

}