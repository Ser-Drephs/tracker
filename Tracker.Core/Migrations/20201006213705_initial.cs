using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    WorkItemId = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WorkItemType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.WorkItemId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTasks",
                columns: table => new
                {
                    WorkTaskId = table.Column<Guid>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: true),
                    TaskId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WorkItemType = table.Column<int>(nullable: false),
                    Activity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTasks", x => x.WorkTaskId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "WorkTasks");
        }
    }
}
