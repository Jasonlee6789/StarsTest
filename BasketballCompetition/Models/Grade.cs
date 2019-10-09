using System;
using System.Collections.Generic;

namespace BasketballCompetition.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Enrolment = new HashSet<Enrolment>();
        }

        public string GradeId { get; set; }
        public string GradeName { get; set; }
        public string AgeGrade { get; set; }

        public ICollection<Enrolment> Enrolment { get; set; }
    }
}
