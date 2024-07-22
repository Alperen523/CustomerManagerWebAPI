using AutoMapper;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Mappings
{
    public class LoyaltyProfile : Profile
    {
        public LoyaltyProfile()
        {
            CreateMap<LoyaltyProgram, LoyaltyProgramDto>().ReverseMap();
        }
    }
}
