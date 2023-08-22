
namespace EFCollections.DAL.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ICoinsCatalogRepository CatalogRepository { get; }

        Task SaveChangesAsync();
    }
}
