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

       

        public RecycleCoinDbContext(DbContextOptions<RecycleCoinDbContext> options):base(options) 
        {

        }

        public DbSet<User>? Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");

            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        
    }
}
