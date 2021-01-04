using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace SR.GMP.EFCore.Migrations
{
    public partial class init : Migration
    {
        private readonly IConfiguration _configuration;
        public init() 
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

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

            string TDMS_DataBaseName = _configuration["TDMS+:DataBase"];
            migrationBuilder.Sql(@$"
                create view [dbo].[view_BaseCountInfo]
                as
                select CENT_ID, SUM(PatientCount) as PatientCount, SUM(NurseCount) as NurseCount, SUM(DoctorCount) as DoctorCount,SUM(BedCount) as BedCount
                from  
                (SELECT USER_CENTER.CENTER_ID as CENT_ID,
                0 as PatientCount,0 as BedCount  ,count(*) as DoctorCount ,0 as NurseCount 
                FROM  {TDMS_DataBaseName}.dbo.SYS_USER as sys_user
                  join {TDMS_DataBaseName}.dbo.SYS_USER_CENTER as USER_CENTER  on  sys_user.ID = USER_CENTER.USER_ID
                  join  {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on USER_CENTER.CENTER_ID  = center.id
                WHERE sys_user.STATE = 1 and sys_user.TYPE_CODE = '01' and center.STATE = 1
                GROUP BY USER_CENTER.CENTER_ID

                union all

                SELECT USER_CENTER.CENTER_ID as CENT_ID,
                0 as PatientCount,0 as BedCount  ,0 as DoctorCount ,count(*) as NurseCount 
                FROM  {TDMS_DataBaseName}.dbo.SYS_USER as sys_user
                  join {TDMS_DataBaseName}.dbo.SYS_USER_CENTER as USER_CENTER  on  sys_user.ID = USER_CENTER.USER_ID
                  join  {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on USER_CENTER.CENTER_ID  = center.id
                WHERE sys_user.STATE = 1 and sys_user.TYPE_CODE = '02' and center.STATE = 1
                GROUP BY USER_CENTER.CENTER_ID

                union all

                select  CENT_ID ,
                count(*) as PatientCount ,0 as BedCount  ,0 as DoctorCount ,0 as NurseCount  
                 from  {TDMS_DataBaseName}.dbo.HD_PATIENT  patient
                 join  {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID  = center.id
                 where patient.STATE = 1 and center.STATE = 1
                 GROUP BY CENT_ID

                 union all

                 select CENT_ID,
                0 as PatientCount ,count(*) as BedCount ,0 as DoctorCount ,0 as NurseCount  
                  from  {TDMS_DataBaseName}.dbo.HD_BED bed
                  join  {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on bed.CENT_ID  = center.id
                   where bed.STATE = 1 and center.STATE = 1
                group  by CENT_ID ) a
                group by a.CENT_ID
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_DeviceTreatDataInfo]
                as
                select TREATMENT.PATIENT_ID, TREATMENT.ID as TREATMENT_ID, TREATMENT.CENT_ID, TREATMENT.TRAETMENT_DATE,  device_data.RECORD_TIME, device_data.DEFAULT_TREAT_TIME, IS_UP, IS_DOWN, ELAPSEDTIME, device_data.UF
                from {TDMS_DataBaseName}.[dbo].[HD_PATIENT] patient
                join {TDMS_DataBaseName}.[dbo].HD_TREATMENT TREATMENT
                on patient.ID = TREATMENT.PATIENT_ID
                join {TDMS_DataBaseName}.[dbo].HD_DEVICE_TREAT_DATA device_data
                on TREATMENT.ID = device_data.TREATMENT_ID
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_EquipmentCountInfo]
                as
                SELECT equipment.CENT_ID, dict.EquipmentName, dict.EquipmentCode, count(*) EquipmentCount
                FROM  {TDMS_DataBaseName}.[dbo].HD_EQUIPMENT  equipment
                JOIN {TDMS_DataBaseName}.[dbo].SYS_INST_CENTER center  ON  equipment.CENT_ID = center.id
                join (select item.NAME EquipmentName, item.CODE EquipmentCode from
                {TDMS_DataBaseName}.[dbo].[SYS_DICT_CATEGORY] category, {TDMS_DataBaseName}.[dbo].[SYS_DICT_ITEM] item
                where category.CODE = 'CV0004_0008_0001' and category.STATE = 1 and item.CATEGORY_ID = category.ID and item.STATE = 1) dict
                on dict.EquipmentCode = equipment.MODEL_CODE
                where equipment.STATE = 1 and center.STATE = 1
                group by equipment.CENT_ID, dict.EquipmentCode, dict.EquipmentName
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_HD_EVENT]
                as
                select patient.id as PATIENT_ID,  patient.PATIENT_NAME AS PATIENT_NAME , 
                patient.CENT_ID as CENT_ID,
                 case patient.patient_sex when '04' then N'未知的性别' when '01' then N'男' when '02' then N'女' when '03' then N'未说明的性别' else N'' end patient_sex  ,
                (SELECT CASE WHEN  MONTH(patient.patient_birthday)>MONTH(getdate())
                OR (MONTH(patient.patient_birthday)=MONTH(getdate())
                AND DAY(patient.patient_birthday)>DAY(getdate()))
                THEN datediff(yy,patient.patient_birthday,getdate())-1 
                else datediff(yy,patient.patient_birthday,getdate()) end patient_age ) as PATIENT_AGE, 
                sche.BED_LABEL as BED_LABEL,
                treat.DOCTOR_USER as DOCTOR_NAME,
                treat.UP_USER  as NURSE_NAME,
                sche.SCHEDULING_CLASS as CLASS_ID,
                sche_class.NAME as CLASS_NAME,
                dia_event.EVENT_NAME,
                dia_event.EVENT_NAME AS EVENT_CODE  ,
                dia_event.RECORD_TIME,
                dia_event.CREATE_AT 
                from  {TDMS_DataBaseName}.dbo.HD_PATIENT  patient
                join  {TDMS_DataBaseName}.dbo.HD_SCHEDULING sche   on  patient.id = sche.PATIENT_ID
                join {TDMS_DataBaseName}.dbo.HD_SCHEDULING_CLASS sche_class on sche_class.ID = sche.SCHEDULING_CLASS
                join   {TDMS_DataBaseName}.dbo.HD_TREATMENT treat on  sche.ID = treat.SCHEDULING_ID
                join  {TDMS_DataBaseName}.dbo.HD_DIALYSIS_EVENT dia_event on treat.ID = dia_event.TREATMENT_ID
                where [EVENT_RESULT] is null
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_HD_MONITORING]
                as
                SELECT  b.CENT_ID AS CENT_ID, f.SCHEDULING_CLASS as CLASS_ID, g.NAME as CLASS_NAME, b.ID AS PATIENT_ID, b.PATIENT_NAME, 
                   CASE b.patient_sex WHEN '04' THEN N'未知的性别' WHEN '01' THEN N'男' WHEN '02' THEN N'女' WHEN '03' THEN N'未说明的性别'
                    ELSE N'' END AS patient_sex,
                       (SELECT  CASE WHEN MONTH(b.patient_birthday) > MONTH(getdate()) OR
                                           (MONTH(b.patient_birthday) = MONTH(getdate()) AND DAY(b.patient_birthday) > DAY(getdate())) 
                                           THEN datediff(yy, b.patient_birthday, getdate()) - 1 ELSE datediff(yy, b.patient_birthday, getdate()) 
                                           END AS patient_age) AS PATIENT_AGE, e.BED_LABEL, e.DOCTOR_USER AS DOCTOR_NAME, 
                   e.UP_USER AS NURSE_NAME, a.RECORD_TIME, a.CREATE_AT, CONVERT(decimal(8, 2), a.VENOUS_PRESSURE) 
                   AS VENOUS_PRESSURE, CONVERT(decimal(8, 2), a.ARTERIAL_PRESSURE) AS ARTERIAL_PRESSURE, 
                   CONVERT(decimal(8, 2), a.TRANS_PRESSURE) AS TRANS_PRESSURE, CONVERT(decimal(8, 2), a.BLOOD_FLOW) 
                   AS BLOOD_FLOW, CONVERT(decimal(8, 2), a.RP_FLUID_FLOW) AS RP_FLUID_FLOW, CONVERT(decimal(8, 2), a.UF_RATE) 
                   AS UF_RATE, CONVERT(decimal(8, 2), a.UF) AS UF, CONVERT(decimal(8, 2), a.BREATHE) AS BREATHE, 
                   CONVERT(decimal(8, 2), a.DIALYSATE_TEMPERATURE) AS DIALYSATE_TEMPERATURE, CONVERT(decimal(8, 2), 
                   a.BODY_TEMPERATURE) AS BODY_TEMPERATURE, CONVERT(decimal(8, 2), a.SYSTOLIC_BLOOD_PRESSURE) 
                   AS SYSTOLIC_BLOOD_PRESSURE, CONVERT(decimal(8, 2), a.STRETCH_PRESSURE) AS STRETCH_PRESSURE, 
                   CONVERT(decimal(8, 2), a.HEART_RATE) AS HEART_RATE, CONVERT(decimal(8, 2), a.ELECTRICAL_CONDUCTIVITY) 
                   AS ELECTRICAL_CONDUCTIVITY, CONVERT(decimal(8, 2), a.KTV) AS ktv
                FROM    {TDMS_DataBaseName}.dbo.HD_PATIENT AS b  JOIN
                   {TDMS_DataBaseName}.dbo.HD_TREATMENT AS e ON e.PATIENT_ID = b.ID INNER JOIN
                   {TDMS_DataBaseName}.dbo.HD_DEVICE_TREAT_DATA AS a ON a.TREATMENT_ID = e.ID INNER JOIN
				   {TDMS_DataBaseName}.dbo.HD_SCHEDULING as f on e.SCHEDULING_ID = f.ID join
				   {TDMS_DataBaseName}.dbo.HD_SCHEDULING_CLASS as g on g.ID = f.SCHEDULING_CLASS
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_MonitorDataInfo]
                as
                select TREATMENT.PATIENT_ID, TREATMENT.ID as TREATMENT_ID, TREATMENT.CENT_ID, TREATMENT.TRAETMENT_DATE, monitor.RECORD_TIME
                 ,[VENOUS_PRESSURE]
                      ,[ARTERIAL_PRESSURE]
                      ,[TRANS_PRESSURE]
                      ,monitor.[BLOOD_FLOW]
                      ,[RP_FLUID_FLOW]
                      ,[UF_RATE]
                      ,[UF]
                      ,[BREATHE]
                      ,monitor.[DIALYSATE_TEMPERATURE]
                      ,[BODY_TEMPERATURE]
                      ,[SYSTOLIC_BLOOD_PRESSURE]
                      ,[STRETCH_PRESSURE]
                      ,[HEART_RATE]
                      ,[ELECTRICAL_CONDUCTIVITY]
	                   ,monitor.[DIALYSATE_FLOW]
                      ,[ATICOAGULANT_ADD]
                      ,[SIGNS_STATUS]
                      ,[EVENT_BIREF]
                      ,monitor.[KTV]
                from {TDMS_DataBaseName}.[dbo].[HD_PATIENT] patient
                join {TDMS_DataBaseName}.[dbo].HD_TREATMENT TREATMENT
                on patient.ID = TREATMENT.PATIENT_ID
                join {TDMS_DataBaseName}.[dbo].[HD_MONITORING_RECORD] monitor
                on monitor.TREATMENT_ID = TREATMENT.ID
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_OnlineTreatmentStatsInfo]
                as 
                SELECT  sche.CENT_ID, sche.SCHEDULING_CLASS AS ClassID, sche_class.NAME AS ClassName, sche_class.SORTS AS SortNum, 
                                   COUNT(sche.ID) AS TotalCount, COUNT(treat.ID) AS TreatingCount,  COUNT(treat_c.ID) AS CompleteCount
                FROM      {TDMS_DataBaseName}.dbo.HD_SCHEDULING AS sche  JOIN
                                   {TDMS_DataBaseName}.dbo.SYS_INST_CENTER AS center ON sche.CENT_ID = center.ID  JOIN
                                   {TDMS_DataBaseName}.dbo.HD_SCHEDULING_CLASS AS sche_class ON sche.SCHEDULING_CLASS = sche_class.ID AND 
                                   sche.CENT_ID = center.ID LEFT  JOIN
                                   {TDMS_DataBaseName}.dbo.HD_TREATMENT AS treat ON treat.SCHEDULING_ID = sche.ID  and treat.DOWN_USER_ID is null

				                   LEFT  JOIN
                                   {TDMS_DataBaseName}.dbo.HD_TREATMENT AS treat_c ON treat_c.SCHEDULING_ID = sche.ID and treat_c.DOWN_USER_ID is not null
                where sche.STATE = 1 and center.STATE = 1 and [TREAT_DATE] = CONVERT(varchar,GETDATE(),23) 
                group by sche.CENT_ID, sche.SCHEDULING_CLASS, sche_class.NAME, sche_class.SORTS

            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_PatientBasicTreatInfo]
                as
                select TREATMENT.PATIENT_ID,TREATMENT.ID as TREATMENT_ID, TREATMENT.CENT_ID,TREATMENT.TRAETMENT_DATE,
                TREATMENT.TREATMENT_MODE, TREATMENT.DIALYZER_NAME, TREATMENT.ATICOAGULANT_NAME, TREATMENT.FIRST_DOSE, TREATMENT.KEEP_DOSE, TREATMENT.DIALYSATE_NAME,
                TREATMENT.BEFORE_WEIGHT, TREATMENT.DRY_WEIGHT, TREATMENT.BEFORE_SBP, TREATMENT.BEFORE_SP,
                TREATMENT.BEFORE_HR, TREATMENT.BEFORE_TEMPERATURE, TREATMENT.PRESET_UF, TREATMENT.ACTUAL_UF, TREATMENT.DEFAULT_TREAT_TIME,
                TREATMENT.AFTER_WEIGHT,  TREATMENT.AFTER_SBP, TREATMENT.AFTER_SP,
                TREATMENT.AFTER_HR, TREATMENT.AFTER_TEMPERATURE
                from {TDMS_DataBaseName}.[dbo].[HD_PATIENT] patient
                join {TDMS_DataBaseName}.[dbo].HD_TREATMENT TREATMENT
                on patient.ID = TREATMENT.PATIENT_ID
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_PatientGeneralInfo]
                 as
                SELECT patient.ID as PATIENT_ID, patient.CENT_ID, patient.PATIENT_NAME, patient.DIALYSIS_ID, treatment.BED_LABEL , sche_class.NAME as CLASS_NAME,

                case patient.patient_sex when '04' then N'未知的性别' when '01' then N'男' when '02' then N'女' when '03' then N'未说明的性别' else N'' end PATIENT_SEX,
                (SELECT CASE WHEN  MONTH(patient.patient_birthday)>MONTH(getdate())
                OR (MONTH(patient.patient_birthday)=MONTH(getdate())
                AND DAY(patient.patient_birthday)>DAY(getdate()))
                THEN datediff(yy,patient.patient_birthday,getdate())-1 
                else datediff(yy,patient.patient_birthday,getdate()) end patient_age ) as PATIENT_AGE,

                case  when patient.HEPATITISB_STATUS='02' OR  patient.HCV_STATUS='02' OR patient.HIV_STATUS='02' OR patient.SYPHILIS_STATUS='02' then N'阳性患者' 
                when patient.HEPATITISB_STATUS='01' and  patient.HCV_STATUS='01' and patient.HIV_STATUS='01' and patient.SYPHILIS_STATUS='01' then N'阴性患者'
                else '未检患者' end PATIENT_TYPE,

                patient.TREATMENT_START_DATE ,

                case patient.MEDICAL_TYPE when '01' then N'医保' when '02' then N'自费' else N'' end MEDICAL_TYPE,
                 treatment.DOCTOR_USER as DOCTOR_NAME,
                 treatment.UP_USER as NURSE_NAME,
                 treatment.TRAETMENT_DATE

                  FROM {TDMS_DataBaseName}.[dbo].[HD_PATIENT] patient
                  join  {TDMS_DataBaseName}.[dbo].HD_TREATMENT  treatment
                  on patient.ID = treatment.PATIENT_ID
                  join {TDMS_DataBaseName}.[dbo].HD_SCHEDULING sche
                  on sche.ID = treatment.SCHEDULING_ID
                  join {TDMS_DataBaseName}.[dbo].HD_SCHEDULING_CLASS sche_class
                  on sche.SCHEDULING_CLASS = sche_class.ID
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_TreatOrderInfo]
                 as 
                select TREATMENT.PATIENT_ID, TREATMENT.ID as TREATMENT_ID, TREATMENT.CENT_ID, TREATMENT.TRAETMENT_DATE, 
	                treat_order.ORDER_NAME, 
                 cast (  case	treat_order.ORDER_STATE when '07' then 1 else 0  end  as bit) IS_EXECED ,
  
	                treat_order.SUBMIT_USER, treat_order.EXEC_USER, dict.NAME as EXEC_METHOD
 
                from {TDMS_DataBaseName}.[dbo].[HD_PATIENT] patient
                join {TDMS_DataBaseName}.[dbo].HD_TREATMENT TREATMENT
                on patient.ID = TREATMENT.PATIENT_ID
                join {TDMS_DataBaseName}.[dbo].[HD_TREATMENT_ORDER] treat_order
                on treat_order.TREATMENT_ID = TREATMENT.ID
                left join (select  dict.NAME,dict.CODE  from
                {TDMS_DataBaseName}.[dbo].[SYS_DICT_CATEGORY] category
                join {TDMS_DataBaseName}.[dbo].[SYS_DICT_ITEM] dict
                on category.ID = dict.CATEGORY_ID
                where category.CODE = 'CV0002_0020') dict
                on treat_order.EXEC_METHOD = dict.CODE
                where treat_order.STATE = 1
            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_YearNewPatientCountInfo]
                 as
                select a.CENT_ID, sum(a.TotalCount) TotalCount,  sum(a.ManCount)  ManCount,sum(a.WomanCount) WomanCount, sum(a.NegativeCount) NegativeCount, sum(a.PositiveCount) PositiveCount
                from
                (select center.ID CENT_ID, count(patient.ID) TotalCount,  0  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1 and DATENAME(YEAR,patient.CREATE_AT) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount,  count(patient.ID)  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1 and DATENAME(YEAR,patient.CREATE_AT) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1 and patient.PATIENT_SEX = '01'
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount, 0  ManCount, count(patient.ID) WomanCount, 0 NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1 and DATENAME(YEAR,patient.CREATE_AT) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1 and patient.PATIENT_SEX = '02'
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount, 0  ManCount, 0 WomanCount, 0 NegativeCount, count(patient.ID) PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1 and DATENAME(YEAR,patient.CREATE_AT) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1 
                and (patient.HEPATITISB_STATUS='02' OR  patient.HCV_STATUS='02' OR patient.HIV_STATUS='02' OR patient.SYPHILIS_STATUS='02') 
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount, 0  ManCount, 0 WomanCount, count(patient.ID) NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1 and DATENAME(YEAR,patient.CREATE_AT) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1 
                and patient.HEPATITISB_STATUS='01' and  patient.HCV_STATUS='01' and patient.HIV_STATUS='01' and patient.SYPHILIS_STATUS='01'
                group by center.ID) a
                group by a.CENT_ID

            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_YearNewPatientMonthlyCountInfo]
                 as
                select patient.CENT_ID ,MONTH(patient.CREATE_AT) Month , count(patient.ID) Count
                from
                 {TDMS_DataBaseName}.dbo.HD_PATIENT patient ,
                  {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center 
                where  DATENAME(YEAR,patient.CREATE_AT) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1 and patient.CENT_ID = center.id and center.STATE = 1
                group by MONTH(patient.CREATE_AT), patient.CENT_ID

            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_YearPatientCountInfo]
                 as

                select a.CENT_ID, sum(a.TotalCount) TotalCount,  sum(a.ManCount)  ManCount,sum(a.WomanCount) WomanCount, sum(a.NegativeCount) NegativeCount, sum(a.PositiveCount) PositiveCount
                from
                (select center.ID CENT_ID, count(patient.ID) TotalCount,  0  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
                from (select patient.CENT_ID, patient.ID
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
                where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1
                group by patient.ID, patient.CENT_ID) patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount,  count(patient.ID)  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
                from (select patient.CENT_ID, patient.ID
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
                where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.PATIENT_SEX = '01' and patient.STATE = 1
                group by patient.ID, patient.CENT_ID) patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount, 0  ManCount, count(patient.ID) WomanCount, 0 NegativeCount, 0 PositiveCount
                from (select patient.CENT_ID, patient.ID
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
                where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.PATIENT_SEX = '02' and patient.STATE = 1
                group by patient.ID, patient.CENT_ID) patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount, 0  ManCount, 0 WomanCount, 0 NegativeCount, count(patient.ID) PositiveCount
                from (select patient.CENT_ID, patient.ID
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
                where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and (patient.HEPATITISB_STATUS='02' OR  patient.HCV_STATUS='02' OR patient.HIV_STATUS='02' OR patient.SYPHILIS_STATUS='02') and patient.STATE = 1
                group by patient.ID, patient.CENT_ID) patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount, 0  ManCount, 0 WomanCount, count(patient.ID) NegativeCount, 0 PositiveCount
                from (select patient.CENT_ID, patient.ID
                from {TDMS_DataBaseName}.dbo.HD_PATIENT patient
                join {TDMS_DataBaseName}.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
                where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.HEPATITISB_STATUS='01' and  patient.HCV_STATUS='01' and patient.HIV_STATUS='01' and patient.SYPHILIS_STATUS='01' and patient.STATE = 1
                group by patient.ID, patient.CENT_ID) patient
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
                where center.STATE = 1
                group by center.ID) a
                group by a.CENT_ID

            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_YearPatientMonthlyCountInfo]
                 as

                SELECT  CENT_ID, Month, COUNT(ID) AS Count
                FROM      (SELECT  patient.CENT_ID, patient.ID, MONTH(treat.TRAETMENT_DATE) AS Month
                                   FROM       {TDMS_DataBaseName}.dbo.HD_PATIENT AS patient INNER JOIN
                                                      {TDMS_DataBaseName}.dbo.HD_TREATMENT AS treat ON treat.PATIENT_ID = patient.ID
                                   WHERE    (treat.STATE = 1) AND (DATENAME(YEAR, treat.TRAETMENT_DATE) = DATENAME(YEAR, GETDATE())) AND 
                                                      (patient.STATE = 1)
                                   GROUP BY patient.ID, patient.CENT_ID, MONTH(treat.TRAETMENT_DATE)) AS a
                GROUP BY CENT_ID, Month

            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_YearTreatCountInfo]
                 as

                select a.CENT_ID , sum(a.TotalCount) TotalCount,  sum(a.ManCount)  ManCount, sum(a.WomanCount) WomanCount, sum(a.NegativeCount) NegativeCount, sum(a.PositiveCount) PositiveCount
                from
                (select center.ID CENT_ID, 0 TotalCount,  COUNT(treat.ID)  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_TREATMENT treat
                join {TDMS_DataBaseName}.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and patient.PATIENT_SEX = '01'
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
                where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID,  0 TotalCount, 0 ManCount, COUNT(treat.ID)  WomanCount, 0 NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_TREATMENT treat
                join {TDMS_DataBaseName}.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and patient.PATIENT_SEX = '02'
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
                where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount,  0  ManCount, 0 WomanCount, 0 NegativeCount, COUNT(treat.ID) PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_TREATMENT treat
                join {TDMS_DataBaseName}.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and (patient.HEPATITISB_STATUS='02' OR  patient.HCV_STATUS='02' OR patient.HIV_STATUS='02' OR patient.SYPHILIS_STATUS='02')
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
                where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, 0 TotalCount,  0  ManCount, 0 WomanCount, COUNT(treat.ID) NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_TREATMENT treat
                join {TDMS_DataBaseName}.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and (patient.HEPATITISB_STATUS='01' and  patient.HCV_STATUS='01' and patient.HIV_STATUS='01' and patient.SYPHILIS_STATUS='01')
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
                where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
                group by center.ID

                UNION  ALL

                select center.ID CENT_ID, COUNT(treat.ID) TotalCount,  0  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
                from {TDMS_DataBaseName}.dbo.HD_TREATMENT treat
                join {TDMS_DataBaseName}.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID 
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
                where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
                group by center.ID) a

                group by a.CENT_ID

            ");

            migrationBuilder.Sql(@$"
                create view [dbo].[view_YearTreatMonthlyCountInfo]
                 as 
                select center.ID CENT_ID, COUNT(treat.ID) Count, MONTH(treat.TRAETMENT_DATE) MONTH
                from {TDMS_DataBaseName}.dbo.HD_TREATMENT treat
                join {TDMS_DataBaseName}.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
                where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
                group by center.ID, MONTH(treat.TRAETMENT_DATE)
            ");

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
