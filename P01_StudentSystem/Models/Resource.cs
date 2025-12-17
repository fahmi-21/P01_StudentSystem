using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }

    public class Resource
    {
        //[Key]
        public int ResourceId { get; set; }

        //[Unicode (true)]
        //[MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Unicode (false)]
        public string Url { get; set; } = string.Empty;

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
