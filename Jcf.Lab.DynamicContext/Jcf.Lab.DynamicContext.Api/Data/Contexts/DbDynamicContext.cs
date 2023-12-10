using Jcf.Lab.DynamicContext.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.DynamicContext.Api.Data.Contexts
{
    public class DbDynamicContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Report> Reports { get; set; }

        public DbDynamicContext(DbContextOptions<DbDynamicContext> options, string connectionString):base(options)
        {
            _connectionString = connectionString;
        }

        public DbDynamicContext(DbContextOptions<DbDynamicContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
