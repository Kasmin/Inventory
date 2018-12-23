using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.Data.Mappings
{
    public class InventoryItemMap : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasOne(i => i.InventorySheet).WithMany(s => s.InventoryItems).HasForeignKey(i => i.InventorySheetId);

            builder.HasData(
                new InventoryItem()
                {
                    Id = 1,
                    Name = "АТС Panasonic NCP500",
                    InventoryNumber = "ВА2162",
                    Count = 1,
                    Cost = 83250.00,
                    DateOfRegistration = new DateTime(2007, 7, 20),
                    LifeTime = 20,
                    Description = "ул. Правда 25А, Серверная №1",
                    InventorySheetId = 1
                },
                new InventoryItem()
                {
                    Id = 2,
                    Name = "VipNet Coordinator HW1000",
                    InventoryNumber = "ВА2198",
                    Count = 1,
                    Cost = 287290.00,
                    DateOfRegistration = new DateTime(2012, 9, 20),
                    LifeTime = 20,
                    Description = "ул. Правда 25А, Серверная №1",
                    InventorySheetId = 1
                },
                new InventoryItem()
                {
                    Id = 3,
                    Name = "IP телефон Cisco CP7911",
                    InventoryNumber = "ВА2212",
                    Count = 1,
                    Cost = 7290.00,
                    DateOfRegistration = new DateTime(2013, 3, 20),
                    LifeTime = 10,
                    Description = "ул. Правда 25А, ЦУКС, Смена ОДС",
                    InventorySheetId = 1
                }
           );
        }
    }
}
