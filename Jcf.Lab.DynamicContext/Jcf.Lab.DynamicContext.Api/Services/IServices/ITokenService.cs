using Jcf.Lab.DynamicContext.Api.Models;
using System.Security.Claims;

namespace Jcf.Lab.DynamicContext.Api.Services.IServices
{
    public interface ITokenService
    {
        ClaimsIdentity GeradorClaims(User user);
        string NewToken(User user);
    }
}
