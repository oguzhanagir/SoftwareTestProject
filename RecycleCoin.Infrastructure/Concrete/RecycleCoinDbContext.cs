using Microsoft.EntityFrameworkCore;
using RecycleCoin.Core.Models;
using RecycleCoin.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecycleCoin.Infrastructure.Concrete
{
    public class RecycleCoinDbContext : DbContext
    {

        public DbSet<User>? Users { get; set; }

  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=RecyleCoinDb; integrated security=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        
    }
}
