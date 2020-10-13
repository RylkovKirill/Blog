using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Data.Migrations
{
    public partial class AddCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
