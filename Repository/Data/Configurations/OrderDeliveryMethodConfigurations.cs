using Core.Entities.Order_Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Data.Configurations
{
    public class OrderDeliveryMethodConfigurations : IEntityTypeConfiguration<OrderDeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<OrderDeliveryMethod> builder)
        {
            builder.Property(P => P.Cost)
                .HasColumnType("decimal(18,2)");
        }
    }
}