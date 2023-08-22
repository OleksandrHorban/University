using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCollections.DAL.Interfaces
{
    public interface ISeeder<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);
    }
}
