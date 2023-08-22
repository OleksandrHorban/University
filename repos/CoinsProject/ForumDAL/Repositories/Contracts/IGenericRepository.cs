using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDAL.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        Task AddDefToDis(int discussionId, string definitionName);
        Task<int> GetDefinitionIdByName(string definitionName);

        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<int> AddRangeAsync(IEnumerable<T> list);
        Task ReplaceAsync(T t);
        Task<int> AddAsync(T t);
    }
}
