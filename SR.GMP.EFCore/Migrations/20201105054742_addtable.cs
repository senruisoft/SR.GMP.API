using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class addtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GMP_EVENT_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ITEM_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    ITEM_CODE = table.Column<string>(maxLength: 64, nullable: false),
                    SORT_CODE = table.Column<int>(nullable: true),
                    STATE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_EVENT_ITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMP_MONITOR_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ITEM_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    ITEM_CODE = table.Column<string>(maxLength: 64, nullable: false),
                    SORT_CODE = table.Column<int>(nullable: true),
                    STATE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_MONITOR_ITEM", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GMP_EVENT_ITEM");

            migrationBuilder.DropTable(
                name: "GMP_MONITOR_ITEM");
        }
    }
}
