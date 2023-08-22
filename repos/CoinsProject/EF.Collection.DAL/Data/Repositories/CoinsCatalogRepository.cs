using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.DAL.Data.Repositories
{
    public class CoinsCatalogRepository : GenericRepository<CoinsCatalog>, ICoinsCatalogRepository
    {
        public CoinsCatalogRepository(CatalogContext catalogContext) : base(catalogContext)
        { 
        }

        public override Task<CoinsCatalog> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
