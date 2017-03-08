using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1final.Models
{
    public class Neglect
    {
        public int ID { get; set; }

        public bool Food { get; set; }
        public bool Shelter { get; set; }
        public bool Abandoned { get; set; }
        public bool Poison { get; set; }
        public bool Underweight { get; set; }
        public bool Trapping { get; set; }
        public bool Water { get; set; }
        public bool Shot { get; set; }
        public bool Injury { get; set; }
        public bool Abuse { get; set; }
        public string Other { get; set; }

        public virtual ICollection<ReportAbuse> ReportAbuses { get; set; }
    }
}