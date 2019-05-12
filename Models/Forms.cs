using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeAn.Models
{
// Data model
//Student ID; last updated date; Student program ID; 
//Student program Description; datapoint 1-10 (string);

    public class Forms
    {
        public int Id { get; set; }

        public string StudentId { get; set; }

        public DateTime LastUpdated { get; set; }

        public string ProgramId { get; set; }

        public string ProgramDescription { get; set; }

        public string DataPointsJson { get; set;
            //get { return JsonConvert.DeserializeObject<string>(this.DataPointsJson);}   
            //set { this.DataPointsJson = JsonConvert.SerializeObject(value); }
            //set { this.DataPointsJson = value; }
        }

    }

}