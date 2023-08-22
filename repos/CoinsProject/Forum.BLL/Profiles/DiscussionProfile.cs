using AutoMapper;
using Forum.BLL.DTOs;
using ForumDAL.Entities;

namespace Forum.BLL.Profiles
{
    public class DiscussionProfile : Profile
    {
        public DiscussionProfile()
        {
            CreateMap<Discussion, DiscussionDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes));
        }
    }
}
