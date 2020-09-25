using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreatmenCountView",
                columns: table => new
                {
                    TotalCount = table.Column<int>(nullable: false),
                    ManCount = table.Column<int>(nullable: false),
                    WomanCount = table.Column<int>(nullable: false),
                    NegativeCount = table.Column<int>(nullable: false),
                    PositiveCount = table.Column<int>(nullable: false),
                    CENT_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TreatmentStatsView",
                columns: table => new
                {
                    Month = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CENT_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_ITEM",
                columns: new[] { "ID", "CENT_ID", "CREATE_AT", "CREATOR_ID", "ITEM_NAME", "MODIFIER_ID", "MODIFY_AT", "PRIORITY", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"), new Guid("b2241873-49ba-4672-92e9-a3825a0e8363"), null, null, "报警项目2", null, null, 2, 1 });

            migrationBuilder.Sql("");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmenCountView");

            migrationBuilder.DropTable(
                name: "TreatmentStatsView");

            migrationBuilder.DeleteData(
                table: "GMP_ALARM_ITEM",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"));
        }
    }
}
