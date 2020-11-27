using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Mappings
{
    class ChatMap
    {
        public ChatMap(EntityTypeBuilder<Chat> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(c => c.Messages).WithOne(m => m.Chat);
        }
    }
}
