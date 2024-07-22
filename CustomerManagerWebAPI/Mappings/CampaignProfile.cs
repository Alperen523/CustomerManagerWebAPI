using AutoMapper;
using CustomerManagerWebApiByAlp.Models;


namespace CustomerManagerWebApiByAlp.Mappings
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignDto>().ReverseMap();
        }
    }
}
