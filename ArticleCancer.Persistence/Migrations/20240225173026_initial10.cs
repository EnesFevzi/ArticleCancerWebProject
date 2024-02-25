using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 20, 30, 25, 439, DateTimeKind.Local).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 20, 30, 25, 439, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "b571f0cf-b44b-412b-b244-1a51d09a3148");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "9a5e5e32-e651-45fb-873d-ce33337e1415");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42f0c6de-1e77-46fa-82ff-866332897a9c", "AQAAAAEAACcQAAAAEL5KPPyyrE6y1jkVaxE++RfFB5XnE1YMY+/+lDXSEh5Qbcpn+dwJ+eTkrXW2koiAWw==", "bdea4e94-0316-4a2a-9970-30e7641187c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "070c1eef-1965-45b2-ba0b-eee02d17cc72", "AQAAAAEAACcQAAAAEK5bI94DbkqGZQTwkcFxorEX6ukkWTQzugI6/aTmrIyWeUBWE4GDTN2HSzpfGJgXvQ==", "94cb7828-4bc6-4616-81be-aac17549175d" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 20, 30, 25, 439, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 20, 30, 25, 439, DateTimeKind.Local).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 20, 30, 25, 439, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 20, 30, 25, 439, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 25, 20, 30, 25, 439, DateTimeKind.Local).AddTicks(3535));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Messages");

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
    }
}
