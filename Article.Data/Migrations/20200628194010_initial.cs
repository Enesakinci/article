using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Article.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: true),
                    CreateIpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    LastModifiedIpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "db.Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: true),
                    CreateIpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    LastModifiedIpAddress = table.Column<string>(maxLength: 20, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_db.Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_db.Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_db.Article_CategoryId",
                table: "db.Article",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "db.Article");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
