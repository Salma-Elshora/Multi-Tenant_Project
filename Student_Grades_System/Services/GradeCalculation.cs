using Student_Grades_System.Models;
using System;
using System.Collections.Generic;


namespace Student_Grades_System.Services
{
    internal class GradeCalculation
    {
        private const double A_Minimum = 85;
        private const double B_Minimum = 75;
        private const double C_Minimum = 65;
        private const double PassingPercentage = 50;

        //for Calculating the Percentage of A Subject
       public static double? CalculatePercentage(SubjectGrade Subject)
       {
            if(Subject == null || Subject.MaxGrade<= 0)
            {
                return null;
            }
            if(Subject.Grade <0 || Subject.Grade > Subject.MaxGrade)
            {
                return null;
            }
            return (Subject.Grade / Subject.MaxGrade) * 100;
       }


        //for Calculating The Letter Grade
        public static LetterGrade CalculateLetterGrade(double Percentage)
        {
            if (Percentage >= A_Minimum)
            {
                return LetterGrade.A;
            }
            if(Percentage >= B_Minimum )
            {
                return LetterGrade.B;
            }
            if(Percentage >= C_Minimum )
            {
                return LetterGrade.C;
            }
            if(Percentage >= PassingPercentage)
            {
                return LetterGrade.D;
            }
            return LetterGrade.F;
        }


        //for checking if student Passed A Subject or Not
        public static bool? IsPassed(SubjectGrade Subject)
        {
            double? Percentage = CalculatePercentage(Subject);

            if(Percentage == null)
            {
                return null;
            }

            return Percentage.Value >= PassingPercentage ;
        }


        //for Calculating the overall Average Percentage
        public static double? CalculateOverallAverage(List<SubjectGrade>Subjects)
        {
            if (Subjects == null || Subjects.Count == 0)
            {
                return null;
            }
            double TotalPercentage = 0;

            foreach (SubjectGrade Subject in Subjects)
            {
                double? Percentage = CalculatePercentage(Subject);

                if (Percentage == null)
                {
                    return null;
                }
                TotalPercentage += Percentage.Value;
            }
            return TotalPercentage / Subjects.Count;
        }


        //for calculating the overall Letter Grade
        public static LetterGrade? CalculateOverallLetterGrade (List<SubjectGrade>Subjects)
        {
            double? Average = CalculateOverallAverage(Subjects);
            if (Average == null)
            {  
                return null;
            }
            return CalculateLetterGrade(Average.Value);
        }
    }
}
