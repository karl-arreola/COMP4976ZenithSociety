using System;
using System.Collections.Generic;

namespace ZenithDataLib.Models
{
    public partial class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Event> Events { get; set; }
    }
}
