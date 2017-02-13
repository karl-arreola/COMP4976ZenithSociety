using System;
using System.ComponentModel.DataAnnotations;

namespace ZenithDataLib.Models
{
    public partial class Event
    {
        public int EventId { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public string EventMadeBy { get; set; }
        public bool IsActive { get; set; }
        
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
