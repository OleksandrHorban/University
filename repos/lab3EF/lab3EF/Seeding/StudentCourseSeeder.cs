using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;
using StudentSystem.Interfaces;

namespace StudentSystem.Seeding
{
    public class StudentCourseSeeder : ISeeder<StudentCourse>
    {

        private static readonly List<StudentCourse> sc = new()
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

        public void Seed(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasData(sc);
        }

    }
}

