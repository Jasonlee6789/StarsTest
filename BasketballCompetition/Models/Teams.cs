using System;
using System.Collections.Generic;

namespace BasketballCompetition.Models
{
    public partial class Teams
    {
        public Teams()
        {
            Enrolment = new HashSet<Enrolment>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public ICollection<Enrolment> Enrolment { get; set; }
    }
}
