using AutoMapper;
using WebApiRegister.Entities;
using WebApiRegister.Models.Users;

namespace WebApiRegister.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
