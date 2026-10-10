using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades_System.Models
{
    internal class StudentInformation
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public int AcademicYear { get; set; }

        public string Department { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
