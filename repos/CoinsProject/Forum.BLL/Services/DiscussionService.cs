using AutoMapper;
using Forum.BLL.DTOs;
using Forum.BLL.Interfaces;
using Forum.BLL.Profiles;
using ForumDAL.Repositories.Contracts;
using System.Data;

namespace Forum.BLL.Services
{
    public class DiscussionService : IDiscussionService
    {
        private readonly IDiscussionRepository _postRepository;

        public DiscussionService(IDiscussionRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<DiscussionDto>>GetAllDiscussions()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DiscussionProfile>();
            });
            var mapper = config.CreateMapper();

            var completePostsDto = new List<DiscussionDto>();
            var posts = await _postRepository.GetAllAsync();
            foreach(var post in posts)
            {
                DiscussionDto postDto = mapper.Map<DiscussionDto>(post);
                completePostsDto.Add(postDto);
            }
            return completePostsDto;
        }

        public async Task<DiscussionDto> GetDiscussionById(int postId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DiscussionProfile>();
            });
            var mapper = config.CreateMapper();

            var post = await _postRepository.GetAsync(postId);
            var postDto = mapper.Map<DiscussionDto>(post);
            return postDto;
        }
        public async Task<int?> GetAverageLikes()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DiscussionProfile>();
            });
            var mapper = config.CreateMapper();
            var likes = new List<int?>();
            var posts = await _postRepository.GetAllAsync();
            foreach (var post in posts)
            {
                if(post.Likes is not null)
                {
                    DiscussionDto postDto = mapper.Map<DiscussionDto>(post);
                    likes.Add(postDto.Likes);
                }
            }
            int? allLikes = 0;
            foreach(var like in likes)
            {
                allLikes += like;
            }
            int? avg = allLikes / likes.Count;
            return avg;
        }
    }
}
