using Student_Grades_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Grades_System.Services
{
    internal class GradeCalculation
    {

        //for Calculating the Percentage of A Subject
       public double CalculatePercentage(SubjectGrade Subject)
       {
            if(Subject == null || Subject.MaxGrade<= 0)
            {
                return -1;
            }
            if(Subject.Grade <0 || Subject.Grade > Subject.MaxGrade)
            {
                return -1;
            }
            return (Subject.Grade / Subject.MaxGrade) * 100;
       }


        //for Calculating The Letter Grade
        public LetterGrade CalculateLetterGrade(double Percentage)
        {
            if (Percentage >= 85)
            {
                return LetterGrade.A;
            }
            if(Percentage >=75 )
            {
                return LetterGrade.B;
            }
            if(Percentage >=65 )
            {
                return LetterGrade.C;
            }
            if(Percentage >= 50)
            {
                return LetterGrade.D;
            }
            return LetterGrade.F;
        }


        //for charcking if student Passed A Subject or Not
        public bool IsPassed(SubjectGrade Subject)
        {
            double Percentage = CalculatePercentage(Subject);

            return Percentage >= 50;
        }


        //for Calculating the overall Average Percentage
        public double CalculateOverallAverage(List<SubjectGrade>Subjects)
        {
            if (Subjects == null || Subjects.Count == 0)
            {
                return -1;
            }
            double TotalPercentage = 0;

            foreach (SubjectGrade Subject in Subjects)
            {
                double Percentage = CalculatePercentage(Subject);

                if (Percentage < 0)
                {
                    return -1;
                }
                TotalPercentage += Percentage;
            }
            return TotalPercentage / Subjects.Count;
        }


        //for calculating the overall Letter Grade
        public LetterGrade? CalculateOverallLetterGrade (List<SubjectGrade>Subjects)
        {
            double Average = CalculateOverallAverage(Subjects);
            if (Average < 0)
            {  
                return null;
            }
            return CalculateLetterGrade(Average);
        }
    }
}
