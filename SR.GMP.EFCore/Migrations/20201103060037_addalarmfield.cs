using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class addalarmfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TREAT_MEASURE",
                table: "GMP_ALARM_ITEM",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TREAT_PROCESS",
                table: "GMP_ALARM_ITEM",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TREAT_MEASURE",
                table: "GMP_ALARM_ITEM");

            migrationBuilder.DropColumn(
                name: "TREAT_PROCESS",
                table: "GMP_ALARM_ITEM");
        }
    }
}
