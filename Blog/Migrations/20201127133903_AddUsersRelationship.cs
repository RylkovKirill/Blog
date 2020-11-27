using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class AddUsersRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstUserId = table.Column<string>(nullable: true),
                    SecondUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserSenderId = table.Column<string>(nullable: true),
                    UserReceiverId = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_UserReceiverId",
                        column: x => x.UserReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_UserSenderId",
                        column: x => x.UserSenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    PostedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ChatId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FirstUserId",
                table: "Chats",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SecondUserId",
                table: "Chats",
                column: "SecondUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserReceiverId",
                table: "Requests",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserSenderId",
                table: "Requests",
                column: "UserSenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

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
    }
}
