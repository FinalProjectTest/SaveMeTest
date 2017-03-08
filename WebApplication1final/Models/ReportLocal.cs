using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1final.Models
{
    public class ReportLocal
    {

        public int ID { get; set; }

        public string AbuserDescription { get; set; }
        public string PropertyDescription { get; set; }
        public string OwnerName { get; set; }
        public string AnimalDescription { get; set; }

        public virtual ICollection<ReportAbuse> ReportAbuses { get; set; }
    }
}