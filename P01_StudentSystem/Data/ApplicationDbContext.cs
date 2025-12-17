using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;initial catalog = StudentSystem;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Students =============================================================================
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    Name = "John Doe",
                    PhoneNumber = "1234567890",
                    RegisteredOn = DateTime.Now,
                    Birthday = new DateTime(2000, 5, 10)
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Jane Smith",
                    PhoneNumber = "9876543210",
                    RegisteredOn = DateTime.Now
                });

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    Name = "C# Programming",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3),
                    Price = 199.99m
                },
                new Course
                {
                    CourseId = 2,
                    Name = "Database Design",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3),
                    Price = 149.99m
                });

            // Seed Resources =============================================================================
            modelBuilder.Entity<Resource>().HasData(
                new Resource
                {
                    ResourceId = 1,
                    Name = "C# Basics Video",
                    Url = "http://example.com/csharp_video",
                    ResourceType = ResourceType.Video,
                    CourseId = 1
                },
                new Resource
                {
                    ResourceId = 2,
                    Name = "Database Design Presentation",
                    Url = "http://example.com/database_design_presentation",
                    ResourceType = ResourceType.Presentation,
                    CourseId = 2
                });

            // Seed Homework =============================================================================
            modelBuilder.Entity<Homework>().HasData(
                new Homework
                {
                    HomeworkId = 1,
                    Content = @"C:\Files\homework1.zip",
                    ContentType = ContentType.Zip,
                    SubmissionTime = DateTime.Now,
                    StudentId = 1,
                    CourseId = 1
                },
                new Homework
                {
                    HomeworkId = 2,
                    Content = @"C:\Files\homework2.pdf",
                    ContentType = ContentType.Pdf,
                    SubmissionTime = DateTime.Now,
                    StudentId = 2,
                    CourseId = 2
                });

            // Seed StudentCourse mappings ============================================================
            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse
                {
                    StudentId = 1,
                    CourseId = 1
                },
                new StudentCourse
                {
                    StudentId = 2,
                    CourseId = 2
                });
        }
    }
}
