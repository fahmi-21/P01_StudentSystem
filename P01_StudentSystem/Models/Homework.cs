using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    public enum ContentType
    {
        Application,
        Pdf,
        Zip
    }

    public class Homework
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; } = string.Empty;
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
