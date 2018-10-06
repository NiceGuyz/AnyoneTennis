using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class Scheds
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public int CoachId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Biography { get; set; }
    }
}