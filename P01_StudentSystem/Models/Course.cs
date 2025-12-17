using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    public class Course
    {
        //[Key]
        public int CourseId { get; set; }

        
        //[MaxLength(80)]
        public string Name { get; set; }= string.Empty;

        //[Unicode (true)]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
