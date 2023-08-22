using Forum.BLL.DTOs;

namespace Forum.BLL.Interfaces
{
    public interface IDiscussionService
    {
        Task<DiscussionDto> GetDiscussionById(int id);
        Task<IEnumerable<DiscussionDto>> GetAllDiscussions();
        Task<int?> GetAverageLikes();
    }
}
