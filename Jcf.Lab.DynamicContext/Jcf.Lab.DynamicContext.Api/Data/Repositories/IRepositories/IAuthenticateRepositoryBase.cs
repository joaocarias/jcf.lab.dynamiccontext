namespace Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories
{
    public interface IAuthenticateRepositoryBase<T> where T : class
    {
        Task<T?> AuthenticateAsync(string username, string password);
        Task<bool> UserNameInUseAsync(string username);
    }
}
