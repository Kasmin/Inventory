using System;
using System.Collections.Generic;
using System.Text;
using Inventory.Data.Mappings;
using Inventory.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<InventorySheet> InventorySheets {get;set;}
        public DbSet<InventoryItem> InventoryItems {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new InventorySheetMap());
            builder.ApplyConfiguration(new InventoryItemMap());
        }
    }
}
