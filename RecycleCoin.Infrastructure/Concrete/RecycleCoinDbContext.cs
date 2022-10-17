﻿using Microsoft.EntityFrameworkCore;
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

        public RecycleCoinDbContext(DbContextOptions<RecycleCoinDbContext> options):base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=RecyleCoinDb; integrated security=true;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        
    }
}
