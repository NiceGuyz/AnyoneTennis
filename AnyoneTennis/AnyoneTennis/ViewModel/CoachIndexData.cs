using AnyoneTennis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnyoneTennis.ViewModels
{
    public class CoachIndexData
    {
        public IEnumerable<Coach> Coaches { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Member> Members { get; set; }

    }
}
