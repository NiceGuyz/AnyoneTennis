﻿using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class CoachEvent
    {
        public int CoachId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Dob { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}