using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.DynamicContext.Api.Models.DTOs.Client
{
    public class ClientResponseDTO
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string ConnectionString { get; set; }

        public ClientResponseDTO() { }
    }
}
