using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_AppUserId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_AppUserId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ToDos");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "ToDos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 0, 0, 57, 76, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 0, 0, 57, 76, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "2649fee3-5e66-40eb-b885-5c6bfb6272af");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "e2361dc1-5c4f-4d2e-8d73-f2c9b896b758");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a427370f-609c-457b-8fca-a36e6d7e4c8c", "AQAAAAEAACcQAAAAEKmBMYF2bYXBlLY12LmgZGwAOVH72OGltJ0S/Cq4ByNny3zkwTDl1EIa62FfqipznA==", "f83995cd-164f-4516-8d10-68432c5924e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db8c6532-7c47-4bff-8512-3e9931f7d0a2", "AQAAAAEAACcQAAAAEFpfGygqkGPlRGm/1Y2Qjauztp/P8p278TN5gfSSzQKQsvESFg0pMbJUD+/Tht1KNw==", "3bad1356-a263-4955-91a2-b62920c9a449" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 0, 0, 57, 76, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 0, 0, 57, 76, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 0, 0, 57, 76, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 0, 0, 57, 76, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 0, 0, 57, 76, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_UserID",
                table: "ToDos",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_UserID",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ToDos");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "ToDos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 22, 17, 11, 397, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 22, 17, 11, 397, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "1f1e1ea7-75cd-477d-84a2-8da446dd41c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "94fe3d93-481d-49ab-8b63-242ef19b5d7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1826264b-8027-4911-896c-5f0d7b8af06e", "AQAAAAEAACcQAAAAENjQ+FTjQ4U2gQrvX9uNHaPm9bVOSxXqUJVoGVaRcEZClJRprHdZC89oDdZ3886bpQ==", "8670ba10-3051-4d44-960c-4b8f9bc100dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d5fdfd5-6dfd-43d7-bd59-403c2a5172b9", "AQAAAAEAACcQAAAAEHGshwUx5rW15Axw1wJy8D+gxfNYF1gE1MENvF1khUU0KlUd1uCNIL5ci1vEmMV26A==", "748d44b0-abf6-4422-9542-8619e870d0ef" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 22, 17, 11, 397, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 22, 17, 11, 397, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 22, 17, 11, 397, DateTimeKind.Local).AddTicks(5167));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 22, 17, 11, 397, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 22, 17, 11, 397, DateTimeKind.Local).AddTicks(5256));

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_AppUserId",
                table: "ToDos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_AppUserId",
                table: "ToDos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
