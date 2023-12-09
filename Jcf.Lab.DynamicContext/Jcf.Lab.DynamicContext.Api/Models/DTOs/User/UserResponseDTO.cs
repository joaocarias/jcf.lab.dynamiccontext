using Jcf.Lab.DynamicContext.Api.Models.DTOs.Client;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.DynamicContext.Api.Models.DTOs.User
{
    public class UserResponseDTO
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public Guid? ClientId { get; set; }

        public ClientResponseDTO? Client { get; set; }

        public UserResponseDTO()
        {
        }
    }
}
