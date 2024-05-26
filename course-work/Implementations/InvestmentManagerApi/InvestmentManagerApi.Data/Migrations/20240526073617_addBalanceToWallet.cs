using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestmentManagerApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class addBalanceToWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1f711a38-3192-4095-8a76-a2e25681b3e5"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("5a7cc6fe-52bb-4bf6-aec6-6c739c9ae70f"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("6390d8d3-3b72-4ef3-ab8d-505828763952"));

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Wallets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedOn", "IsActivated", "Name", "ToEuroRate", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("08befb67-2d0a-4dcb-8ff4-edbb284da0e1"), "EUR", new DateTime(2024, 5, 26, 7, 36, 16, 386, DateTimeKind.Utc).AddTicks(6396), true, "Euro", 1m, new DateTime(2024, 5, 26, 7, 36, 16, 386, DateTimeKind.Utc).AddTicks(6399) },
                    { new Guid("3c424249-3130-4a80-a459-ec99f7d693ef"), "BGN", new DateTime(2024, 5, 26, 7, 36, 16, 386, DateTimeKind.Utc).AddTicks(6408), true, "Lev", 1.95m, new DateTime(2024, 5, 26, 7, 36, 16, 386, DateTimeKind.Utc).AddTicks(6408) },
                    { new Guid("90d7a8ea-a843-4a7b-9a6b-fa6fa75bf6f9"), "USD", new DateTime(2024, 5, 26, 7, 36, 16, 386, DateTimeKind.Utc).AddTicks(6424), true, "American Dollar", 0.93m, new DateTime(2024, 5, 26, 7, 36, 16, 386, DateTimeKind.Utc).AddTicks(6425) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("08befb67-2d0a-4dcb-8ff4-edbb284da0e1"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("3c424249-3130-4a80-a459-ec99f7d693ef"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("90d7a8ea-a843-4a7b-9a6b-fa6fa75bf6f9"));

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Wallets");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedOn", "IsActivated", "Name", "ToEuroRate", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("1f711a38-3192-4095-8a76-a2e25681b3e5"), "USD", new DateTime(2024, 5, 25, 10, 46, 59, 842, DateTimeKind.Utc).AddTicks(9426), true, "American Dollar", 0.93m, new DateTime(2024, 5, 25, 10, 46, 59, 842, DateTimeKind.Utc).AddTicks(9426) },
                    { new Guid("5a7cc6fe-52bb-4bf6-aec6-6c739c9ae70f"), "EUR", new DateTime(2024, 5, 25, 10, 46, 59, 842, DateTimeKind.Utc).AddTicks(9412), true, "Euro", 1m, new DateTime(2024, 5, 25, 10, 46, 59, 842, DateTimeKind.Utc).AddTicks(9414) },
                    { new Guid("6390d8d3-3b72-4ef3-ab8d-505828763952"), "BGN", new DateTime(2024, 5, 25, 10, 46, 59, 842, DateTimeKind.Utc).AddTicks(9422), true, "Lev", 1.95m, new DateTime(2024, 5, 25, 10, 46, 59, 842, DateTimeKind.Utc).AddTicks(9422) }
                });
        }
    }
}
