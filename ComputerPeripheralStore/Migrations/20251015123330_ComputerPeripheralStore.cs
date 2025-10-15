using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ComputerPeripheralStore.Migrations
{
    /// <inheritdoc />
    public partial class ComputerPeripheralStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peripherals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peripherals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Peripherals",
                columns: new[] { "Id", "AddedDate", "Category", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Keyboard", "Mechanical Keyboard", 89.99m, 10 },
                    { 2, new DateTime(2024, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Mouse", "Gaming Mouse", 49.99m, 15 },
                    { 3, new DateTime(2024, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Monitor", "4K Monitor", 299.99m, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peripherals");
        }
    }
}
