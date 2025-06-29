using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class DiagnosticConfiguration
    {
        public void Configure(EntityTypeBuilder<Diagnostic> builder)
        {
            builder.ToTable("diagnostics");

            // Clave primaria
            builder.HasKey(d => d.IdDiagnostic);
            builder.Property(d => d.IdDiagnostic)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_diagnostic");

            builder.Property(a => a.Description)
                .IsRequired()
                .HasColumnName("description");

            builder.Property(a => a.IdUser)
                .IsRequired()
                .HasColumnName("id_user");

            builder.HasOne(dd => dd.User)
                   .WithMany(so => so.Diagnostics)
                   .HasForeignKey(dd => dd.IdUser);

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