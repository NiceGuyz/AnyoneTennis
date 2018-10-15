using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class Coach
    {
        // unique id of coach id
        public int CoachId { get; set; }
        // name of coach
        public string Name { get; set; }
        // nickname of coach
        public string Nickname { get; set; }
        // birthday of coach
        public DateTime Dob { get; set; }
        // biography of coach
        public string Biography { get; set; }


    }
}
