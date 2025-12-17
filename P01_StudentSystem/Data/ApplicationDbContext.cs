using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace P01_StudentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;initial catalog = StudentSystem;Integrated Security=True;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");
        }

        public static void SeedData(ApplicationDbContext db)
        {
            try
            {
                if (db == null)
                {
                    Console.WriteLine("Database context is null!");
                    return;
                }

                bool hasStudents = db.Students.Any();
                bool hasCourses = db.Courses.Any();

                Console.WriteLine($"Has Students: {hasStudents}, Has Courses: {hasCourses}");

                if (!hasStudents && !hasCourses)
                {
                    Console.WriteLine("Starting to seed data...");

                    // add students =========================================================================
                    var students = new List<Student>
                    {
                        new Student
                        {
                            Name = "John Doe",
                            PhoneNumber = "1234567890",
                            RegisteredOn = DateTime.Now,
                            Birthday = new DateTime(2000, 5, 10)
                        },
                        new Student
                        {
                            Name = "Jane Smith",
                            PhoneNumber = "9876543210",
                            RegisteredOn = DateTime.Now
                        }
                    };
                    db.Students.AddRange(students);
                    db.SaveChanges();
                    Console.WriteLine("Students added successfully!");

                    // add courses =======================================================================
                    var courses = new List<Course>
                    {
                        new Course
                        {
                            Name = "C# Programming",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(3),
                            Price = 199.99m
                        },
                        new Course
                        {
                            Name = "Database Design",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddMonths(3),
                            Price = 149.99m
                        }
                    };
                    db.Courses.AddRange(courses);
                    db.SaveChanges();
                    Console.WriteLine("Courses added successfully!");

                    // add resources===========================================================================
                    var resources = new List<Resource>
                    {
                        new Resource
                        {
                            Name = "C# Basics Video",
                            Url = "http://example.com/csharp_video",
                            ResourceType = ResourceType.Video,
                            CourseId = 1
                        },
                        new Resource
                        {
                            Name = "Database Design Presentation",
                            Url = "http://example.com/database_design_presentation",
                            ResourceType = ResourceType.Presentation,
                            CourseId = 2
                        }
                    };
                    db.Resources.AddRange(resources);
                    db.SaveChanges();
                    Console.WriteLine("Resources added successfully!");

                    // add homework submissions===================================================================
                    var homeworks = new List<Homework>
                    {
                        new Homework
                        {
                            Content = @"C:\Files\homework1.zip",
                            ContentType = ContentType.Zip,
                            SubmissionTime = DateTime.Now,
                            StudentId = 1,
                            CourseId = 1
                        },
                        new Homework
                        {
                            Content = @"C:\Files\homework2.pdf",
                            ContentType = ContentType.Pdf,
                            SubmissionTime = DateTime.Now,
                            StudentId = 2,
                            CourseId = 2
                        }
                    };
                    db.HomeworkSubmissions.AddRange(homeworks);
                    db.SaveChanges();
                    Console.WriteLine("Homework submissions added successfully!");

                    // add student courses========================================================================
                    var studentCourses = new List<StudentCourse>
                    {
                        new StudentCourse
                        {
                            StudentId = 1,
                            CourseId = 1
                        },
                        new StudentCourse
                        {
                            StudentId = 2,
                            CourseId = 2
                        }
                    };
                    db.StudentCourses.AddRange(studentCourses);
                    db.SaveChanges();
                    Console.WriteLine("Student courses added successfully!");

                    Console.WriteLine("All seed data saved successfully!");
                }
                else
                {
                    Console.WriteLine("Database already contains data. Skipping seed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding data: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            }
        }
    }
}