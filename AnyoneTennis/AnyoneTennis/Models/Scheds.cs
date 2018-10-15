using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class Scheds
    {
        // unique id of event
        public int EventId { get; set; }
        // name of event
        public string EventName { get; set; }
        // description of event
        public string EventDescription { get; set; }
        // event date
        public DateTime EventDate { get; set; }
        // coach of event
        public int CoachId { get; set; }
        // name of coach of the event
        public string Name { get; set; }
        // nickname of the coach of the event
        public string Nickname { get; set; }
        // biography of the coach of the event
        public string Biography { get; set; }
    }
}