using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class AnotherCatalogRepository : GenericRepository<AnotherCatalog>, IAnotherCatalogRepository
    {
        public AnotherCatalogRepository(CatalogContext catalogContext) : base(catalogContext)
        {
        }

        public override Task<AnotherCatalog> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
