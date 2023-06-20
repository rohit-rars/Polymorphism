using ProductOfferService = grpcservice.Protos.UserOfferService;
using AutoMapper;
using Grpc.Core;
using grpcservice.Entities;
using grpcservice.Protos;
using grpcservice.Repositories;

namespace grpcservice.Services
{
    public class UsersOfferService : ProductOfferService.UserOfferServiceBase
    {
        private readonly IProductOfferService _prductOfferService;
        private readonly IMapper _mapper;

        public UsersOfferService(IProductOfferService prductOfferService, IMapper mapper)
        {
            _prductOfferService = prductOfferService;
            _mapper = mapper;
        }

        public async override Task<UserOffers> GetUserOfferList(EmptyRequestArg request, ServerCallContext context)
        {
            var offersData = await _prductOfferService.GetOfferListAsync();

            UserOffers response = new UserOffers();
            foreach (var offer in offersData)
            {
                response.Items.Add(_mapper.Map<UserOfferDetail>(offer));
            }

            return response;
        }
    }
}
