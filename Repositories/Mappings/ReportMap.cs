using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Mappings
{
    public class ReportMap
    {
        public ReportMap(EntityTypeBuilder<Report> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(r => r.User).WithMany(u => u.Reports);
            entityTypeBuilder.HasOne(r => r.Post).WithMany(p => p.Reports);
            entityTypeBuilder.HasOne(r => r.Category).WithMany(rk => rk.Reports);
        }
    }
}
