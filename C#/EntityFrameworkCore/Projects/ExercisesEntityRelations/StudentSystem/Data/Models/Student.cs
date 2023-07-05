using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        
        public DateTime RegisteredOn { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
