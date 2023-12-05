using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("343f8370-28d4-4ade-91df-7965041b98f1"), "c25a8427-00cd-41c6-8a7a-b5aaa7d2776a", "Admin", "ADMIN" },
                    { new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"), "caae5285-96dc-480d-bc7e-d17b83065b86", "Member", "MEMBER" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"), new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"), "AppUserRole" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("343f8370-28d4-4ade-91df-7965041b98f1"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), "AppUserRole" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"), new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("343f8370-28d4-4ade-91df-7965041b98f1"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

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
    }
}
