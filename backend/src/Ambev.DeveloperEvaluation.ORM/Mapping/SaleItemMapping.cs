using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemMapping : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.ProductId).IsRequired();
            builder.Property(s => s.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.UnitPrice).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(s => s.Quantity).IsRequired();
            builder.Property(s => s.Discount).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(s => s.Cancelled).IsRequired();
            builder.Property(s => s.SaleId).IsRequired();
            builder.Property(s => s.TotalItem).IsRequired().HasColumnType("decimal(10,2)");
            builder.HasOne(s => s.Sale).WithMany(s => s.Items).HasForeignKey(s => s.SaleId);
        }
    }
}
