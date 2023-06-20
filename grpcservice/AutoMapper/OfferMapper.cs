using grpcservice.Entities;
using AutoMapper;
using grpcservice.Protos;

namespace grpcservice.AutoMapper
{
    public class OfferMapper : Profile
    {
        public OfferMapper()
        {
            CreateMap<Offer, OfferDetail>().ReverseMap();
        }
    }
}
