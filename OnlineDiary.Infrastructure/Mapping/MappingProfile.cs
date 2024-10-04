using AutoMapper;
using OnlineDiary.Domain.Entities;
using OnlineDiary.Infrastructure.Identity;

namespace OnlineDiary.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Доменный User -> InfrastructureUser
            CreateMap<User, InfrastructureUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                // Дополнительные маппинги
                .ReverseMap();
        }
    }
}
