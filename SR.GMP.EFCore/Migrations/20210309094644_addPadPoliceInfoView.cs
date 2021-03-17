using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace SR.GMP.EFCore.Migrations
{
    public partial class addPadPoliceInfoView : Migration
    {
        private readonly IConfiguration _configuration;
        public addPadPoliceInfoView()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string TDMS_DataBaseName = _configuration["TDMS+:DataBase"];
            migrationBuilder.Sql(@$"
                CREATE VIEW [dbo].[view_PadPoliceInfo]
                AS
                SELECT   ID,PATIENT_ID, PATIENT_NAME, TREATMENT_ID, POLICE_TYPE, POLICE_TITLE, POLICE_DESCRIPTION, STATE, 
                                CREATE_USER_ID, CREATE_USER_NAME, CREATE_AT, CENT_ID, INST_ID, [PATIENT_AGE], [PATIENT_SEX], [BED_LABEL], [CLASS_NAME],[CLASS_ID],[TREAT_MEASURE],[TREAT_PROCESS]
                FROM     {TDMS_DataBaseName}.dbo.HD_TREATMENT_POLICE h
                WHERE   (STATE != 999)
            ");

            migrationBuilder.Sql(@$"
                CREATE VIEW [dbo].[view_PadPoliceFileInfo]
                AS
                SELECT   ID, POLICE_ID, FILE_CONTENT
                FROM      {TDMS_DataBaseName}.dbo.HD_TREATMENT_POLICE_FILE
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
