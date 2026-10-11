using System;

namespace Student_Grades_System
{
     internal class Program
     {
          static void Main(string[] args)
          {
               // Student Data Validation

               // Validate Student ID
               Console.Write("Enter Student ID: ");
               string studentId = Console.ReadLine();

               if (string.IsNullOrWhiteSpace(studentId) || !int.TryParse(studentId, out int id) || id <= 0)
               {
                    Console.WriteLine("Invalid Student ID. ID must be a positive number.");
               }

               // Validate Subject Name
               Console.Write("Enter Subject Name: ");
               string subjectName = Console.ReadLine();

               if (string.IsNullOrWhiteSpace(subjectName))
               {
                    Console.WriteLine("Invalid Subject Name. Name cannot be empty.");
               }

               // Validate Student Name input
               Console.Write("Enter Student Name: ");
               string studentName = Console.ReadLine();

               if (string.IsNullOrWhiteSpace(studentName))
               {
                    Console.WriteLine("Invalid Student Name. Name cannot be empty.");
               }

               // Validate Grade each Subject
               Console.Write("Enter Grade: ");
               string gradeInput = Console.ReadLine();

               if (!double.TryParse(gradeInput, out double grade) || grade < 0 || grade > 100)
               {
                    Console.WriteLine("Invalid Grade. Grade must be between 0 and 100.");
               }

               // Validate Final Grade
               Console.Write("Enter Final Grade: ");
               string finalGradeInput = Console.ReadLine();

               if (!double.TryParse(finalGradeInput, out double finalGrade) || finalGrade < 0 || finalGrade > 100)
               {
                    Console.WriteLine("Invalid Final Grade. Final Grade must be between 0 and 100.");
               }
          }
     }
}
