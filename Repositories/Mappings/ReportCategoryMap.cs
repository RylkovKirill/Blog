using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Mappings
{
    public class ReportCategoryMap
    {
        public ReportCategoryMap(EntityTypeBuilder<ReportCategory> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(rk => rk.Reports).WithOne(r => r.ReportCategory);
        }
    }
}
