using Invoice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreData.Data
{
    public class InvoiceItemModelConfiguration : IEntityTypeConfiguration<InvoiceItemModel>
    {
        public void Configure(EntityTypeBuilder<InvoiceItemModel> builder)
        {
            builder.ToTable("InvoiceItems"); //InvoiceItems is the name of the table that you specified in the DbContext
            builder.Property(p => p.Id).HasColumnName(nameof(InvoiceItemModel.Id));
            builder.Property(p => p.ItemName).HasColumnName(nameof(InvoiceItemModel.ItemName)).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Description).HasColumnName(nameof(InvoiceItemModel.Description)).HasMaxLength(256);
            builder.Property(p => p.UnitPrice).HasColumnName(nameof(InvoiceItemModel.UnitPrice)).HasPrecision(8, 2);
            builder.Property(p => p.Quantity).HasColumnName(nameof(InvoiceItemModel.Quantity)).HasPrecision(8, 2);
            builder.Property(p => p.Amount).HasColumnName(nameof(InvoiceItemModel.Amount)).HasPrecision(18, 2);
            builder.Property(p => p.InvoiceId).HasColumnName(nameof(InvoiceItemModel.InvoiceId));
        }
    }
}
