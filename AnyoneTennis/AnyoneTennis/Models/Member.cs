using System;
using System.Collections.Generic;

namespace AnyoneTennis.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string email { get; set; }
    }
}
