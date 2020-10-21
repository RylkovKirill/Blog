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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e16895dd-7352-4cb4-b1b6-2a97f596e2ae", "24cf080a-9b9a-40ef-abc5-6a63bc8c0bed", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b809eea3-e39d-4721-b56e-7a19be0b34d4", 0, "", "asp.net.core.blog@gmail.com", true, false, null, null, "ASP.NET.CORE.BLOG@GMAIL.COM", "ASP.NET.CORE.BLOG@GMAIL.COM", "AQAAAAEAACcQAAAAEOEKElUzhOEW81I9h2pnWIwnGlHOvNXypzurxZGfMpXSO4G5Fnq4qIG1b703CpyhWA==", null, false, "", null, false, "asp.net.core.blog@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("4d134864-0453-486e-85c9-661674d9a261"), null, "Дом и сад" },
                    { new Guid("8800563e-843f-49cb-b8ed-c0bdb70341c0"), null, "Еда и напитки" },
                    { new Guid("5e578c08-ab04-484c-ac42-03c3272d0eb5"), null, "Здоровье и фитнес" },
                    { new Guid("c068f9d5-cc91-43f6-ae7b-47a5f3f6b466"), null, "Наука и техника" },
                    { new Guid("9443b6be-27fc-4b5b-80ae-6190deb3f497"), null, "Новости и политика" },
                    { new Guid("bb685dac-ab24-4ecd-a291-a0542c624170"), null, "Развлечение" },
                    { new Guid("a216c6f5-0be5-4d50-84ea-ee2fee208cfc"), null, "Разное" },
                    { new Guid("66b02aec-0ab5-4af8-a969-39ac6493f5ba"), null, "Спорт" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b809eea3-e39d-4721-b56e-7a19be0b34d4", "e16895dd-7352-4cb4-b1b6-2a97f596e2ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b809eea3-e39d-4721-b56e-7a19be0b34d4", "e16895dd-7352-4cb4-b1b6-2a97f596e2ae" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d134864-0453-486e-85c9-661674d9a261"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5e578c08-ab04-484c-ac42-03c3272d0eb5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66b02aec-0ab5-4af8-a969-39ac6493f5ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8800563e-843f-49cb-b8ed-c0bdb70341c0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9443b6be-27fc-4b5b-80ae-6190deb3f497"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a216c6f5-0be5-4d50-84ea-ee2fee208cfc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb685dac-ab24-4ecd-a291-a0542c624170"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c068f9d5-cc91-43f6-ae7b-47a5f3f6b466"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e16895dd-7352-4cb4-b1b6-2a97f596e2ae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b809eea3-e39d-4721-b56e-7a19be0b34d4");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

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
