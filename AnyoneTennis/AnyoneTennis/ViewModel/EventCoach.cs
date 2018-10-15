using AnyoneTennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyoneTennis.ViewModel
{
    public class EventCoach
    {

        public int CoachId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Dob { get; set; }
        public string Biography { get; set; }
        public bool Assigned { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}