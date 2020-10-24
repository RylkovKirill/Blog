using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappings
{
    public class PostCategoryMap
    {
        public PostCategoryMap(EntityTypeBuilder<PostCategory> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(c => c.Posts).WithOne(p => p.Category);
        }
    }
}
