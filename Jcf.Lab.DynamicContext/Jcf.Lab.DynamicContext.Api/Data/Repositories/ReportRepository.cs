using Jcf.Lab.DynamicContext.Api.Data.Contexts;
using Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories;
using Jcf.Lab.DynamicContext.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.DynamicContext.Api.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DbDynamicContextFactory _dbDynamicContextFactory;
        private readonly ILogger<ReportRepository> _logger;

        public ReportRepository(DbDynamicContextFactory dbDynamicContextFactory, ILogger<ReportRepository> logger)
        {

            _dbDynamicContextFactory = dbDynamicContextFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<Report>> GetReports(string connectionString)
        {
            try
            {
                using(var _dbContext = _dbDynamicContextFactory.Create(connectionString))
                {
                    return await _dbContext.Reports.ToListAsync();                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Report>();  
            }
        }
    }
}
