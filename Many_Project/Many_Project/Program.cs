namespace Many_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student_Management st = new Student_Management();
            st.AddStudent(new Student_Information(10,"ziad"));
            st.AddStudent(new Student_Information(11,"Mohammed"));
            st.AddStudent(new Student_Information(12,"Ahmed"));
            st.AddStudent(new Student_Information(10,"Marwan"));
            st.AddStudent(new Student_Information(14,"Amal"));
            st.AddStudent(new Student_Information(15,"Judy"));
            st.AddStudent(new Student_Information(16,"Salma"));
            st.DisplayStudent();
            Console.WriteLine("_____________________________");
            st.UpdateStudent(new Student_Information(11,"ziad"));
            st.DisplayStudent();
            Console.WriteLine("_____________________________");
            st.DeleteStudentById(1);
            st.DeleteStudentById(12);
            st.DisplayStudent();
            Console.WriteLine("_____________________________");
            st.FindStudentById(12);
            st.FindStudentById(10);



        }
    }
}
