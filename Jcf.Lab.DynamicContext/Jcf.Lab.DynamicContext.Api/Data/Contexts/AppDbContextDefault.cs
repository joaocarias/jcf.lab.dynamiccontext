﻿using Jcf.Lab.DynamicContext.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Lab.DynamicContext.Api.Data.Contexts
{
    public class AppDbContextDefault : DbContext
    {
        public AppDbContextDefault(DbContextOptions<AppDbContextDefault> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
