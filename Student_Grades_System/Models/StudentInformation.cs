using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades_System.Models
{
    internal class StudentInformation
    {
        public int StudentID { get; private set; }

        public string StudentName { get; private set; }

        public AcademicYear AcademicYear { get; private set; }

        public Department Department { get; private set; }

        public StudentInformation(int studentID,string studentName,AcademicYear academicYear,Department department)
        {
            StudentID = studentID;
            StudentName = studentName;
            AcademicYear = academicYear;
            Department = department;
        }
    }
}
