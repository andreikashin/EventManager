using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class Event
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public string Name { get; set; }

        [Display(Name = "Duration in hours")]
        public int DurationInHours { get; set; }

        [Display(Name = "Date and Time")]
        public DateTimeOffset DateTime { get; set; }

        [StringLength(1000)]
        public string Info { get; set; }
    }
}