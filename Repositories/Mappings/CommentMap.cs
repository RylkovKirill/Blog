using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Mappings
{
    public class CommentMap
    {
        public CommentMap(EntityTypeBuilder<Comment> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(c => c.Post).WithMany(p => p.Comments).OnDelete(DeleteBehavior.Cascade);
            entityTypeBuilder.HasOne(c => c.User).WithMany(u => u.Comments);
        }
    }
}
