using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 28, 10, 800, DateTimeKind.Local).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 28, 10, 800, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "f5e67b1b-0af8-4a3b-899e-2de0e246b4fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "0df61a78-1a8b-4f36-9965-d606b83220ed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfcce68a-94ef-478d-a66d-3fdff6c84520", "AQAAAAEAACcQAAAAEK6swdvBm7cuGgXGUjEHX53mcx+hsLs0VtwcCnpwdivVbxWZvOvZELS9yw5xdeNMTw==", "2d7d1bb1-044a-42f1-b54b-ec0c2d9af035" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8ce57a1-50d5-4675-bbfc-28e9d102e35d", "AQAAAAEAACcQAAAAED0DtxdrvFcN4EzoRtHtn56xQ1XwwCE5yqXmQR5zpR1UGhuW4+MS6XIsl8XASWxLyQ==", "6b0691db-4656-4ada-8bf2-bd236b330f07" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 28, 10, 800, DateTimeKind.Local).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 28, 10, 800, DateTimeKind.Local).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 28, 10, 800, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 28, 10, 800, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 10, 16, 28, 10, 800, DateTimeKind.Local).AddTicks(5521));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
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
    }
}
