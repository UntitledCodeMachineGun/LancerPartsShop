using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancerPartsShop.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4b29369-89aa-429c-96d4-2bd5267523c2",
                column: "ConcurrencyStamp",
                value: "d54843eb-96ad-4ba0-940c-a0a229108cc4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e61803d-b0bf-4db9-b850-a9ff9c75b496",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "019b7b2e-3568-4e3d-aeee-78bf9b428b41", "AQAAAAEAACcQAAAAEH38RtjnVZL2ppReozE9d3b1zPQp+z8pRP/fAhLvTXaOJLQ7nrF23vdXcRAlYtHmtw==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("08050526-d33e-40e9-b98d-e9f9b8160f77"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 29, 23, 3, 43, 370, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("3de47f54-f02d-4c98-a64f-b5313b885f9e"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 29, 23, 3, 43, 370, DateTimeKind.Utc).AddTicks(1463));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("3e23fdbf-2c09-484e-bff4-ac7acefae890"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 29, 23, 3, 43, 370, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("913507db-c5ce-4bc2-b1f9-5e54fe570873"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 29, 23, 3, 43, 370, DateTimeKind.Utc).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("deae2a12-08d2-4ef7-be64-f47d18264ca0"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 29, 23, 3, 43, 370, DateTimeKind.Utc).AddTicks(1438));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4b29369-89aa-429c-96d4-2bd5267523c2",
                column: "ConcurrencyStamp",
                value: "14fd302e-6617-4b94-9443-3e27f9d26e99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e61803d-b0bf-4db9-b850-a9ff9c75b496",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f3cfaec-c022-4671-a17b-58d3b3969918", "AQAAAAEAACcQAAAAELJSRpViOa1xnYORUTrB827rIO/8BQ8uDtGYjCa3DmE2LLw1TIWG1ie+MCbcczdOTQ==" });

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("08050526-d33e-40e9-b98d-e9f9b8160f77"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 12, 51, 56, 861, DateTimeKind.Utc).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("3de47f54-f02d-4c98-a64f-b5313b885f9e"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 12, 51, 56, 861, DateTimeKind.Utc).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("3e23fdbf-2c09-484e-bff4-ac7acefae890"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 12, 51, 56, 861, DateTimeKind.Utc).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("913507db-c5ce-4bc2-b1f9-5e54fe570873"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 12, 51, 56, 861, DateTimeKind.Utc).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "TextFields",
                keyColumn: "Id",
                keyValue: new Guid("deae2a12-08d2-4ef7-be64-f47d18264ca0"),
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 12, 51, 56, 861, DateTimeKind.Utc).AddTicks(7731));
        }
    }
}
