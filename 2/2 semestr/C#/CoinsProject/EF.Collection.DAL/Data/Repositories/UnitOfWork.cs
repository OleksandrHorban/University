using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CatalogContext databaseContext;

        public ICoinsCatalogRepository CatalogRepository { get; }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(
             CatalogContext databaseContext,
             ICoinsCatalogRepository catalog)
        {
            this.databaseContext = databaseContext;

            CatalogRepository = catalog;
        }
    }
}
