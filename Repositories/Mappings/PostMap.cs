using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Mappings
{
    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(p => p.Category).WithMany(c => c.Posts);
            entityTypeBuilder.HasMany(p => p.Comments).WithOne(c => c.Post).OnDelete(DeleteBehavior.Cascade);
            entityTypeBuilder.HasMany(u => u.Reports).WithOne(r => r.Post);
        }
    }
}
