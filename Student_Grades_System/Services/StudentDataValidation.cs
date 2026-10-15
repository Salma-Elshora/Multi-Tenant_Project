using System;

namespace Student_Grades_System.Services
{
     internal class StudentDataValidation
     {
          // Validate Student ID
          public bool ValidateStudentId(int studentId)
          {
               return studentId > 0;
          }

          // Validate Student Name
          public bool ValidateStudentName(string studentName)
          {
               return !string.IsNullOrWhiteSpace(studentName);
          }

          // Validate Subject Name
          public bool ValidateSubjectName(string subjectName)
          {
               return !string.IsNullOrWhiteSpace(subjectName);
          }

          // Validate Subject Grade
          public bool ValidateGrade(double grade)
          {
               return grade >= 0 && grade <= 100;
          }

          // Validate Final Grade
          public bool ValidateFinalGrade(double finalGrade)
          {
               return finalGrade >= 0 && finalGrade <= 100;
          }

          // Validate all Student Data
          public bool ValidateStudentData(int studentId, string studentName)
          {
               return ValidateStudentId(studentId)
                      && ValidateStudentName(studentName);
          }

          // Validate Subject Data
          public bool ValidateSubjectData(string subjectName, double grade)
          {
               return ValidateSubjectName(subjectName)
                      && ValidateGrade(grade);
          }
     }
}
