using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappings
{
    public class PostMap
    {
        public PostMap(EntityTypeBuilder<Post> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(p => p.Category).WithMany(c => c.Posts);
            entityTypeBuilder.HasMany(p => p.Comments).WithOne(c => c.Post);
        }
    }
}
