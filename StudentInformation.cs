using System;
using System.Collections.Generic;
using System.Text;

namespace Many_Project
{
    public class Student_Information
    {
        public Student_Information(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
