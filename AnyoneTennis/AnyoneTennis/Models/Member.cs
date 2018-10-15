using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class Member
    {
        // unique id of member table
        public int MemberId { get; set; }
        // name of member
        public string Name { get; set; }
        // birthday of member
        public DateTime Dob { get; set; }
        // gender of member
        public string Gender { get; set; }
        // email of member
        public string emailId { get; set; }

        
    }
}
