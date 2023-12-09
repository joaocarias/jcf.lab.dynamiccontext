namespace Jcf.Lab.DynamicContext.Api.Models.Records.User
{
    public record CreateUser(string Name, string Email, string Password, Guid? ClientId);
 }
