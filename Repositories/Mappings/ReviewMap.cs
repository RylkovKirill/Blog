using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Mappings
{
    public class ReviewMap
    {
        public ReviewMap(EntityTypeBuilder<Review> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(r => r.User).WithMany(u => u.Reviews);
            entityTypeBuilder.HasOne(r => r.Post).WithMany(p => p.Reviews);
        }
    }
}
