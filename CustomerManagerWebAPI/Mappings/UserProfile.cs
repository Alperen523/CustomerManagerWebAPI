using AutoMapper;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
