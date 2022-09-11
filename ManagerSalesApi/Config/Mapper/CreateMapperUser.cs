using AutoMapper;
using ManagerSalesApi.Controllers.Request;
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
            CreateMap<User, UserRequest>();
            CreateMap<UserRequest, User>();
            CreateMap<Opportunity, OpportunityRequest>();
            CreateMap<OpportunityRequest, Opportunity>();
        }
    }
}
