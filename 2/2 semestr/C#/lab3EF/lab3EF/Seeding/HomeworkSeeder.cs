using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;
using StudentSystem.Interfaces;
using static StudentSystem.Enums.ContentType;

namespace StudentSystem.Seeding
{
    public class HomeworkSeeder : ISeeder<Homework>
    {
        private static readonly List<Homework> h = new()
        {
            new Homework
            {
                HomeworkId = 1,
                Content = "Task",
                ContentType = ContentType.pdf,
                SubmissionTime = DateTime.Now,
                CourseId = 1,
                StudentId = 1
            },

            new Homework
            {
                HomeworkId = 2,
                Content = "Task",
                ContentType = ContentType.application,
                SubmissionTime = DateTime.Now,
                CourseId = 2,
                StudentId = 1
            }
        };

        public void Seed(EntityTypeBuilder<Homework> builder)
        {
            builder.HasData(h);
        }
    }

}
