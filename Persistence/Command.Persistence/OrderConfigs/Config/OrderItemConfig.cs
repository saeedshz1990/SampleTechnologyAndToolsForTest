using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleTechnologyForTest.Entities;
using SampleTechnologyForTest.Entities.Entity.Orders;

namespace Command.Persistence.OrderConfigs.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(TableNameResource.OrderItem);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CountOfItem).IsRequired(true);
            builder.Property(x => x.DiscountOfAmount).IsRequired(true);

            builder.HasOne(x => x.Product)
                 .WithMany(x => x.OrderItems)
                 .HasForeignKey(x => x.ProductId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(true);
        }
    }
}
