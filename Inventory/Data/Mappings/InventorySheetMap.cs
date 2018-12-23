using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Data.Mappings
{
    public class InventorySheetMap : IEntityTypeConfiguration<InventorySheet>
    {
        public void Configure(EntityTypeBuilder<InventorySheet> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.InventoryItems);
            builder.HasOne(s => s.User).WithMany(u => u.InventorySheets).HasForeignKey(s => s.UserId);

            builder.HasData(
                new InventorySheet()
                {
                    Id = 1,
                    AccountNumber = "101",
                    UserId = new Guid("7d026625-3759-435e-9411-08d667f56c42"),
                }    
            );
        }
    }
}
