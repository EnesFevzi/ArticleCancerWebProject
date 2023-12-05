using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 46, 53, 770, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 46, 53, 770, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "21ab2fe1-337d-462e-b296-fb8686a496c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "091d1f7a-1399-45cd-b264-944fbca90795");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0273723-9c5c-418f-ac29-1fc5090a4c3c", "AQAAAAEAACcQAAAAEDLVyyY+RlgscQy/7mZdNlgiMBAAXzZxYGzUHMLGjUyV8zkxHItBsXDG7R9xIJ+8eA==", "db5b1da5-b6fc-4dc0-b446-dfd54ae3605f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24949946-366b-418d-b219-da085b0103a2", "AQAAAAEAACcQAAAAEDhOIL3TbDVFNPO/85csn1RDknMini90Sz6mfquap/89UIxa5bwKep8B8kNUcP2hlw==", "2e1c77bd-957a-4254-8712-041a949a1048" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 46, 53, 770, DateTimeKind.Local).AddTicks(8775));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 46, 53, 770, DateTimeKind.Local).AddTicks(8875));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 46, 53, 770, DateTimeKind.Local).AddTicks(8878));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 28, 49, 608, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 28, 49, 608, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "c25a8427-00cd-41c6-8a7a-b5aaa7d2776a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "caae5285-96dc-480d-bc7e-d17b83065b86");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "137fe2f2-783f-4066-b498-79cc36d87f5a", "AQAAAAEAACcQAAAAECaqMdrXtYrhMiF3iYzpxqq9VFUGR7KqVohiS37ztVqDEzf26XNnvOnwWNBXO3n9HQ==", "a83c3b62-4296-4f58-8012-30a0cf398b40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0ceb0f4-7a2d-43ff-bdea-a572097328ca", "AQAAAAEAACcQAAAAEJ4/WCVgrjtqV+tF7XMKJbI1Qrjigiram+YWaT4/qnhjFPuLZe0uNvmdytZTfpGQeA==", "c140f6ff-5f00-4d0d-9a06-d4c542e94462" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 28, 49, 608, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 28, 49, 608, DateTimeKind.Local).AddTicks(8969));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 5, 20, 28, 49, 608, DateTimeKind.Local).AddTicks(8973));
        }
    }
}
