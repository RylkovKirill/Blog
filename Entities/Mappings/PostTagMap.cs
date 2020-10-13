using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappings
{
    public class PostTagMap
    {
        public PostTagMap(EntityTypeBuilder<PostTag> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(pt => new { pt.PostId, pt.TagId });
            entityTypeBuilder.HasOne(pt => pt.Post).WithMany(p => p.Tags).HasForeignKey(pt => pt.TagId);
            entityTypeBuilder.HasOne(pt => pt.Tag).WithMany(t => t.Posts).HasForeignKey(pt => pt.PostId);
        }
    }
}
