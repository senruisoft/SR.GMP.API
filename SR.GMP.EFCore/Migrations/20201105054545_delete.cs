using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GMP_EVENT_ITEM");

            migrationBuilder.DropTable(
                name: "GMP_MONITOR_ITEM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GMP_EVENT_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITEM_CODE = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ITEM_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SORT_CODE = table.Column<int>(type: "int", nullable: true),
                    STATE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_EVENT_ITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMP_MONITOR_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITEM_CODE = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ITEM_NAME = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SORT_CODE = table.Column<int>(type: "int", nullable: true),
                    STATE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_MONITOR_ITEM", x => x.ID);
                });
        }
    }
}
