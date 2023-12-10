using Jcf.Lab.DynamicContext.Api.Models;

namespace Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReports(string connectionString);
    }
}
