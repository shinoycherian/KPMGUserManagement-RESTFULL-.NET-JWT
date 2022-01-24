

namespace Mover.CandidateTest.Application.Mapper
{
    using AutoMapper;
    using Mover.CandidateTest.Models;
    using Mover.CandidateTest.Application.ApiModels.Product;
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductApiModel>().ReverseMap();
        }
    }
}
