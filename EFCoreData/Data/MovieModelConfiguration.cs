﻿using Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreData.Data
{
    public class MovieModelConfiguration : IEntityTypeConfiguration<MovieModel>
    {
        public void Configure(EntityTypeBuilder<MovieModel> builder)
        {
            builder.ToTable("Movies");
            builder.HasKey(m => m.Id);
            builder.Property(p => p.Title).HasColumnName("Title").HasMaxLength(128).IsRequired();
            builder.HasIndex(p => p.Title).IsUnique();
            builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(512);
            builder.HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity<MovieActors>(
                    j => j
                        .HasOne(ma => ma.Actor)
                        .WithMany(a => a.MovieActors)
                        .HasForeignKey(ma => ma.ActorId),
                    j => j
                        .HasOne(ma => ma.Movie)
                        .WithMany(m => m.MovieActors)
                        .HasForeignKey(ma => ma.MovieId),
                    j =>
                    {
                        // You can add more configuration here
                        j.Property(ma => ma.UpdateTime).HasColumnName("UpdateTime").HasDefaultValueSql("CURRENT_TIMESTAMP");
                        j.HasKey(ma => new { ma.MovieId, ma.ActorId });
                    }
                );
        }
    }
}
