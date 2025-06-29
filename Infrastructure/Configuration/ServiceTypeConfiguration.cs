using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ServiceTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.ToTable("service_types");

            // Clave primaria
            builder.HasKey(d => d.IdServiceType);
            builder.Property(d => d.IdServiceType)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_service_type");

            builder.Property(a => a.Description)
                .IsRequired()
                .HasColumnName("description");

            builder.Property(a => a.Duration)
                .IsRequired()
                .HasColumnName("duration");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("date")
                .HasDefaultValueSql("CURRENT_DATE")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("date")
                .HasDefaultValueSql("CURRENT_DATE")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}