using Jcf.Lab.DynamicContext.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.DynamicContext.Api.Data.Contexts
{
    public class AppDbContextDefault : DbContext
    {
        public AppDbContextDefault(DbContextOptions<AppDbContextDefault> options) : base(options) { }

        DbSet<User> Users { get; set; }
        DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }    
    }
}
