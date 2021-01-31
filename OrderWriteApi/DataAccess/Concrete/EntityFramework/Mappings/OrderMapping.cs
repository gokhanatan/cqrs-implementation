using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderWriteApi.DataAccess.Entities;

namespace OrderWriteApi.DataAccess.Concrete.EntityFramework.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.Code).HasColumnName("Code").HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(t => t.CreateDate).HasColumnName("CreateDate").HasColumnType("datetime").IsRequired();
            builder.Property(t => t.Status).HasColumnName("Status").HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(t => t.TotalPrice).HasColumnName("TotalPrice").HasColumnType("Money").IsRequired();
            builder.Property(t => t.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired();

        }
    }
}