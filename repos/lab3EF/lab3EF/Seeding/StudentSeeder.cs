using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Interfaces;
using StudentSystem.Data.Models;

namespace StudentSystem.Seeding
{
    public class StudentSeeder : ISeeder<Student>
    {
        private static readonly List<Student> s = new()
        {
            new Student
            {
                StudentId = 1,
                Name = "Oleksandr",
                PhoneNumber = "+123456789",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now
            },

            new Student
            {
                StudentId = 2,
                Name = "Stepan",
                PhoneNumber = "+123456789",
                RegisteredOn = DateTime.Now,
                Birthday = DateTime.Now
            }
        };

        public void Seed(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(s);
        }
    }
}
