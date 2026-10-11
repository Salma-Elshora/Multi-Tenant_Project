using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
        // StudentDataValidation Class
        //
        // Responsibility:
        // This class will validate student information and grades
        // before the data is accepted by the application.
        //
        // Expected operations:
        // 1. Check that required student information is valid.
        // 2. Check that subject grades are within the allowed range.
        // 3. Validate any additional input according to project rules.
        //
        // Important:
        // This class validates data only.
        // Grade calculation will be handled by GradeCalculation.
    
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

