using grpcservice.Entities;
using AutoMapper;
using grpcservice.Protos;

namespace grpcservice.AutoMapper
{
    public class UserOfferMapper : Profile
    {
        public UserOfferMapper()
        {
            CreateMap<Offer, UserOfferDetail>().ReverseMap();
        }
    }
}
