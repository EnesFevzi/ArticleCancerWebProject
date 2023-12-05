using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 19, 59, 26, 485, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 19, 59, 26, 485, DateTimeKind.Local).AddTicks(110));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9476d6e-b347-437c-8579-073a50e4f4ea", "AQAAAAEAACcQAAAAEPEzT74QS3+ouJQMzP5nllE2C6k8RSZynGh6b+IdSPI5CrLPQesnfCNEYsqlO0NGhA==", "d76155d6-7b4a-4b4b-a17b-c84e917fda0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8fe5ca8-9237-4b2b-9cfa-39cc6fe2914c", "AQAAAAEAACcQAAAAEKcgUD4e3/33GTE3B+jIGh5bj0Z+2MwQ5MkUcv7Cs29iWnTUFbsNeGvzp9Jc3dfC9g==", "1ea75a0b-a0be-40eb-91e5-aa3df30eca9c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 19, 59, 26, 485, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 19, 59, 26, 485, DateTimeKind.Local).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 19, 59, 26, 485, DateTimeKind.Local).AddTicks(969));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 17, 26, 10, 525, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 17, 26, 10, 525, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d30458a-5f9c-4d8b-b36a-817fd81a92ae", "AQAAAAEAACcQAAAAEJdSer2AnSZb455Ap37x6E0MadVMKlvCbezToB8eGG2+LJ8baf9/3Ei9576PY6Zozg==", "0bf861a7-efde-422a-a94e-787f19b60b0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd0d3c2c-72e0-44a0-9ec9-c107f8226783", "AQAAAAEAACcQAAAAECpgtBzCnk/eE+e9smtL7XKYed7JlIj+D87Qu2wS+u6+pcrEYpGHbiL+m+rCw3ekBg==", "34cd2e95-be72-4f99-87c8-e5d75514fe69" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 17, 26, 10, 525, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 17, 26, 10, 525, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 17, 26, 10, 525, DateTimeKind.Local).AddTicks(9693));
        }
    }
}
