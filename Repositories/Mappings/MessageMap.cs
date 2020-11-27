using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Mappings
{
    class MessageMap
    {
        public MessageMap(EntityTypeBuilder<Message> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(m => m.Chat).WithMany(c => c.Messages);
            entityTypeBuilder.HasOne(m => m.User).WithMany(u => u.Messages);
        }
    }
}
