create view [dbo].[view_YearNewPatientMonthlyCountInfo]
 as

select patient.CENT_ID ,MONTH(patient.CREATE_AT) Month , count(patient.ID) Count
from
 HDIS_DEV.dbo.HD_PATIENT patient ,
  HDIS_DEV.dbo.SYS_INST_CENTER center 
where  DATENAME(YEAR,patient.CREATE_AT) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1 and patient.CENT_ID = center.id and center.STATE = 1
group by MONTH(patient.CREATE_AT), patient.CENT_ID
