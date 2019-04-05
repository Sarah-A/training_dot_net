using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspDotNetCoreFromScratch.Migrations
{
    public partial class SeedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "OrderNumber" },
                values: new object[] { 1, new DateTime(2019, 4, 5, 11, 14, 22, 40, DateTimeKind.Local).AddTicks(9240), "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
