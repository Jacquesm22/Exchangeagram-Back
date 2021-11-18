using ExchangeAGram.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeAGram.Infrastructure.Persistence.Configurations
{
    public class SharedPhotoConfig : IEntityTypeConfiguration<SharedPhoto>
    {
        public void Configure(EntityTypeBuilder<SharedPhoto> builder)
        {
            builder.HasOne(o => o.User).WithMany(m => m.SharedPhotos).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
