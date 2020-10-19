using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a085f11-74fc-4031-ab8b-f3db1e03089d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d546ba4-c9fa-4165-9f0c-af0a430ee103"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1dfb83d-7a85-425f-9f2d-3d4f7a3fb94a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a42f9331-fd0e-496e-9139-fa42fde4ee51"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a56db6c0-95ce-43ea-8131-f01f5a54a67a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c53ab2c0-6f37-43ea-99fa-dff0ad20c4cc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4e64bb0-d3e5-440c-a327-097bec16213d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fdbc92e8-870c-4e1b-8060-2590229dd62e"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca1bfd9b-9749-45e0-9e7b-8413a15414cc", "a4bc1989-4ee8-4c10-8b07-1fdf92168b74", "admin", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("773e0e42-fab0-4839-9d50-295080c0f52f"), null, "Дом и сад" },
                    { new Guid("89188345-b201-4827-8076-c707fe0d9721"), null, "Еда и напитки" },
                    { new Guid("5d84f307-4b97-466a-ac2a-c6656fdd5659"), null, "Здоровье и фитнес" },
                    { new Guid("e4219b54-f765-4650-8772-44eea00cf97f"), null, "Наука и техника" },
                    { new Guid("756ec259-faa3-4d38-a42a-e8e942abf101"), null, "Новости и политика" },
                    { new Guid("d2f3b43e-e84e-47b9-b3e9-948fa76d96fb"), null, "Развлечение" },
                    { new Guid("b530a79e-be67-425c-a044-79f3e9620b26"), null, "Разное" },
                    { new Guid("3acfc59c-8009-423b-9529-0e82285920a1"), null, "Спорт" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "5e7a4393-074c-405f-afc5-b97a378eb57e", "ca1bfd9b-9749-45e0-9e7b-8413a15414cc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5e7a4393-074c-405f-afc5-b97a378eb57e", "ca1bfd9b-9749-45e0-9e7b-8413a15414cc" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3acfc59c-8009-423b-9529-0e82285920a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d84f307-4b97-466a-ac2a-c6656fdd5659"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("756ec259-faa3-4d38-a42a-e8e942abf101"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("773e0e42-fab0-4839-9d50-295080c0f52f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("89188345-b201-4827-8076-c707fe0d9721"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b530a79e-be67-425c-a044-79f3e9620b26"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2f3b43e-e84e-47b9-b3e9-948fa76d96fb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e4219b54-f765-4650-8772-44eea00cf97f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca1bfd9b-9749-45e0-9e7b-8413a15414cc");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("c53ab2c0-6f37-43ea-99fa-dff0ad20c4cc"), null, "Дом и сад" },
                    { new Guid("a56db6c0-95ce-43ea-8131-f01f5a54a67a"), null, "Еда и напитки" },
                    { new Guid("8d546ba4-c9fa-4165-9f0c-af0a430ee103"), null, "Здоровье и фитнес" },
                    { new Guid("f4e64bb0-d3e5-440c-a327-097bec16213d"), null, "Наука и техника" },
                    { new Guid("a1dfb83d-7a85-425f-9f2d-3d4f7a3fb94a"), null, "Новости и политика" },
                    { new Guid("a42f9331-fd0e-496e-9139-fa42fde4ee51"), null, "Развлечение" },
                    { new Guid("fdbc92e8-870c-4e1b-8060-2590229dd62e"), null, "Разное" },
                    { new Guid("0a085f11-74fc-4031-ab8b-f3db1e03089d"), null, "Спорт" }
                });
        }
    }
}
