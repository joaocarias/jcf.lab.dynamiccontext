using Jcf.Lab.DynamicContext.Api.Data.Contexts;
using Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories;
using Jcf.Lab.DynamicContext.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.DynamicContext.Api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly AppDbContextDefault _appDbContextDefault;

        public UserRepository(ILogger<UserRepository> logger, AppDbContextDefault appDbContextDefault)
        {
            _logger = logger;
            _appDbContextDefault = appDbContextDefault;
        }

        public async Task<User?> CreateAsync(User entity)
        {
            try
            {
                await _appDbContextDefault.Users.AddAsync(entity);
                await _appDbContextDefault.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _appDbContextDefault.Users
                                    .Include(c => c.Client)
                                    .AsNoTracking()
                                    .Where(l => l.IsActivo &&
                                                (l.ClientId == null || (l.ClientId != null && l.Client != null && l.Client.IsActivo)))
                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<User>();
            }
        }

        public async Task<User?> GetAsync(Guid id)
        {
            try
            {
                return await _appDbContextDefault.Users
                                    .Include(c => c.Client)
                                    .AsNoTracking()
                                    .Where(l => l.IsActivo 
                                                && (l.ClientId == null || (l.ClientId != null && l.Client != null && l.Client.IsActivo))
                                                && l.Id == id
                                                )
                                    .SingleOrDefaultAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
