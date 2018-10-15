using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class Event
    {
        // event id
        public int EventId { get; set; }
        // event name
        public string Name { get; set; }
        // event description
        public string Description { get; set; }
        // coach of the event
        public int Coach { get; set; }
        // date of the event
        public DateTime Date { get; set; }

    }
}
