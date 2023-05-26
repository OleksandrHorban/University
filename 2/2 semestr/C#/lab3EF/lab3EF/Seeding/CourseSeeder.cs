using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;
using StudentSystem.Interfaces;

namespace StudentSystem.Seeding
{
    public class CourseSeeder : ISeeder<Course>
    {
        private static readonly List<Course> c = new()
        {
            new Course
            {
                CourseId = 1,
                Name = "OOP",
                Description = "Description for OOP",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Price = 5000
            },

            new Course
            {
                CourseId = 2,
                Name = "Philosophy",
                Description = "Description for Philosophy",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Price = 1000
            }
        };

        public void Seed(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(c);
        }
    }
}
