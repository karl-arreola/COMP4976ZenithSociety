using System;

namespace ZenithDataLib.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string EventMadeBy { get; set; }
        public bool IsActive { get; set; }

        public Activity activity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
