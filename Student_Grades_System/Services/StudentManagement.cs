
using System.Collections.Generic;
using System.Linq;
using Student_Grades_System.Models;
using Student_Grades_System.Reports;

namespace Student_Grades_System.Services
{
    internal class StudentManagement
    {
        private class StudentRecord
        {
            public StudentInformation Student { get; }
            public List<SubjectGrade> Subjects { get; }

            public StudentRecord(StudentInformation student)
            {
                Student = student;
                Subjects = new List<SubjectGrade>();
            }
        }

        private readonly List<StudentRecord> records = new List<StudentRecord>();
        private readonly StudentDataValidation validation = new StudentDataValidation();

        public bool AddStudent(StudentInformation student)
        {
            if (student == null)
                return false;

            if (!validation.ValidateStudentData(student.StudentID, student.StudentName))
                return false;

            if (FindStudent(student.StudentID) != null)
                return false;

            records.Add(new StudentRecord(student));
            return true;
        }

        public StudentInformation FindStudent(int studentID)
        {
            StudentRecord record = records.FirstOrDefault(
                r => r.Student.StudentID == studentID);

            return record?.Student;
        }

        public List<StudentInformation> GetAllStudents()
        {
            return records.Select(r => r.Student).ToList();
        }

        public bool AddSubject(int studentID, SubjectGrade subject)
        {
            StudentRecord record = records.FirstOrDefault(
                r => r.Student.StudentID == studentID);

            if (record == null || subject == null)
                return false;

            if (!validation.ValidateSubjectName(subject.SubjectName))
                return false;

            if (subject.SubjectID <= 0 ||
                subject.MaxGrade <= 0 ||
                subject.Grade < 0 ||
                subject.Grade > subject.MaxGrade)
                return false;

            if (record.Subjects.Any(s => s.SubjectID == subject.SubjectID))
                return false;

            record.Subjects.Add(subject);
            return true;
        }

        public List<SubjectGrade> GetSubjects(int studentID)
        {
            StudentRecord record = records.FirstOrDefault(
                r => r.Student.StudentID == studentID);

            return record == null
                ? new List<SubjectGrade>()
                : record.Subjects;
        }

        public bool RemoveStudent(int studentID)
        {
            StudentRecord record = records.FirstOrDefault(
                r => r.Student.StudentID == studentID);

            if (record == null)
                return false;

            records.Remove(record);
            return true;
        }

        public void DisplayStudents()
        {
            if (records.Count == 0)
            {
                System.Console.WriteLine("No students registered.");
                return;
            }

            foreach (StudentRecord record in records)
            {
                System.Console.WriteLine(
                    $"ID: {record.Student.StudentID} | " +
                    $"Name: {record.Student.StudentName} | " +
                    $"Year: {record.Student.AcademicYear} | " +
                    $"Department: {record.Student.Department}");
            }
        }

        public void DisplayStudentReport(int studentID)
        {
            StudentInformation student = FindStudent(studentID);

            if (student == null)
            {
                System.Console.WriteLine("Student not found.");
                return;
            }

            StudentGradeReport.PrintReport(student, GetSubjects(studentID));
        }
    }
}
