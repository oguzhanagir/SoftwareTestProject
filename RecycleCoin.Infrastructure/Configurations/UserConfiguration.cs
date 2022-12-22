using Microsoft.EntityFrameworkCore;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(m => m.Id).UseMySqlIdentityColumn();

            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(m => m.LastName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.PasswordHash).IsRequired();
            builder.Property(m => m.PasswordSalt).IsRequired();

            


            builder.ToTable("Users");
        }
    }
}
