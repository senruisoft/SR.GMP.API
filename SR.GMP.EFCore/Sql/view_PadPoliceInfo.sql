﻿CREATE VIEW [dbo].[view_PadPoliceInfo]
AS
SELECT   ID,PATIENT_ID, PATIENT_NAME, TREATMENT_ID, POLICE_TYPE, POLICE_TITLE, POLICE_DESCRIPTION, STATE, 
                CREATE_USER_ID, CREATE_USER_NAME, CREATE_AT, CENT_ID, INST_ID, [PATIENT_AGE], [PATIENT_SEX], [BED_LABEL], [CLASS_NAME],[CLASS_ID],[TREAT_MEASURE],[TREAT_PROCESS]
FROM      HDIS_DEV.dbo.HD_TREATMENT_POLICE h
WHERE   (STATE != 999)