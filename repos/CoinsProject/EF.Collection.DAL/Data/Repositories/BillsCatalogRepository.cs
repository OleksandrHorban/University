using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;

namespace EFCollections.DAL.Data.Repositories
{
    public class BillsCatalogRepository : GenericRepository<BillsCatalog>, IBillsCatalogRepository
    {
        public BillsCatalogRepository(CatalogContext catalogContext) : base(catalogContext)
        {
        }

        public override Task<BillsCatalog> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
