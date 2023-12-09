using Jcf.Lab.DynamicContext.Api.Data.Contexts;
using Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories;
using Jcf.Lab.DynamicContext.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.DynamicContext.Api.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ILogger<ClientRepository> _logger;
        private readonly AppDbContextDefault _appDbContextDefault;

        public ClientRepository(ILogger<ClientRepository> logger, AppDbContextDefault appDbContextDefault)
        {
            _logger = logger;
            _appDbContextDefault = appDbContextDefault;
        }

        public async Task<Client> CreateAsync(Client entity)
        {
            try
            {
                await _appDbContextDefault.Clients.AddAsync(entity);
                await _appDbContextDefault.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            try
            {
                return await _appDbContextDefault.Clients
                                    .AsNoTracking()
                                    .Where(l => l.IsActivo).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Client>();
            }
        }

        public async Task<Client?> GetAsync(Guid id)
        {
            try
            {
                return await _appDbContextDefault.Clients                                   
                                    .AsNoTracking()
                                    .Where(l => l.IsActivo && l.Id == id)
                                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
