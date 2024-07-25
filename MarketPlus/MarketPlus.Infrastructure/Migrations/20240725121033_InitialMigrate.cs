using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarketPlus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false, comment: "Product name"),
                    Description = table.Column<string>(type: "TEXT", nullable: true, comment: "Product description"),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true, comment: "Product status with default value in true"),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false, comment: "Produc quantity"),
                    Price_Amount = table.Column<decimal>(type: "TEXT", nullable: true),
                    Price_Currency = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true, comment: "Creation audit"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true, comment: "Update audit"),
                    DeletedAt = table.Column<DateTime>(type: "TEXT", nullable: true, comment: "Delete audit")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "Status", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8a3b695a-ca34-4b22-8ce4-36fc2ff5710c"), new DateTime(2024, 7, 25, 7, 10, 33, 143, DateTimeKind.Local).AddTicks(7119), null, "Camiseta oficial de colombia", "Camiseta", true, 10, null },
                    { new Guid("a6e3cd29-04b3-47d0-9d89-08bf50888237"), new DateTime(2024, 7, 25, 7, 10, 33, 143, DateTimeKind.Local).AddTicks(7080), null, "Guayos futbol", "Guayos", true, 5, null },
                    { new Guid("d579c47e-b292-4b39-848c-0cc4d4771f15"), new DateTime(2024, 7, 25, 7, 10, 33, 143, DateTimeKind.Local).AddTicks(7121), null, "Balón copa america", "Balon", true, 15, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
