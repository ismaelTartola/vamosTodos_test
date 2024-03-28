using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VamosTodos_Test.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectAggregateRoot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProjectDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAggregateRoot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAggregateRoot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAggregateRoot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BugEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BugDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BugCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BugEntity_ProjectAggregateRoot_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectAggregateRoot",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BugEntity_UserAggregateRoot_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAggregateRoot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BugEntity_ProjectId",
                table: "BugEntity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BugEntity_UserId",
                table: "BugEntity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugEntity");

            migrationBuilder.DropTable(
                name: "ProjectAggregateRoot");

            migrationBuilder.DropTable(
                name: "UserAggregateRoot");
        }
    }
}
