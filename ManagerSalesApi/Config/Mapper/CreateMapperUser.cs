using AutoMapper;
using ManagerSalesApi.Controllers.Response;
using ManagerSalesApi.Models;

namespace ManagerSalesApi.Config.Mapper
{
    public class CreateMapperUser : Profile
    {
        public CreateMapperUser()
        {
            CreateMap<UserResponse, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
