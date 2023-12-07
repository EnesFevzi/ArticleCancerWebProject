using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 21, 8, 30, 90, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 21, 8, 30, 90, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "43c805b6-9821-45b8-a975-500b6e09923b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "a62c4fc6-01ba-47df-97de-0144194956cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbffa3ec-0ff0-48ee-a043-856ec6fff9e8", "AQAAAAEAACcQAAAAEN8irl6Eoi3RqK3RBZxiiKmPJvTvCTjUiV152Lkyrnl7bn9y7Q3YG0k6O3cQzJgIFw==", "7e1f2ca8-e1a9-482e-9e77-f08d580ef3d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44e2635b-2b48-4e56-b97d-501d2848551e", "AQAAAAEAACcQAAAAEAJ0R//k6J52KiQhgeCjOIQyUcLROhgPo3n33+o9GKR/7wox1DTEZ3lQ1TOY0WO13w==", "4aaebd2f-31e8-4f50-a2b6-9d8c21d9a08f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 21, 8, 30, 90, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 21, 8, 30, 90, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 21, 8, 30, 90, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 21, 8, 30, 90, DateTimeKind.Local).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 7, 21, 8, 30, 90, DateTimeKind.Local).AddTicks(7608));
        }
    }
}
