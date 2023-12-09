using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDos");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 23, 3, 38, 427, DateTimeKind.Local).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 23, 3, 38, 427, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "87292af2-c6c6-468d-b577-986eab035f6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "ab2ff4d4-82a0-43fb-b8a1-3bf502a4da69");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f34e781-9453-4d71-82c6-990bcd99cbef", "AQAAAAEAACcQAAAAEGTGwynowlCj1aNt3tZru7izEvhRCZ0MYY8HqG7Man9MBcY11/AB3kknzMPjmn3IsQ==", "25ffeb23-3c45-450a-9355-a60e2b067e14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0560b70-99bc-483d-9f5d-ad56f988a314", "AQAAAAEAACcQAAAAEBhXIKf+iKV+wtHx+1zwHnK8QX6Obt7xXdIqBS/X/j7Jy2Mrb7zjLnMtmVSG+OS9+w==", "dd290737-5b6d-4d49-8c9f-7ab9226613ca" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 23, 3, 38, 427, DateTimeKind.Local).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 23, 3, 38, 427, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 23, 3, 38, 427, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 23, 3, 38, 427, DateTimeKind.Local).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 23, 3, 38, 427, DateTimeKind.Local).AddTicks(6695));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 22, 48, 1, 476, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 22, 48, 1, 476, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "c2f3600d-b09c-4783-89dc-84064791b94e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "3fc72dc5-a037-4bfa-8d75-d4480de0b07f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbdeca8c-d544-4635-b840-a47eda26205f", "AQAAAAEAACcQAAAAEHTZMYXDFReLMTNumOA59bTwhXg+NusZcw8akC3XnmrNwOHZuEJaWcY8ytO66nkJig==", "d505fded-c089-4cb7-8396-1d2275b6b404" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "004a658a-4b67-420f-a38b-af0c6c7f30b6", "AQAAAAEAACcQAAAAEK7QZJspfb8cH2zFzoa9DpK/Dgyc/QVoVteE9PBBYQlIMWjT2CTSH7QkjLfW3DGlkQ==", "a0aa2422-da59-4a35-8c9a-fded7fa22ce4" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 22, 48, 1, 476, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 22, 48, 1, 476, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 22, 48, 1, 476, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 22, 48, 1, 476, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 8, 22, 48, 1, 476, DateTimeKind.Local).AddTicks(8237));
        }
    }
}
