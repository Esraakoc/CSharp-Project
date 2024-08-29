using AutoMapper;
using EK.Entities.Models;
using EK.Business.Dto;

namespace EK.Api.Profiles
{
    public class EkUserProfile : Profile
    {
        public EkUserProfile()
        {
            CreateMap<EkUser, EkUserDto>().ReverseMap();
        }
    }
}
