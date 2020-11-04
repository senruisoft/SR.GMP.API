using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class addrecorddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GMP_ALARM_RECORD_DATA",
                columns: table => new
                {
                    ALARM_RECORD_ID = table.Column<Guid>(nullable: false),
                    MONITOR_ITEM_CODE = table.Column<string>(maxLength: 64, nullable: false),
                    MONITOR_ITEM_VALUE = table.Column<string>(maxLength: 64, nullable: true),
                    IS_ALARM = table.Column<bool>(nullable: false),
                    RULE_TYPE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_ALARM_RECORD_DATA", x => new { x.ALARM_RECORD_ID, x.MONITOR_ITEM_CODE });
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_RECORD_DATA_GMP_ALARM_RECORD_ALARM_RECORD_ID",
                        column: x => x.ALARM_RECORD_ID,
                        principalTable: "GMP_ALARM_RECORD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GMP_ALARM_RECORD_DATA");
        }
    }
}
