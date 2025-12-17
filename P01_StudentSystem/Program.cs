using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Models;

namespace P01_StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>()
                .BuildServiceProvider();

            using (var context = serviceProvider.GetService<ApplicationDbContext>())
            {
                Console.WriteLine("   Hello, Student System!");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Course");
                Console.WriteLine("3. Add Resource");
                Console.WriteLine("4. Add Homework");
                Console.WriteLine("5. Enroll Student in Course");
                Console.WriteLine("-----------------------------");

                bool exit = false; 

                do
                {
                    Console.Write("\nPlease select an option: ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddStudent(context);
                            break;

                        case "2":
                            AddCourse(context);
                            break;

                        case "3":
                            AddResource(context);
                            break;

                        case "4":
                            AddHomework(context);
                            break;

                        case "5":
                            EnrollStudentInCourse(context);
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }

                    Console.WriteLine("\nDo you want to continue? (y/n): ");
                    string continueInput = Console.ReadLine();
                    if (continueInput.ToLower() != "y")
                    {
                        exit = true; 
                    }

                } while (!exit); 
            }
        }


        // Method to Add a Student
        static void AddStudent(ApplicationDbContext context)
        {
            Console.Write("\nEnter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number (optional): ");
            string phoneNumber = Console.ReadLine();

            var student = new Student
            {
                Name = name,
                PhoneNumber = phoneNumber,
                RegisteredOn = DateTime.Now
            };

            context.Students.Add(student);
            context.SaveChanges();

            Console.WriteLine("\nStudent Added Successfully!");
        }

        // Method to Add a Course
        static void AddCourse(ApplicationDbContext context)
        {
            Console.Write("\nEnter Course Name: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter Course Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            var course = new Course
            {
                Name = courseName,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                Price = price
            };

            context.Courses.Add(course);
            context.SaveChanges();

            Console.WriteLine("\nCourse Added Successfully!");
        }

        // Method to Add a Resource
        static void AddResource(ApplicationDbContext context)
        {
            Console.Write("\nEnter Resource Name: ");
            string resourceName = Console.ReadLine();

            Console.Write("Enter Resource URL: ");
            string url = Console.ReadLine();

            Console.WriteLine("Select Resource Type (1-Video, 2-Presentation, 3-Document, 4-Other): ");
            int resourceTypeOption = int.Parse(Console.ReadLine());
            ResourceType resourceType = (ResourceType)(resourceTypeOption - 1);

            Console.Write("Enter Course ID to associate with this Resource: ");
            int courseId = int.Parse(Console.ReadLine());

            var resource = new Resource
            {
                Name = resourceName,
                Url = url,
                ResourceType = resourceType,
                CourseId = courseId
            };

            context.Resources.Add(resource);
            context.SaveChanges();

            Console.WriteLine("\nResource Added Successfully!");
        }

        // Method to Add Homework===============================================
        static void AddHomework(ApplicationDbContext context)
        {
            Console.Write("\nEnter Homework Content (File path): ");
            string content = Console.ReadLine();

            Console.WriteLine("Select Content Type (1-Application, 2-Pdf, 3-Zip): ");
            int contentTypeOption = int.Parse(Console.ReadLine());
            ContentType contentType = (ContentType)(contentTypeOption - 1);

            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            var homework = new Homework
            {
                Content = content,
                ContentType = contentType,
                SubmissionTime = DateTime.Now,
                StudentId = studentId,
                CourseId = courseId
            };

            context.HomeworkSubmissions.Add(homework);
            context.SaveChanges();

            Console.WriteLine("\nHomework Added Successfully!");
        }

        // Method to Enroll Student in Course=============================================
        static void EnrollStudentInCourse(ApplicationDbContext context)
        {
            Console.Write("\nEnter Student ID to Enroll: ");
            int studentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID to Enroll in: ");
            int courseId = int.Parse(Console.ReadLine());

            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            context.StudentCourses.Add(studentCourse);
            context.SaveChanges();

            Console.WriteLine("\nStudent Enrolled in Course Successfully!");
        }
    }
}
