using LR12_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LR12_2
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
