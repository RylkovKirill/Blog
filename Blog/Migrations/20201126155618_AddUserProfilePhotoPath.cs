using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class AddUserProfilePhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoPath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e16895dd-7352-4cb4-b1b6-2a97f596e2ae",
                column: "ConcurrencyStamp",
                value: "ee9b4a88-40d2-4d65-948c-ff5c45dfc9b3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b809eea3-e39d-4721-b56e-7a19be0b34d4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b7e1b20-4ad9-4d03-8032-fe33bf0deb8a", "AQAAAAEAACcQAAAAELdmeEadZouxg6MVPDQr9VgdqPlYavEB4qS/FkHaU+rRifyWxE42lyCiUmtCzqM59w==" });

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("2c1bd27d-1cf7-46bd-ad38-ae8b0199eedf"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("5177e626-a357-4722-af79-9a9efb43193e"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("b9afdb0b-87f1-484a-886d-a66d591b6cfa"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("cab6fa8f-6467-4f1f-9267-af8d35d3a0a7"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("d1ef5ca8-6510-4768-9207-b1aac15989fd"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e0124c8f-cd37-4093-b8d1-b62dfac7f2cb"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 505, DateTimeKind.Utc).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e2fe0327-4d9a-4d6f-ba7c-4f58a107fd15"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e6fd90a4-ffbc-498b-a3d8-646ae10784a9"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("06568472-51b4-4292-b7e0-a220b789c885"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("0d50b5d6-2274-4f74-a478-7671242e1348"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("516fff94-dfd1-4c94-bebd-9498048eac3d"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("520eeb61-256a-4edd-9476-5fbe69cc3f20"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("6c8b430f-99bf-460d-903e-198728353a72"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("7eca2608-2bf8-482b-a630-8e7eb2bc8724"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("83ba1239-4ef7-44a7-ae91-c5c9d0e6c100"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("bacc901a-c8fd-4f8c-b4f7-30e8a5b0d502"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 26, 15, 56, 17, 507, DateTimeKind.Utc).AddTicks(8103));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoPath",
                table: "AspNetUsers");

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
    }
}
