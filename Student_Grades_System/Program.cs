
using System;
using Student_Grades_System.Models;
using Student_Grades_System.Services;

namespace Student_Grades_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManagement management = new StudentManagement();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n========== STUDENT GRADES MANAGER ==========");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Find Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Add Subject Grade");
                Console.WriteLine("5. Display Student Report");
                Console.WriteLine("6. Remove Student");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                        
                    case "1":
                        Console.Clear();
                        AddStudent(management);
                        Console.WriteLine("Enter any key to back to Main Menue ! ");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        FindStudent(management);
                        Console.WriteLine("Enter any key to back to Main Menue ! ");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        management.DisplayStudents();
                        Console.WriteLine("Enter any key to back to Main Menue ! ");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        AddSubject(management);
                        Console.WriteLine("Enter any key to back to Main Menue ! ");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        DisplayReport(management);
                        Console.WriteLine("Enter any key to back to Main Menue ! ");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.Clear();
                        RemoveStudent(management);
                        Console.WriteLine("Enter any key to back to Main Menue ! ");
                        Console.ReadKey();
                        break;

                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddStudent(StudentManagement management)
        {
            Console.Write("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Academic Year:");
            Console.WriteLine("1. First  2. Second  3. Third  4. Fourth");
            Console.Write("Choose year: ");

            if (!int.TryParse(Console.ReadLine(), out int year) || !Enum.IsDefined(typeof(AcademicYear), year))
            {
                Console.WriteLine("Invalid academic year.");
                return;
            }

            Console.WriteLine("Departments:");
            foreach (Department department in Enum.GetValues(typeof(Department)))
            {
                Console.WriteLine($"{(int)department}. {department}");
            }

            Console.Write("Choose department number: ");

            if (!int.TryParse(Console.ReadLine(), out int departmentNumber) ||
                !Enum.IsDefined(typeof(Department), departmentNumber))
            {
                Console.WriteLine("Invalid department.");
                return;
            }

            StudentInformation student = new StudentInformation(id,name,(AcademicYear)year,(Department)departmentNumber);
            if (management.AddStudent(student))
                Console.WriteLine("Student added successfully.");
            else
                Console.WriteLine("Invalid data or Student ID already exists.");
        }

        static void FindStudent(StudentManagement management)
        {
            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            StudentInformation student = management.FindStudent(id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"ID: {student.StudentID}");
            Console.WriteLine($"Name: {student.StudentName}");
            Console.WriteLine($"Academic Year: {student.AcademicYear}");
            Console.WriteLine($"Department: {student.Department}");
        }

        static void AddSubject(StudentManagement management)
        {
            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int studentID))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            if (management.FindStudent(studentID) == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter Subject ID: ");

            if (!int.TryParse(Console.ReadLine(), out int subjectID))
            {
                Console.WriteLine("Invalid Subject ID.");
                return;
            }

            Console.Write("Enter Subject Name: ");
            string subjectName = Console.ReadLine();

            Console.Write("Enter Maximum Grade: ");

            if (!double.TryParse(Console.ReadLine(), out double maxGrade) || maxGrade <= 0)
            {
                Console.WriteLine("Invalid maximum grade.");
                return;
            }

            Console.Write("Enter Student Grade: ");

            if (!double.TryParse(Console.ReadLine(), out double grade) ||
                grade < 0 || grade > maxGrade)
            {
                Console.WriteLine("Grade must be between 0 and the maximum grade.");
                return;
            }

            SubjectGrade subject = new SubjectGrade(
                subjectID, subjectName, grade, maxGrade);

            if (management.AddSubject(studentID, subject))
                Console.WriteLine("Subject grade added successfully.");
            else
                Console.WriteLine("Could not add subject. Check the data or duplicate ID.");
        }

        static void DisplayReport(StudentManagement management)
        {
            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            management.DisplayStudentReport(id);
        }

        static void RemoveStudent(StudentManagement management)
        {
            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            if (management.RemoveStudent(id))
                Console.WriteLine("Student removed successfully.");
            else
                Console.WriteLine("Student not found.");
        }
    }
}
