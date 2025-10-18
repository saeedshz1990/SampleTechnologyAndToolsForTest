using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Persistence.OrderConfigs.Config
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(TableNameResource.Order);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FinalAmount).IsRequired(true);
            builder.Property(x => x.DicountPercent).IsRequired(true);
            builder.Property(x => x.NumberOfItems).IsRequired(true);
            builder.Property(x => x.OrderNumber).IsRequired(true);

            builder.HasMany(x => x.OrderItems)
                   .WithOne(x => x.Order)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(true);
        }
    }
}
