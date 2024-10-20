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
    public class ContactConfiguration : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(contact => contact.id);
            //builder.Property(p => p.id).HasColumnName("id");
            builder.Property(p => p.FirstName).HasColumnName(nameof(ContactModel.FirstName)).IsRequired();
            builder.Property(p => p.LastName).HasColumnName(nameof(ContactModel.LastName)).IsRequired();
            builder.Property(p => p.Title).HasColumnName("Title");
            builder.Property(p => p.Email).HasColumnName(nameof(ContactModel.Email)).IsRequired();
            builder.Property(p => p.Phone).HasColumnName(nameof(ContactModel.Phone)).IsRequired();
            //builder.Property(p => p.Address).HasColumnName(nameof(ContactModel.Address));
                
        }
    }
}
