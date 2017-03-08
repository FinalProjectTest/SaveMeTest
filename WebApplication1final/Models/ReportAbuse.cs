using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1final.Models
{
    public class ReportAbuse
    { 
     [Key]
    public int ReportID { get; set; }

    public string Topic { get; set; }
    public string FullName { get; set; }
    public string ReportEmail { get; set; }
    public string ReportPhone { get; set; }
    public bool Contact { get; set; }
    public bool Updates { get; set; }

    [ForeignKey("ReportLocal")]
    
    public int LocalID { get; set; }

    public virtual ReportLocal ReportLocal { get; set; }

    [ForeignKey("Neglect")]
    public int NeglectID { get; set; }

    public virtual Neglect Neglect { get; set; }

}
}