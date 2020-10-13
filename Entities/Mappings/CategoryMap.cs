using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappings
{
    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(c => c.Posts).WithOne(p => p.Category);
        }
    }
}
