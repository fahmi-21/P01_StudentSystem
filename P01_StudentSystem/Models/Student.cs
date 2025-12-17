using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace P01_StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Unicode(true)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(10)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
