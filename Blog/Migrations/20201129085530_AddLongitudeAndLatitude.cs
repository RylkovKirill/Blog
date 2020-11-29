using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class AddLongitudeAndLatitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e16895dd-7352-4cb4-b1b6-2a97f596e2ae",
                column: "ConcurrencyStamp",
                value: "ac93dc86-adee-402f-b42b-8f26bcf8fb8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b809eea3-e39d-4721-b56e-7a19be0b34d4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "48d205dc-2052-483e-846e-0ac785febea6", "AQAAAAEAACcQAAAAEJbyukjRMp+nxjSK5HT58Ee3r35ZH+JpEfnPAvPC4iqpZALfPWasptmUNLB9F5n0aw==" });

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("2c1bd27d-1cf7-46bd-ad38-ae8b0199eedf"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("5177e626-a357-4722-af79-9a9efb43193e"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("b9afdb0b-87f1-484a-886d-a66d591b6cfa"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("cab6fa8f-6467-4f1f-9267-af8d35d3a0a7"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("d1ef5ca8-6510-4768-9207-b1aac15989fd"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(2529));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e0124c8f-cd37-4093-b8d1-b62dfac7f2cb"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 604, DateTimeKind.Utc).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e2fe0327-4d9a-4d6f-ba7c-4f58a107fd15"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e6fd90a4-ffbc-498b-a3d8-646ae10784a9"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("06568472-51b4-4292-b7e0-a220b789c885"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("0d50b5d6-2274-4f74-a478-7671242e1348"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("516fff94-dfd1-4c94-bebd-9498048eac3d"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("520eeb61-256a-4edd-9476-5fbe69cc3f20"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("6c8b430f-99bf-460d-903e-198728353a72"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("7eca2608-2bf8-482b-a630-8e7eb2bc8724"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("83ba1239-4ef7-44a7-ae91-c5c9d0e6c100"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("bacc901a-c8fd-4f8c-b4f7-30e8a5b0d502"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 29, 8, 55, 29, 606, DateTimeKind.Utc).AddTicks(5118));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e16895dd-7352-4cb4-b1b6-2a97f596e2ae",
                column: "ConcurrencyStamp",
                value: "09f8978d-5d91-44cf-9005-4bece652f42e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b809eea3-e39d-4721-b56e-7a19be0b34d4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a3dc4c9-5a2c-480e-b442-4c017d0ea898", "AQAAAAEAACcQAAAAEOfAVRkwAGv5Y0UaNGncZB48Z9A8t3IEVBrbtqWaxO618ej3PW4saZXciKpoh8O9zw==" });

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("2c1bd27d-1cf7-46bd-ad38-ae8b0199eedf"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("5177e626-a357-4722-af79-9a9efb43193e"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("b9afdb0b-87f1-484a-886d-a66d591b6cfa"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("cab6fa8f-6467-4f1f-9267-af8d35d3a0a7"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("d1ef5ca8-6510-4768-9207-b1aac15989fd"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e0124c8f-cd37-4093-b8d1-b62dfac7f2cb"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 544, DateTimeKind.Utc).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e2fe0327-4d9a-4d6f-ba7c-4f58a107fd15"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "PostCategories",
                keyColumn: "Id",
                keyValue: new Guid("e6fd90a4-ffbc-498b-a3d8-646ae10784a9"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("06568472-51b4-4292-b7e0-a220b789c885"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("0d50b5d6-2274-4f74-a478-7671242e1348"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("516fff94-dfd1-4c94-bebd-9498048eac3d"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("520eeb61-256a-4edd-9476-5fbe69cc3f20"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("6c8b430f-99bf-460d-903e-198728353a72"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("7eca2608-2bf8-482b-a630-8e7eb2bc8724"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("83ba1239-4ef7-44a7-ae91-c5c9d0e6c100"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "ReportCategories",
                keyColumn: "Id",
                keyValue: new Guid("bacc901a-c8fd-4f8c-b4f7-30e8a5b0d502"),
                column: "CreatedDate",
                value: new DateTime(2020, 11, 27, 13, 39, 1, 546, DateTimeKind.Utc).AddTicks(4532));
        }
    }
}
