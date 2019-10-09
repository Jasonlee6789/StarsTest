using System;
using System.Collections.Generic;

namespace BasketballCompetition.Models
{
    public partial class Enrolment
    {
        public int EnrolId { get; set; }
        public int? TeamId { get; set; }
        public string GradeId { get; set; }

        public Grade Grade { get; set; }
        public Teams Team { get; set; }
    }
}
