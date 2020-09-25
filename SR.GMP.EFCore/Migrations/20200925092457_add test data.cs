using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class addtestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GMP_EVENT_ITEM",
                columns: new[] { "ID", "ITEM_CODE", "ITEM_NAME", "SORT_CODE", "STATE" },
                values: new object[] { 1, "高血压", "高血压", null, 1 });

            migrationBuilder.InsertData(
                table: "GMP_MONITOR_ITEM",
                columns: new[] { "ID", "ITEM_CODE", "ITEM_NAME", "SORT_CODE", "STATE" },
                values: new object[] { 1, "SYSTOLIC_BLOOD_PRESSURE", "舒张压", null, 1 });

            migrationBuilder.InsertData(
                table: "SYS_INST",
                columns: new[] { "ID", "ADDRESS", "CODE", "CREATE_AT", "CREATOR_ID", "MODIFIER_ID", "MODIFY_AT", "NAME", "STATE" },
                values: new object[] { new Guid("a2241873-49ba-4672-92e9-a3825a0e8362"), null, "0010", null, null, null, null, "仁济医院", 1 });

            migrationBuilder.InsertData(
                table: "SYS_USER",
                columns: new[] { "ID", "ACCOUNT", "CREATE_AT", "CREATOR_ID", "GENDER", "JOB_NO", "MODIFIER_ID", "MODIFY_AT", "NAME", "PWD", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), "admin", null, null, 0, null, null, null, "admin", "123456", 1 });

            migrationBuilder.InsertData(
                table: "SYS_INST_CENTER",
                columns: new[] { "ID", "CENT_DESC", "CODE", "CREATE_AT", "CREATOR_ID", "EXT_ID", "INST_ID", "MODIFIER_ID", "MODIFY_AT", "NAME", "PY", "SORT_CODE", "STATE", "TYPE_CODE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"), null, "0010", null, null, "cd20937a-24b2-455c-91c9-0df498c581b2", new Guid("a2241873-49ba-4672-92e9-a3825a0e8362"), null, null, "仁济东院", null, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "SYS_INST_CENTER",
                columns: new[] { "ID", "CENT_DESC", "CODE", "CREATE_AT", "CREATOR_ID", "EXT_ID", "INST_ID", "MODIFIER_ID", "MODIFY_AT", "NAME", "PY", "SORT_CODE", "STATE", "TYPE_CODE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8363"), null, "0010", null, null, "0010", new Guid("a2241873-49ba-4672-92e9-a3825a0e8362"), null, null, "仁济西院", null, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_ITEM",
                columns: new[] { "ID", "CENT_ID", "CREATE_AT", "CREATOR_ID", "ITEM_NAME", "MODIFIER_ID", "MODIFY_AT", "PRIORITY", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"), null, null, "报警项目1", null, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_ITEM",
                columns: new[] { "ID", "CENT_ID", "CREATE_AT", "CREATOR_ID", "ITEM_NAME", "MODIFIER_ID", "MODIFY_AT", "PRIORITY", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"), new Guid("b2241873-49ba-4672-92e9-a3825a0e8363"), null, null, "报警项目2", null, null, 2, 1 });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_ITEM_RULE",
                columns: new[] { "ID", "CREATE_AT", "CREATOR_ID", "EVENT_ITEM_CODE", "ITEM_ID", "LOGIC_TYPE", "MODIFIER_ID", "MODIFY_AT", "MONITOR_ITEM_CODE", "RULE_TYPE", "SORT_NUM", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), null, null, null, new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), 0, null, null, "VENOUS_PRESSURE", 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_ITEM_RULE",
                columns: new[] { "ID", "CREATE_AT", "CREATOR_ID", "EVENT_ITEM_CODE", "ITEM_ID", "LOGIC_TYPE", "MODIFIER_ID", "MODIFY_AT", "MONITOR_ITEM_CODE", "RULE_TYPE", "SORT_NUM", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"), null, null, null, new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), 0, null, null, "ARTERIAL_PRESSURE", 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_RULE_CONFIG",
                columns: new[] { "ID", "CREATE_AT", "CREATOR_ID", "IS_CONTAINMAX", "IS_CONTAINMIN", "IS_DIFFVALUE", "MAX_VALUE", "MIN_VALUE", "MODIFIER_ID", "MODIFY_AT", "RULE_ID", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), null, null, false, false, false, 120m, 100m, null, null, new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), 1 });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_RULE_CONFIG",
                columns: new[] { "ID", "CREATE_AT", "CREATOR_ID", "IS_CONTAINMAX", "IS_CONTAINMIN", "IS_DIFFVALUE", "MAX_VALUE", "MIN_VALUE", "MODIFIER_ID", "MODIFY_AT", "RULE_ID", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8314"), null, null, false, false, false, 90m, null, null, null, new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"), 1 });

            migrationBuilder.InsertData(
                table: "GMP_ALARM_RULE_CONFIG",
                columns: new[] { "ID", "CREATE_AT", "CREATOR_ID", "IS_CONTAINMAX", "IS_CONTAINMIN", "IS_DIFFVALUE", "MAX_VALUE", "MIN_VALUE", "MODIFIER_ID", "MODIFY_AT", "RULE_ID", "STATE" },
                values: new object[] { new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"), null, null, false, false, false, null, 100m, null, null, new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GMP_ALARM_ITEM",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"));

            migrationBuilder.DeleteData(
                table: "GMP_ALARM_RULE_CONFIG",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"));

            migrationBuilder.DeleteData(
                table: "GMP_ALARM_RULE_CONFIG",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"));

            migrationBuilder.DeleteData(
                table: "GMP_ALARM_RULE_CONFIG",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8314"));

            migrationBuilder.DeleteData(
                table: "GMP_EVENT_ITEM",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GMP_MONITOR_ITEM",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SYS_USER",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"));

            migrationBuilder.DeleteData(
                table: "GMP_ALARM_ITEM_RULE",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"));

            migrationBuilder.DeleteData(
                table: "GMP_ALARM_ITEM_RULE",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8313"));

            migrationBuilder.DeleteData(
                table: "SYS_INST_CENTER",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8363"));

            migrationBuilder.DeleteData(
                table: "GMP_ALARM_ITEM",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8312"));

            migrationBuilder.DeleteData(
                table: "SYS_INST_CENTER",
                keyColumn: "ID",
                keyValue: new Guid("b2241873-49ba-4672-92e9-a3825a0e8362"));

            migrationBuilder.DeleteData(
                table: "SYS_INST",
                keyColumn: "ID",
                keyValue: new Guid("a2241873-49ba-4672-92e9-a3825a0e8362"));
        }
    }
}
