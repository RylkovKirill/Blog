﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappings
{
    public class CommentMap
    {
        public CommentMap(EntityTypeBuilder<Comment> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(c => c.Post).WithMany(p => p.Comments);
            entityTypeBuilder.HasOne(c => c.User).WithMany(u => u.Comments);
        }
    }
}
