using AutoMapper;
using CustomerManagerWebAPI.Models;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Mappings
{


    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
            CreateMap<MobilePhone, MobilePhoneDto>().ReverseMap();
        }
    }

}