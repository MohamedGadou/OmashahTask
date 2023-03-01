using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmashahTask.Domain.Entities;

namespace OmashahTask.Infrastructure.EntityConfigs
{
    public class ItemEntityTypeConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(e => e.Id);
        }
    }
}
