using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddUserIdPostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29ab13dc-b38f-407f-a19a-3f5e9193ecac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("386badb6-8a12-48bf-b807-3c19eec95f32"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7512cdd7-ef41-42d3-b700-b72c6b8e032a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7ec0824c-c44b-48bb-8c0a-1dca4a79e092"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8cce6150-9f62-4b1b-bd0b-730b951d3ff3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc4b4417-f5da-4bf2-819b-783d7394dfb6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ccd7209f-2f73-4fe2-a426-b47a2c1ba808"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaa78801-d5f5-4fb4-af45-95df9d36e9e4"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

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
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("29ab13dc-b38f-407f-a19a-3f5e9193ecac"), null, "Дом и сад" },
                    { new Guid("eaa78801-d5f5-4fb4-af45-95df9d36e9e4"), null, "Еда и напитки" },
                    { new Guid("8cce6150-9f62-4b1b-bd0b-730b951d3ff3"), null, "Здоровье и фитнес" },
                    { new Guid("386badb6-8a12-48bf-b807-3c19eec95f32"), null, "Наука и техника" },
                    { new Guid("ccd7209f-2f73-4fe2-a426-b47a2c1ba808"), null, "Новости и политика" },
                    { new Guid("bc4b4417-f5da-4bf2-819b-783d7394dfb6"), null, "Развлечение" },
                    { new Guid("7ec0824c-c44b-48bb-8c0a-1dca4a79e092"), null, "Разное" },
                    { new Guid("7512cdd7-ef41-42d3-b700-b72c6b8e032a"), null, "Спорт" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
