using BeAn.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeAn.Models
{

    public class Student
    {
        public int Id { get; set; }

        public string StudentId { get; set; }

        public string StudentInitial { get; set; }

        public string Remark { get; set; }

        public string ProgramId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }

}