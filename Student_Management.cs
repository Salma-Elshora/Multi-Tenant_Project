using System;
using System.Collections.Generic;
using System.Text;

namespace Many_Project
{
    public class Student_Management
    {
       List<Student_Information> students = new List<Student_Information>();
        public void AddStudent(Student_Information student)
        {
            foreach (var s in students)
            {
                if (s.Id == student.Id)
                {
                    Console.WriteLine("ID already Added!");
                    return;
                }
            }
            students.Add(student);
            Console.WriteLine("Student added.");
        }
        public void UpdateStudent(Student_Information updatedStudent)
        {
            foreach (var s in students)
            {
                if (s.Id == updatedStudent.Id)
                {
                    s.Name = updatedStudent.Name;
                    Console.WriteLine("Student updated.");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }
        public void DisplayStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students in list!");
                return;
            }
            foreach (var s in students)
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name}");
        }

        public Student_Information FindStudentById(int id)
        {
            foreach (var s in students)
            {
                if (s.Id == id)
                {
                    Console.WriteLine($"Student found: {s.Id} - {s.Name}");
                    return s;
                }
            }
            Console.WriteLine("Student not found.");
            return null;
        }

        public void DeleteStudentById(int id)
        {
            foreach (var s in students)
            {
                if (s.Id == id)
                {
                    students.Remove(s);
                    Console.WriteLine("Student deleted.");
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }


    }
}
