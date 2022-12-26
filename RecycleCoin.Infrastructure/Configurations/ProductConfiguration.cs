using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(m => m.Id).UseMySqlIdentityColumn();

            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Point).IsRequired();
            builder.Property(m => m.Quantity).IsRequired();




                 

            builder.ToTable("Products");
        }
    }
}
