using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Mappings
{
    public class ApplicationUserMap
    {
        public ApplicationUserMap(EntityTypeBuilder<ApplicationUser> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(u => u.Posts).WithOne(p => p.User);
            entityTypeBuilder.HasMany(u => u.Comments).WithOne(c => c.User);
            entityTypeBuilder.HasMany(u => u.Reviews).WithOne(r => r.User);
            entityTypeBuilder.HasMany(u => u.Reports).WithOne(r => r.User);
            entityTypeBuilder.HasMany(u => u.OutgoingRequests).WithOne(or => or.UserSender);
            entityTypeBuilder.HasMany(u => u.IncomingRequests).WithOne(ir => ir.UserReceiver);
            entityTypeBuilder.HasMany(u => u.Messages).WithOne(m => m.User);
        }
    }
}
