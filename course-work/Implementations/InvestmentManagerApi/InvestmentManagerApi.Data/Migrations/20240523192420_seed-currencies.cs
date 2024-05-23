using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestmentManagerApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedcurrencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedOn", "IsActivated", "Name", "ToEuroRate", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("116d72aa-0815-41b4-bc3e-bd4ed357a8c6"), "BGN", new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9305), true, "Lev", 1.95m, new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9306) },
                    { new Guid("66e9e89e-41a1-47d3-a43a-b365ac9f0b16"), "EUR", new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9291), true, "Euro", 1m, new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9293) },
                    { new Guid("e61f4fee-912c-4562-b7c4-2f35e49d3fac"), "USD", new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9327), true, "American Dollar", 0.93m, new DateTime(2024, 5, 23, 19, 24, 20, 406, DateTimeKind.Utc).AddTicks(9328) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("116d72aa-0815-41b4-bc3e-bd4ed357a8c6"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("66e9e89e-41a1-47d3-a43a-b365ac9f0b16"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("e61f4fee-912c-4562-b7c4-2f35e49d3fac"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Currencies");
        }
    }
}
