using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class additemname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MONITOR_ITEM_NAME",
                table: "GMP_ALARM_RECORD_DATA",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MONITOR_ITEM_NAME",
                table: "GMP_ALARM_RECORD_DATA");
        }
    }
}
