using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SR.GMP.EFCore.Migrations
{
    public partial class _1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TREAMENT_INFO",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_RECORD_TIME",
                table: "GMP_ALARM_RECORD",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ALARM_INFO",
                table: "GMP_ALARM_RECORD",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "BED_LABEL",
                table: "GMP_ALARM_RECORD",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DOCTOR_NAME",
                table: "GMP_ALARM_RECORD",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NURSE_NAME",
                table: "GMP_ALARM_RECORD",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PATIENT_AGE",
                table: "GMP_ALARM_RECORD",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PATIENT_NAME",
                table: "GMP_ALARM_RECORD",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PATIENT_SEX",
                table: "GMP_ALARM_RECORD",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BED_LABEL",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.DropColumn(
                name: "DOCTOR_NAME",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.DropColumn(
                name: "NURSE_NAME",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.DropColumn(
                name: "PATIENT_AGE",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.DropColumn(
                name: "PATIENT_NAME",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.DropColumn(
                name: "PATIENT_SEX",
                table: "GMP_ALARM_RECORD");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DATA_RECORD_TIME",
                table: "GMP_ALARM_RECORD",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ALARM_INFO",
                table: "GMP_ALARM_RECORD",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TREAMENT_INFO",
                table: "GMP_ALARM_RECORD",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
