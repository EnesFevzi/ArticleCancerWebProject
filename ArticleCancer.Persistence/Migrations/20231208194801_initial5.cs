using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ToDos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ToDos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ToDos",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ToDos");

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
        }
    }
}
