using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestmentManagerApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class doNotSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("03c113ad-ee4e-4242-b346-17796ac0010b"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("1325cc7d-1539-417d-a6c7-7ac6e05eedc7"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("dcfa1df1-f2c0-48e6-857c-65e8aa2b4802"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("103f79cd-a084-46d7-a317-edd5a38ac6c8"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedOn", "IsActivated", "Name", "ToEuroRate", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("03c113ad-ee4e-4242-b346-17796ac0010b"), "USD", new DateTime(2024, 5, 25, 10, 6, 56, 490, DateTimeKind.Utc).AddTicks(2919), true, "American Dollar", 0.93m, new DateTime(2024, 5, 25, 10, 6, 56, 490, DateTimeKind.Utc).AddTicks(2919) },
                    { new Guid("1325cc7d-1539-417d-a6c7-7ac6e05eedc7"), "EUR", new DateTime(2024, 5, 25, 10, 6, 56, 490, DateTimeKind.Utc).AddTicks(2869), true, "Euro", 1m, new DateTime(2024, 5, 25, 10, 6, 56, 490, DateTimeKind.Utc).AddTicks(2872) },
                    { new Guid("dcfa1df1-f2c0-48e6-857c-65e8aa2b4802"), "BGN", new DateTime(2024, 5, 25, 10, 6, 56, 490, DateTimeKind.Utc).AddTicks(2881), true, "Lev", 1.95m, new DateTime(2024, 5, 25, 10, 6, 56, 490, DateTimeKind.Utc).AddTicks(2882) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CreatedOn", "Email", "FirstName", "IsActivated", "LastName", "Password", "UpdatedOn" },
                values: new object[] { new Guid("103f79cd-a084-46d7-a317-edd5a38ac6c8"), 21, new DateTime(2024, 5, 25, 10, 6, 56, 504, DateTimeKind.Utc).AddTicks(1266), "admin@admin.bg", "Georgi", true, "Petkov", "YDg11ABmw9wAkNQ3MpQ9rQiP+wNCH6drZSz5+xxHM20=", new DateTime(2024, 5, 25, 10, 6, 56, 504, DateTimeKind.Utc).AddTicks(1271) });
        }
    }
}
