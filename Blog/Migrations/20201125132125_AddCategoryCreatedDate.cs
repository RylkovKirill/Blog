using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class AddCategoryCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ReportCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PostCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e16895dd-7352-4cb4-b1b6-2a97f596e2ae",
                column: "ConcurrencyStamp",
                value: "aa86cc43-00c4-4c86-ae84-8bd4816eac81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b809eea3-e39d-4721-b56e-7a19be0b34d4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad56d321-43ee-483b-b724-492d0c27181d", "AQAAAAEAACcQAAAAEBuH6oyzxu8VbmewHy06qwucnDkI3ei8j5OFe2zXJqwYGb2h3kqkfxMKBjIKaRdL+Q==" });

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("2c1bd27d-1cf7-46bd-ad38-ae8b0199eedf"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 82, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("5177e626-a357-4722-af79-9a9efb43193e"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 82, DateTimeKind.Local).AddTicks(9088));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("b9afdb0b-87f1-484a-886d-a66d591b6cfa"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 82, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("cab6fa8f-6467-4f1f-9267-af8d35d3a0a7"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 82, DateTimeKind.Local).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("d1ef5ca8-6510-4768-9207-b1aac15989fd"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 82, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e0124c8f-cd37-4093-b8d1-b62dfac7f2cb"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 81, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e2fe0327-4d9a-4d6f-ba7c-4f58a107fd15"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 82, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e6fd90a4-ffbc-498b-a3d8-646ae10784a9"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 16, 21, 24, 82, DateTimeKind.Local).AddTicks(9193));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("06568472-51b4-4292-b7e0-a220b789c885"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("0d50b5d6-2274-4f74-a478-7671242e1348"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("516fff94-dfd1-4c94-bebd-9498048eac3d"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(1225));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("520eeb61-256a-4edd-9476-5fbe69cc3f20"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("6c8b430f-99bf-460d-903e-198728353a72"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("7eca2608-2bf8-482b-a630-8e7eb2bc8724"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("83ba1239-4ef7-44a7-ae91-c5c9d0e6c100"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("bacc901a-c8fd-4f8c-b4f7-30e8a5b0d502"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 25, 13, 21, 24, 83, DateTimeKind.Utc).AddTicks(1249));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ReportCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PostCategories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e16895dd-7352-4cb4-b1b6-2a97f596e2ae",
                column: "ConcurrencyStamp",
                value: "ba3d5292-c6c7-44d9-b678-e02eaee8f11d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b809eea3-e39d-4721-b56e-7a19be0b34d4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45dc673c-2672-4d9b-810b-3ed5b45d5cf7", "AQAAAAEAACcQAAAAEEq4FJ1qg+MvPXnHLtZlJiIx2fwij4hxO7F5/r2K/fvt9huPA/uIS1J+jRXTrGFXwA==" });
        }
    }
}
