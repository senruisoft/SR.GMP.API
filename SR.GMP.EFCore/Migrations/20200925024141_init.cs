using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GMP_ALARM_RECORD",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ALARM_ITEM_ID = table.Column<Guid>(nullable: false),
                    PATIENT_EXT_ID = table.Column<string>(maxLength: 64, nullable: false),
                    PATIENT_NAME = table.Column<string>(maxLength: 64, nullable: true),
                    PATIENT_SEX = table.Column<string>(maxLength: 64, nullable: true),
                    PATIENT_AGE = table.Column<int>(nullable: false),
                    BED_LABEL = table.Column<string>(maxLength: 64, nullable: true),
                    DOCTOR_NAME = table.Column<string>(maxLength: 64, nullable: true),
                    NURSE_NAME = table.Column<string>(maxLength: 64, nullable: true),
                    ALARM_ITEM_NAME = table.Column<string>(maxLength: 128, nullable: false),
                    PRIORITY = table.Column<int>(nullable: false),
                    ALARM_INFO = table.Column<string>(maxLength: 128, nullable: true),
                    DATA_RECORD_TIME = table.Column<DateTime>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    HANDLE_TIME = table.Column<DateTime>(nullable: true),
                    CREATE_AT = table.Column<DateTime>(nullable: false),
                    CENT_ID = table.Column<Guid>(nullable: false),
                    CLASS_ID = table.Column<string>(nullable: true),
                    CLASS_NAME = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_ALARM_RECORD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GMP_EVENT_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITEM_NAME = table.Column<string>(maxLength: 64, nullable: false),
                    ITEM_CODE = table.Column<string>(maxLength: 64, nullable: false),
                    SORT_CODE = table.Column<int>(nullable: true),
                    STATE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_MONITOR_ITEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SYS_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    ACCOUNT = table.Column<string>(maxLength: 128, nullable: false),
                    PWD = table.Column<string>(maxLength: 128, nullable: false),
                    JOB_NO = table.Column<string>(maxLength: 32, nullable: true),
                    NAME = table.Column<string>(maxLength: 128, nullable: false),
                    GENDER = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_USER_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYS_USER_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYS_DICT_CATEGORY",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    P_ID = table.Column<Guid>(nullable: true),
                    CODE = table.Column<string>(maxLength: 64, nullable: false),
                    NAME = table.Column<string>(maxLength: 64, nullable: false),
                    SORT_CODE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_DICT_CATEGORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_DICT_CATEGORY_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYS_DICT_CATEGORY_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYS_INST",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    CODE = table.Column<string>(maxLength: 50, nullable: false),
                    NAME = table.Column<string>(maxLength: 50, nullable: false),
                    ADDRESS = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_INST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_INST_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYS_INST_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYS_DICT_ITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    CATEGORY_ID = table.Column<Guid>(nullable: false),
                    P_ID = table.Column<Guid>(nullable: true),
                    CODE = table.Column<string>(maxLength: 64, nullable: false),
                    NAME = table.Column<string>(maxLength: 64, nullable: false),
                    PY = table.Column<string>(maxLength: 64, nullable: true),
                    SORT_CODE = table.Column<int>(nullable: false),
                    DESC = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_DICT_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_DICT_ITEM_SYS_DICT_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "SYS_DICT_CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SYS_DICT_ITEM_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYS_DICT_ITEM_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYS_INST_CENTER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    INST_ID = table.Column<Guid>(nullable: false),
                    CODE = table.Column<string>(maxLength: 128, nullable: false),
                    NAME = table.Column<string>(maxLength: 128, nullable: false),
                    SORT_CODE = table.Column<string>(maxLength: 128, nullable: true),
                    PY = table.Column<string>(maxLength: 50, nullable: true),
                    CENT_DESC = table.Column<string>(maxLength: 256, nullable: true),
                    TYPE_CODE = table.Column<int>(nullable: false),
                    EXT_ID = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_INST_CENTER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_INST_CENTER_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SYS_INST_CENTER_SYS_INST_INST_ID",
                        column: x => x.INST_ID,
                        principalTable: "SYS_INST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SYS_INST_CENTER_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GMP_ALARM_ITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    ITEM_NAME = table.Column<string>(maxLength: 128, nullable: false),
                    PRIORITY = table.Column<int>(nullable: false),
                    CENT_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_ALARM_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_ITEM_SYS_INST_CENTER_CENT_ID",
                        column: x => x.CENT_ID,
                        principalTable: "SYS_INST_CENTER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_ITEM_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_ITEM_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GMP_ALARM_ITEM_RULE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    ITEM_ID = table.Column<Guid>(nullable: false),
                    RULE_TYPE = table.Column<int>(nullable: false),
                    MONITOR_ITEM_CODE = table.Column<string>(maxLength: 64, nullable: true),
                    EVENT_ITEM_CODE = table.Column<string>(maxLength: 64, nullable: true),
                    LOGIC_TYPE = table.Column<int>(nullable: false),
                    SORT_NUM = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_ALARM_ITEM_RULE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_ITEM_RULE_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_ITEM_RULE_GMP_ALARM_ITEM_ITEM_ID",
                        column: x => x.ITEM_ID,
                        principalTable: "GMP_ALARM_ITEM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_ITEM_RULE_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GMP_ALARM_RULE_CONFIG",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    STATE = table.Column<int>(nullable: false),
                    CREATE_AT = table.Column<DateTime>(nullable: true),
                    CREATOR_ID = table.Column<Guid>(nullable: true),
                    MODIFY_AT = table.Column<DateTime>(nullable: true),
                    MODIFIER_ID = table.Column<Guid>(nullable: true),
                    RULE_ID = table.Column<Guid>(nullable: false),
                    MAX_VALUE = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    IS_CONTAINMAX = table.Column<bool>(nullable: false),
                    MIN_VALUE = table.Column<decimal>(type: "decimal(8, 2)", nullable: true),
                    IS_CONTAINMIN = table.Column<bool>(nullable: false),
                    IS_DIFFVALUE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GMP_ALARM_RULE_CONFIG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_RULE_CONFIG_SYS_USER_CREATOR_ID",
                        column: x => x.CREATOR_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_RULE_CONFIG_SYS_USER_MODIFIER_ID",
                        column: x => x.MODIFIER_ID,
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GMP_ALARM_RULE_CONFIG_GMP_ALARM_ITEM_RULE_RULE_ID",
                        column: x => x.RULE_ID,
                        principalTable: "GMP_ALARM_ITEM_RULE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_ITEM_CENT_ID",
                table: "GMP_ALARM_ITEM",
                column: "CENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_ITEM_CREATOR_ID",
                table: "GMP_ALARM_ITEM",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_ITEM_MODIFIER_ID",
                table: "GMP_ALARM_ITEM",
                column: "MODIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_ITEM_RULE_CREATOR_ID",
                table: "GMP_ALARM_ITEM_RULE",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_ITEM_RULE_ITEM_ID",
                table: "GMP_ALARM_ITEM_RULE",
                column: "ITEM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_ITEM_RULE_MODIFIER_ID",
                table: "GMP_ALARM_ITEM_RULE",
                column: "MODIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_RULE_CONFIG_CREATOR_ID",
                table: "GMP_ALARM_RULE_CONFIG",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_RULE_CONFIG_MODIFIER_ID",
                table: "GMP_ALARM_RULE_CONFIG",
                column: "MODIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GMP_ALARM_RULE_CONFIG_RULE_ID",
                table: "GMP_ALARM_RULE_CONFIG",
                column: "RULE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_DICT_CATEGORY_CREATOR_ID",
                table: "SYS_DICT_CATEGORY",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_DICT_CATEGORY_MODIFIER_ID",
                table: "SYS_DICT_CATEGORY",
                column: "MODIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_DICT_ITEM_CATEGORY_ID",
                table: "SYS_DICT_ITEM",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_DICT_ITEM_CREATOR_ID",
                table: "SYS_DICT_ITEM",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_DICT_ITEM_MODIFIER_ID",
                table: "SYS_DICT_ITEM",
                column: "MODIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_INST_CREATOR_ID",
                table: "SYS_INST",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_INST_MODIFIER_ID",
                table: "SYS_INST",
                column: "MODIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_INST_CENTER_CREATOR_ID",
                table: "SYS_INST_CENTER",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_INST_CENTER_INST_ID",
                table: "SYS_INST_CENTER",
                column: "INST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_INST_CENTER_MODIFIER_ID",
                table: "SYS_INST_CENTER",
                column: "MODIFIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_CREATOR_ID",
                table: "SYS_USER",
                column: "CREATOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_MODIFIER_ID",
                table: "SYS_USER",
                column: "MODIFIER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GMP_ALARM_RECORD");

            migrationBuilder.DropTable(
                name: "GMP_ALARM_RULE_CONFIG");

            migrationBuilder.DropTable(
                name: "GMP_EVENT_ITEM");

            migrationBuilder.DropTable(
                name: "GMP_MONITOR_ITEM");

            migrationBuilder.DropTable(
                name: "SYS_DICT_ITEM");

            migrationBuilder.DropTable(
                name: "GMP_ALARM_ITEM_RULE");

            migrationBuilder.DropTable(
                name: "SYS_DICT_CATEGORY");

            migrationBuilder.DropTable(
                name: "GMP_ALARM_ITEM");

            migrationBuilder.DropTable(
                name: "SYS_INST_CENTER");

            migrationBuilder.DropTable(
                name: "SYS_INST");

            migrationBuilder.DropTable(
                name: "SYS_USER");
        }
    }
}
