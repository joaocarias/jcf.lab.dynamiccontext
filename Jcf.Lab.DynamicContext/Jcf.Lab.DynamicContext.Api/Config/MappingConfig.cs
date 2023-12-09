using AutoMapper;
using Jcf.Lab.DynamicContext.Api.Models;
using Jcf.Lab.DynamicContext.Api.Models.DTOs.Client;
using Jcf.Lab.DynamicContext.Api.Models.DTOs.User;

namespace Jcf.Lab.DynamicContext.Api.Config
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserResponseDTO, User>().ReverseMap();

            CreateMap<ClientResponseDTO, Client>().ReverseMap();
        }
    }
}
