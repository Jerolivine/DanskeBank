using DanskeBank.Domain.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanskeBank.Infrastructure.EntityFramework.Core.Configuration
{
    public class CompanyScheduleConfiguration : IEntityTypeConfiguration<CompanySchedule>
    {
        public void Configure(EntityTypeBuilder<CompanySchedule> builder)
        {

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.CompanyId);
            builder.Property(t => t.Day);

        }
    }
}
