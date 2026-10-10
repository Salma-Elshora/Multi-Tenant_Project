using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades_System.Models
{
    internal class SubjectGrade
    {
        public int SubjectID { get; private set; }

        public string SubjectName { get; private set; }

        public double Grade { get; private set; }

        public double MaxGrade { get; private set; }

        public int CreditHours { get; private set; }

        public SubjectGrade(int subjectID,string subjectName,double grade,double maxGrade,int creditHours)
        {
            SubjectID = subjectID;
            SubjectName = subjectName;
            Grade = grade;
            MaxGrade = maxGrade;
            CreditHours = creditHours;
        }
    }
}
