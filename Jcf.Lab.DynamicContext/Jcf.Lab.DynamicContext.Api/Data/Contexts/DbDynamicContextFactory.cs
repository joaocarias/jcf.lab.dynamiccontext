using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.DynamicContext.Api.Data.Contexts
{
    public class DbDynamicContextFactory
    {
        private readonly DbContextOptions<DbDynamicContext> dbContextOptions;

        public DbDynamicContextFactory(DbContextOptions<DbDynamicContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public DbDynamicContext Create(string connectionString)
        {
            var options = new DbContextOptionsBuilder<DbDynamicContext>()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .Options;

            return new DbDynamicContext(options, connectionString);
        }

    }
}
