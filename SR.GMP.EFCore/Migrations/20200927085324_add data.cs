using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GMP_ALARM_ITEM_RULE",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                column: "ITEM_ID",
                value: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"));

            migrationBuilder.UpdateData(
                table: "GMP_ALARM_ITEM_RULE",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"),
                column: "ITEM_ID",
                value: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GMP_ALARM_ITEM_RULE",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"),
                column: "ITEM_ID",
                value: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"));

            migrationBuilder.UpdateData(
                table: "GMP_ALARM_ITEM_RULE",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"),
                column: "ITEM_ID",
                value: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"));
        }
    }
}
