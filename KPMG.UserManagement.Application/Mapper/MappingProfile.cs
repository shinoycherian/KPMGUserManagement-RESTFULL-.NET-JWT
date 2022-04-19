

namespace KPMG.UserManagement.Application.Mapper
{
    using AutoMapper;
    using KPMG.UserManagement.Models;
    using KPMG.UserManagement.Application.ApiModels.User;
    public class  MappingProfile:Profile
    {
        public MappingProfile()
        {           
            CreateMap<User, RegisterUserApiRequest>().ReverseMap();
            CreateMap<User, RegisterUserApiResponse>().ReverseMap();
            CreateMap<User, UserApiModel>().ReverseMap();
        }
       
    }
}
