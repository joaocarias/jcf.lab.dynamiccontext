namespace Jcf.Lab.DynamicContext.Api.Models.DTOs.User
{
    public class LoginResponseDTO
    {
        public bool Auth { get; set; } = true;
        public UserResponseDTO? User { get; set; }

        public string? Token { get; set; }

        public string? Message { get; set; } = "Usuário Autenticado";
    }
}
