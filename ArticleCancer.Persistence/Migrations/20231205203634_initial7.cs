using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 23, 36, 34, 155, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 23, 36, 34, 155, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "c73d21ff-6857-4922-8bfe-269bd59e7fc5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "6f2d04bb-f772-4318-b234-fe44607414a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "ImageID", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cc6ff99-b893-4c41-ac66-0f19ed568b42", new Guid("01673030-c382-45f8-84dc-a095bf6a7532"), "AQAAAAEAACcQAAAAEM2Wvk+5jA+3PtZ8mV5qOjJ3dpFVQxjhPebCIqyWefjPeSCV4w+HM0Y7DbyPRA3urg==", "112725e1-546e-4f7a-96c5-606fe394f55c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "ImageID", "PasswordHash", "SecurityStamp" },
                values: new object[] { "787b174b-f961-4bc9-b638-04dec1ee7057", new Guid("01673030-c382-45f8-84dc-a095bf6a7532"), "AQAAAAEAACcQAAAAEF81UZkeG4MBISmr6bf4gx0cvdB+t1inJWqc6sanu+9kRzMpn5zFTsQ9drwaBkTk8g==", "b4417bbd-b695-4751-a61a-14a9760c2c29" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 23, 36, 34, 155, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 23, 36, 34, 155, DateTimeKind.Local).AddTicks(6092));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 23, 36, 34, 155, DateTimeKind.Local).AddTicks(6095));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 53, 11, 904, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 53, 11, 904, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "8e8df043-ae14-41ae-8176-3078c6e0a774");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "76927235-e7bc-4a20-9dc3-665e996677c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "ImageID", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b3c02b7-8de0-4dfb-9912-66ac4619a918", new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), "AQAAAAEAACcQAAAAEHbdreg4rdt6uc1LZ3K3oYL2nkzHsvxQjei/NkKi5oVMnpeQzwrcQD2X02fsunpg+w==", "d89fa36b-8c11-470a-a5af-49d5f38e93d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "ImageID", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dec687c-c01a-42db-93d4-a08dec2313bf", new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), "AQAAAAEAACcQAAAAEKKCkiwC/e3wU8D9WuBG2JN2RnOBxCl1ordTgukNzGjQxiZas2oJpOiuK99bAe+2Ew==", "1e0b245c-1627-458d-ae30-917ce05637db" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 53, 11, 904, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 53, 11, 904, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 53, 11, 904, DateTimeKind.Local).AddTicks(6954));
        }
    }
}
