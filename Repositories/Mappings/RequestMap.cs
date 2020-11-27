using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Mappings
{
    class RequestMap
    {
        public RequestMap(EntityTypeBuilder<Request> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(r => r.UserSender).WithMany(us => us.OutgoingRequests);
            entityTypeBuilder.HasOne(r => r.UserReceiver).WithMany(ur => ur.IncomingRequests);
        }
    }
}
