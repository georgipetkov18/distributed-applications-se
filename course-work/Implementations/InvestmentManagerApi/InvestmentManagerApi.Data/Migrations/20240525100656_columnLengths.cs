using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestmentManagerApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class columnLengths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Etfs",
                type: "nvarchar(127)",
                maxLength: 127,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Currencies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currencies",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Etfs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(127)",
                oldMaxLength: 127);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

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
    }
}
