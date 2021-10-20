using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cSharp_URL_Shortener.Models
{
    [Table("Statistics")]
    public class Statistics
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Redirect")]
        public Guid RedirectId { get; set; }

        public DateTime VisitTime { get; set; }

        //public ICollection<Redirect.Redirect> Redirects { get; set; }

        public Statistics(Guid redirectId, DateTime visitTime)
        {
            RedirectId = redirectId;
            VisitTime = visitTime;
        }
    }
}