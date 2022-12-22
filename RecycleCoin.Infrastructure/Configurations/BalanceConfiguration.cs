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
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value).IsRequired();

        }
    }
}
