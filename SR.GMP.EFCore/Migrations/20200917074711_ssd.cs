using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class ssd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CENT_CODE",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.AddColumn<Guid>(
                name: "CENT_ID",
                table: "GMP_ALARM_RECORD",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CLASS_ID",
                table: "GMP_ALARM_RECORD",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CENT_ID",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.DropColumn(
                name: "CLASS_ID",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.AddColumn<string>(
                name: "CENT_CODE",
                table: "GMP_ALARM_RECORD",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
