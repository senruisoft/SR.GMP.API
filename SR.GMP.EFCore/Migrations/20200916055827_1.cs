using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EXT_ID",
                table: "SYS_INST_CENTER",
                maxLength: 128,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SYS_INST_CENTER",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"),
                column: "EXT_ID",
                value: "0010");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EXT_ID",
                table: "SYS_INST_CENTER");
        }
    }
}
