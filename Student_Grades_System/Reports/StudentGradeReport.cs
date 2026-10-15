using System;
using System.Collections.Generic;
using Student_Grades_System.Models;
using Student_Grades_System.Services;

namespace Student_Grades_System.Reports
{
    internal class StudentGradeReport
    {
        public static void PrintReport(StudentInformation student, List<SubjectGrade> subjects)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("             STUDENT REPORT               ");
            Console.WriteLine("==========================================");

            if (student != null)
            {
                Console.WriteLine($"Student Name : {student.StudentName}");
                Console.WriteLine($"Student ID   : {student.StudentID}");
                Console.WriteLine($"Department   : {student.Department}");
                Console.WriteLine($"Academic Year: {student.AcademicYear}");
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Subjects & Grades:");

            if (subjects == null || subjects.Count == 0)
            {
                Console.WriteLine("No subjects registered for this student.");
            }
            else
            {
                foreach (var sub in subjects)
                {
                    double? percentage = GradeCalculation.CalculatePercentage(sub);
                    LetterGrade letter = GradeCalculation.CalculateLetterGrade(percentage ?? 0);
                    bool? passed = GradeCalculation.IsPassed(sub);

                    string statusText = (passed == true) ? "Passed" : "Failed";

                    Console.WriteLine($"- {sub.SubjectName}: Grade = {sub.Grade}/{sub.MaxGrade} " +
                                      $"({percentage:F1}%) | Letter: {letter} | Status: {statusText}");
                }
            }

            Console.WriteLine("------------------------------------------");

           
            double? overallAvg = GradeCalculation.CalculateOverallAverage(subjects);
            LetterGrade? overallLetter = GradeCalculation.CalculateOverallLetterGrade(subjects);

            Console.WriteLine($"Overall Average : {(overallAvg.HasValue ? overallAvg.Value.ToString("F1") + "%" : "N/A")}");
            Console.WriteLine($"Overall Letter  : {(overallLetter.HasValue ? overallLetter.ToString() : "N/A")}");
            Console.WriteLine("==========================================");
        }
    }
}