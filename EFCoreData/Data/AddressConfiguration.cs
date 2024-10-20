using Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreData.Data
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.State).IsRequired();
            builder.Property(a => a.ZipCode).IsRequired();
            builder.Property(a => a.Country);
            builder.Property(a => a.ContactId).IsRequired();
            builder.Ignore(a => a.Contact);
            builder.HasOne(a => a.Contact) //this Contact comes from the AddressModel's properties
                .WithOne(c => c.Address) //this Address comes from the ContactModel's properties
                .HasForeignKey<AddressModel>(a => a.ContactId);
        }
    }
}
