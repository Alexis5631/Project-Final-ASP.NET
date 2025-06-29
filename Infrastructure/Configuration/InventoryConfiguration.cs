using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class InventoryConfiguration
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("inventories");

            // Clave primaria
            builder.HasKey(d => d.IdInventory);
            builder.Property(d => d.IdInventory)
                .ValueGeneratedOnAdd()
                .IsRequired()
                .HasColumnName("id_inventory");

            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnName("name");

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