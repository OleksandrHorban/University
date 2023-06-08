using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCollections.DAL.Exceptions;
using EFCollections.DAL.Interfaces.Repositories;
using EFCollections.DAL.Entities;

namespace EFCollections.DAL.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CatalogContext databaseContext;

        protected readonly DbSet<TEntity> table;

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await table.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id)
                ?? throw new EntityNotFoundException(
                    GetEntityNotFoundErrorMessage(id));
        }
        public abstract Task<TEntity> GetCompleteEntityAsync(int id);

        public virtual async Task InsertAsync(TEntity entity) => await table.AddAsync(entity);

        public virtual async Task UpdateAsync(TEntity entity)
        {
            try
            {
                databaseContext.Entry(entity).State = EntityState.Modified;
                await databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Обробка винятку при збереженні змін
                throw new Exception("Помилка під час оновлення запису.", ex);
            }
        }


        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await Task.Run(() => table.Remove(entity));
        }

        protected static string GetEntityNotFoundErrorMessage(int id) =>
            $"{typeof(TEntity).Name} with id {id} not found.";

        public GenericRepository(CatalogContext databaseContext)
        {
            this.databaseContext = databaseContext;
            table = this.databaseContext.Set<TEntity>();
        }

        //public virtual async Task GetByNameAsync(string name)
        //{
        //    return await table.FirstOrDefaultAsync(e => e.Name == name);
        //}

        //public virtual async Task ReplaceAsync(TEntity entity)
        //{
        //    try
        //    {
        //        databaseContext.Entry(entity).State = EntityState.Modified;
        //        await databaseContext.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Помилка під час заміни запису.", ex);
        //    }
        //}

    }
}
