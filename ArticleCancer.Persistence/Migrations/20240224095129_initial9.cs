using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentDetails",
                columns: table => new
                {
                    ContentDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginExitDifference = table.Column<double>(type: "float", nullable: true),
                    IsWatched = table.Column<bool>(type: "bit", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentDetails", x => x.ContentDetailID);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 51, 28, 977, DateTimeKind.Local).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 51, 28, 977, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "5395ed3f-a668-4a96-9efc-7cad5025443b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "89a55e4d-75b0-45a4-84bd-2e80fbf18a3d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7a01eca-b157-4907-9810-b996b4a0030c", "AQAAAAEAACcQAAAAEPbzNTNNuAIgjw2uFA+iAwoD61WhtjW36SPjLTpqqBB+EEvbw5kQOoBTkDY73vpxAA==", "c6f9f6d0-7c9f-4fea-9158-bc0dfd2d5c13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80b3388c-595e-4b58-9c26-fd465952c64e", "AQAAAAEAACcQAAAAEBPacj3SUA4L2B8gjt+DLQ9de7EGYmJQ6/nVnMP86f60xD2wm76US//3wOWizVmRcw==", "8d3f2c7b-289e-4b39-a09a-d51471742765" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 51, 28, 977, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 51, 28, 977, DateTimeKind.Local).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 51, 28, 977, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 51, 28, 977, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 51, 28, 977, DateTimeKind.Local).AddTicks(4215));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentDetails");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 32, 50, 164, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 32, 50, 164, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "ad43141d-60ff-41da-9050-a12f5817c172");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "ce6e5d4a-9e54-413e-9700-1922c8ce126a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700d504d-b93f-47dd-8e9f-328c32c12573", "AQAAAAEAACcQAAAAEG3uzzazSPg3zly+mUF+Cw+ieof+1TZfAIFlLXksQ3Nq42GH751H2Wo0vT+McOum+w==", "91c832e1-35e3-4cd6-9950-a9708766a9d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61789133-8d85-42c7-b6e9-32bf1af0beeb", "AQAAAAEAACcQAAAAEDIi7xxc89U2fsQQp4mS2So7zRrT6b4nvWXRd3ldy1KOW8iDf4MmgJZdPlQ8LW/Eiw==", "7f92c293-38ae-4c23-8ade-32d16a0a2cf2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 32, 50, 164, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 32, 50, 164, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 32, 50, 164, DateTimeKind.Local).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 32, 50, 164, DateTimeKind.Local).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 32, 50, 164, DateTimeKind.Local).AddTicks(2715));
        }
    }
}
