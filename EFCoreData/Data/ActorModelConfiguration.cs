using Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreData.Data
{
    public class ActorModelConfiguration : IEntityTypeConfiguration<ActorModel>
    {
        public void Configure(EntityTypeBuilder<ActorModel> builder)
        {
            builder.ToTable("Actors");
            builder.HasKey(a => a.Id);
            builder.Property(p => p.Name).HasColumnName("Name").HasMaxLength(32).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
