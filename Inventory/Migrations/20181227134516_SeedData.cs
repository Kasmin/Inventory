using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Organisation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7d026625-3759-435e-9411-08d667f56c42"), 0, "44fe737e-d684-4aac-a6c3-9baad012e36a", "user@user.ru", false, true, null, "USER@USER.RU", "USER@USER.RU", null, "AQAAAAEAACcQAAAAEG0qRduIF1IoSaSKLwjNralERLDt62StIlFFIA2V77c1dV1qJrw/SemWIWrWeOtyLw==", null, false, null, "PTY4YHQHQOBOTTKVGZUKUCQVK2GAPPS5", false, "user@user.ru" });

            migrationBuilder.InsertData(
                table: "InventorySheets",
                columns: new[] { "Id", "AccountNumber", "UserId" },
                values: new object[] { 1, "101", new Guid("7d026625-3759-435e-9411-08d667f56c42") });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "Id", "Cost", "Count", "DateOfRegistration", "Description", "InventoryNumber", "InventorySheetId", "LifeTime", "Name" },
                values: new object[] { 1, 83250.0, 1, new DateTime(2007, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ул. Правда 25А, Серверная №1", "ВА2162", 1, 20, "АТС Panasonic NCP500" });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "Id", "Cost", "Count", "DateOfRegistration", "Description", "InventoryNumber", "InventorySheetId", "LifeTime", "Name" },
                values: new object[] { 2, 287290.0, 1, new DateTime(2012, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ул. Правда 25А, Серверная №1", "ВА2198", 1, 20, "VipNet Coordinator HW1000" });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "Id", "Cost", "Count", "DateOfRegistration", "Description", "InventoryNumber", "InventorySheetId", "LifeTime", "Name" },
                values: new object[] { 3, 7290.0, 1, new DateTime(2013, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ул. Правда 25А, ЦУКС, Смена ОДС", "ВА2212", 1, 10, "IP телефон Cisco CP7911" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InventorySheets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { new Guid("7d026625-3759-435e-9411-08d667f56c42"), "44fe737e-d684-4aac-a6c3-9baad012e36a" });
        }
    }
}
