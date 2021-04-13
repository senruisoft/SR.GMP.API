using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace SR.GMP.EFCore.Migrations
{
    public partial class updatePadPoliceInfoView : Migration
    {
        private readonly IConfiguration _configuration;
        public updatePadPoliceInfoView()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string TDMS_DataBaseName = _configuration["TDMS+:DataBase"];
            migrationBuilder.Sql(@$"
                    alter view dbo.View_PadPoliceInfo
                    as 
                    SELECT   ID, PATIENT_ID, PATIENT_NAME, TREATMENT_ID, POLICE_TYPE, POLICE_TITLE, POLICE_DESCRIPTION, [STATE], 
                                    CREATE_USER_ID, CREATE_USER_NAME, CREATE_AT, CENT_ID, INST_ID, PATIENT_AGE, PATIENT_SEX, BED_LABEL, 
                                    CLASS_NAME, CLASS_ID, TREAT_MEASURE, TREAT_PROCESS, [PRIORITY], REMARK
                    FROM      {TDMS_DataBaseName}.dbo.HD_TREATMENT_POLICE 
                    WHERE   (STATE <> 999)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
