using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_AspNetUsers_UserID",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_UserID",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ApplicationUsers");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 8, 38, 175, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 8, 38, 175, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "acc466e7-da1c-41fa-8aa0-546571cfb429");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "7a0f291f-2863-4439-91da-48476eb4ca08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ea06479-56ee-4ab8-ac6d-38d79c3194a7", "AQAAAAEAACcQAAAAEAuJmnvRhT9gE97rg96V2c8f8xuoHd9oKhWivw9jF9RsnZwxV102sKGn8cEgR1deMw==", "9eaf3bb7-ccd9-4ca7-ad5b-da812d684770" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3452ba7c-4677-40d7-93e8-dc7e11a427e7", "AQAAAAEAACcQAAAAEC0fBjL+rPjH76QVY02XeUYeMbMF+zBY5Uh4uayUvO/AdHksOsMM4MTzu3LlexkOCA==", "2a74d51a-739c-4d8f-8127-af9a0a1f5b36" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 8, 38, 175, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 8, 38, 175, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 8, 38, 175, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 8, 38, 175, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 8, 38, 175, DateTimeKind.Local).AddTicks(4267));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "ApplicationUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 1, 36, 796, DateTimeKind.Local).AddTicks(5482));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 1, 36, 796, DateTimeKind.Local).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "a638733e-d3f7-4162-8848-25352ba6858f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "8e5606f6-5b05-48e4-ba1d-18b15a15144b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeb9811f-8561-4e8e-b448-9e99ae04b1b9", "AQAAAAEAACcQAAAAEJ8K9QseH7ACBrrPOR3INSmfAavMW4purzLYRwYMp+S63sdnXsuDaRqVaxJzay6/Fw==", "74ecf729-1f46-4cc2-9d41-ebe2f8cb0d1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cc85bbe-fc0e-4c7c-97d4-ddf668ed56b2", "AQAAAAEAACcQAAAAEGDEKrODAKqjbx5mRLzOqw6pziF8mUZgr0uHMvpyMQwLD7VNaEEs/Lwj68IiN9HWDA==", "9e217f13-44d0-4763-b7ed-8f99f81c34d0" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 1, 36, 796, DateTimeKind.Local).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 1, 36, 796, DateTimeKind.Local).AddTicks(6145));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 1, 36, 796, DateTimeKind.Local).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 1, 36, 796, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 1, 36, 796, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserID",
                table: "ApplicationUsers",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_AspNetUsers_UserID",
                table: "ApplicationUsers",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
