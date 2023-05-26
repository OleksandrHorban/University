using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;
using StudentSystem.Interfaces;
using static StudentSystem.Enums.ResourceType;

namespace StudentSystem.Seeding
{
    public class ResourceSeeder : ISeeder<Resource>
    {
        private static readonly List<Resource> resources = new()
        {
            new Resource
            {
                ResourceId = 1,
                Name = "Metanit",
                Url = "www.link.com",
                ResourceType = ResourceType.video,
                CourseId = 1
            },

            new Resource
            {
                ResourceId = 2,
                Name = "Entity Framework Core",
                Url = "www.linkk.com",
                ResourceType = ResourceType.video,
                CourseId = 2
            }
        };

        public void Seed(EntityTypeBuilder<Resource> builder)
        {
            builder.HasData(resources);
        }
    }
}
