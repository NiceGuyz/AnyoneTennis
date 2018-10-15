using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class CoachEvent
    {
        // unique identifier of coach
        public int CoachId { get; set; }
        // name of coach
        public string Name { get; set; }
        // nickname of coach
        public string Nickname { get; set; }
        // birthday of coach
        public DateTime Dob { get; set; }
        // biography of coach
        public string Biography { get; set; }
        public bool Assigned { get; set; }

        // list of event that the coach handles
        public virtual ICollection<Event> Events { get; set; }
    }
}
