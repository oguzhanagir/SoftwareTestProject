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
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<UserRoleMapping>? UserRoleMappings  { get; set; }


       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
        }

        
    }
}
