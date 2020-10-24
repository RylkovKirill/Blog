using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Mappings
{
    public class ReportMap
    {
        public ReportMap(EntityTypeBuilder<Report> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(r => r.User).WithMany(u => u.Reports);
            entityTypeBuilder.HasOne(r => r.Post).WithMany(p => p.Reports);
            entityTypeBuilder.HasOne(r => r.ReportCategory).WithMany(rk => rk.Reports);
        }
    }
}
