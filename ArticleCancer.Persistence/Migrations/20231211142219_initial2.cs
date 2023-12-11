using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleCancer.Persistence.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoBlogs_Video_VideoID",
                table: "VideoBlogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Videos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "VideoID");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnouncementID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnouncementID);
                    table.ForeignKey(
                        name: "FK_Announcements_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Announcements_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ImageID");
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementVisitors",
                columns: table => new
                {
                    AnnouncementID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorID = table.Column<int>(type: "int", nullable: false),
                    ArticleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementVisitors", x => new { x.AnnouncementID, x.VisitorID });
                    table.ForeignKey(
                        name: "FK_AnnouncementVisitors_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementVisitors_Visitors_VisitorID",
                        column: x => x.VisitorID,
                        principalTable: "Visitors",
                        principalColumn: "VisitorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 17, 22, 18, 396, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 17, 22, 18, 396, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "7c3f7d6c-6d1f-4407-8be0-df1b6b8998d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "cbe6041c-0989-4d39-8c27-b7ac16b84350");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "237a9e63-c99f-4e95-a36b-6dd6d66738aa", "AQAAAAEAACcQAAAAEGjjACiDRVoTZ+lRwkbaGBuc+Go5i0F63JcFcoBOKQC3/Ziq9VnTUwrkQOdoIR2yIQ==", "463b0b63-09b8-4a91-8745-f4c50aa338c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61c95912-9a63-4f16-9fc5-9fd1dfcd79db", "AQAAAAEAACcQAAAAEBGTh9W/OdfUOXGoTHpoTPzwWwerlEC3LxDxiOJsbJZK4+xYpKStaa+51QtJlfYSsA==", "f3083a3b-9487-4b87-8dbb-af8eabeb6d83" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 17, 22, 18, 396, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 17, 22, 18, 396, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 17, 22, 18, 396, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 17, 22, 18, 396, DateTimeKind.Local).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 11, 17, 22, 18, 396, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ImageID",
                table: "Announcements",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_UserID",
                table: "Announcements",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementVisitors_ArticleID",
                table: "AnnouncementVisitors",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementVisitors_VisitorID",
                table: "AnnouncementVisitors",
                column: "VisitorID");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoBlogs_Videos_VideoID",
                table: "VideoBlogs",
                column: "VideoID",
                principalTable: "Videos",
                principalColumn: "VideoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoBlogs_Videos_VideoID",
                table: "VideoBlogs");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AnnouncementVisitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Video");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "VideoID");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("1e70f334-8f4b-4813-a023-067931ec7586"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 14, 15, 18, 493, DateTimeKind.Local).AddTicks(3333));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: new Guid("eae365f5-dadf-40b5-ae6e-760e6ad9657d"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 14, 15, 18, 493, DateTimeKind.Local).AddTicks(3328));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "d326b41a-4b90-4ae1-b31c-fba8c60c4a12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "d143fb64-a271-4437-a851-5f32028a0ca2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db46cffd-82de-4e91-8b2f-8843a6d7980d", "AQAAAAEAACcQAAAAEOWKyBMwE4CkoLFzHIw/+8030mSCLra68qCmiRZ6EOZ4fCHsIaZAg0TcYlvrdn1iPw==", "8e97eee5-d800-4a6f-b4b9-939b05cddabd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf57756e-a54b-4121-8593-e9d09c7e41d7", "AQAAAAEAACcQAAAAEMcdTh+nCZTK3eEGWE/Zlqms7jQ0EVbARpPdyygHOjNU1zbDj417GSU5gsPKgpiI4w==", "b0cee982-5e42-4716-b069-e5665def9859" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: new Guid("9019dd67-01e4-4435-a939-88ab3042c44a"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 14, 15, 18, 493, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("01673030-c382-45f8-84dc-a095bf6a7532"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 14, 15, 18, 493, DateTimeKind.Local).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 14, 15, 18, 493, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("20042866-5942-4772-99ec-75b17944bed8"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 14, 15, 18, 493, DateTimeKind.Local).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "NewID",
                keyValue: new Guid("ff859916-d03b-4291-8e99-b4311f2b9d3b"),
                column: "CreatedDate",
                value: new DateTime(2023, 12, 10, 14, 15, 18, 493, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.AddForeignKey(
                name: "FK_VideoBlogs_Video_VideoID",
                table: "VideoBlogs",
                column: "VideoID",
                principalTable: "Video",
                principalColumn: "VideoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
