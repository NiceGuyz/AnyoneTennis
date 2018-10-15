using AnyoneTennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyoneTennis.ViewModel
{
    public class EventCoach
    {
        // unique id of coach
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

        // events handle by coach
        public virtual ICollection<Event> Events { get; set; }
    }
}