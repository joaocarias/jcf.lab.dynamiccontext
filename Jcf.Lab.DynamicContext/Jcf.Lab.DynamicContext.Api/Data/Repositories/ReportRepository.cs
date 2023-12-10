using Dapper;
using Jcf.Lab.DynamicContext.Api.Data.Contexts;
using Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories;
using Jcf.Lab.DynamicContext.Api.Models;

namespace Jcf.Lab.DynamicContext.Api.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
      
        private readonly ILogger<ReportRepository> _logger;      

        public ReportRepository(ILogger<ReportRepository> logger)
        {
            _logger = logger;            
        }

        public async Task<IEnumerable<Report>> GetReports(string connectionString)
        {
            try
            {
                var sql = @"                                 
                            SELECT Id, 
                                MyClient, 
                                MyTest, 
                                MyText
                            FROM 
                                reports
                            ";

                using var _dapperContext = new AppDbDapperDynamicContext(connectionString);
                var result = await _dapperContext.Connection.QueryAsync<Report>(sql, null, _dapperContext.Transaction);
                return result ?? Enumerable.Empty<Report>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Enumerable.Empty<Report>();  
            }
        }
    }
}
