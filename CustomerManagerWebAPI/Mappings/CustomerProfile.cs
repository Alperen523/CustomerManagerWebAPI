using AutoMapper;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}