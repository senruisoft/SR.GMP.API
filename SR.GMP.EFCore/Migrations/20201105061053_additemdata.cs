using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class additemdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GMP_MONITOR_ITEM",
                columns: new[] { "ID", "ITEM_CODE", "ITEM_NAME", "SORT_CODE", "STATE" },
                values: new object[,]
                {
                    { 1, "VENOUS_PRESSURE", "静脉压", null, 1 },
                    { 2, "ARTERIAL_PRESSURE", "动脉压", null, 1 },
                    { 3, "TRANS_PRESSURE", "跨膜压", null, 1 },
                    { 4, "BLOOD_FLOW", "血流量", null, 1 },
                    { 5, "BODY_TEMPERATURE", "体温", null, 1 },
                    { 6, "SYSTOLIC_BLOOD_PRESSURE", "收缩压", null, 1 },
                    { 7, "STRETCH_PRESSURE", "舒张压", null, 1 },
                    { 8, "HEART_RATE", "心率", null, 1 },
                    { 9, "ELECTRICAL_CONDUCTIVITY", "电导率", null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 9);
        }
    }
}
