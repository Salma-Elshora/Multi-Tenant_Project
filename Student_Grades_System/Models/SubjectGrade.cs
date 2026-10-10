using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades_System.Models
{
    internal class SubjectGrade
    {
        public int SubjectID { get; set; }

        public string SubjectName { get; set; } = string.Empty;

        public double Grade { get; set; }

        public double MaxGrade { get; set; }

        public int CreditHours { get; set; }
    }
}
