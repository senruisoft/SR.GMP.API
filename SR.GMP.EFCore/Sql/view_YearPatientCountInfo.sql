create view [dbo].[view_YearPatientCountInfo]
 as

select a.CENT_ID, sum(a.TotalCount) TotalCount,  sum(a.ManCount)  ManCount,sum(a.WomanCount) WomanCount, sum(a.NegativeCount) NegativeCount, sum(a.PositiveCount) PositiveCount
from
(select center.ID CENT_ID, count(patient.ID) TotalCount,  0  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
from (select patient.CENT_ID, patient.ID
from HDIS_DEV.dbo.HD_PATIENT patient
join HDIS_DEV.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.STATE = 1
group by patient.ID, patient.CENT_ID) patient
join HDIS_DEV.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
where center.STATE = 1
group by center.ID

UNION  ALL

select center.ID CENT_ID, 0 TotalCount,  count(patient.ID)  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
from (select patient.CENT_ID, patient.ID
from HDIS_DEV.dbo.HD_PATIENT patient
join HDIS_DEV.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.PATIENT_SEX = '01' and patient.STATE = 1
group by patient.ID, patient.CENT_ID) patient
join HDIS_DEV.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
where center.STATE = 1
group by center.ID

UNION  ALL

select center.ID CENT_ID, 0 TotalCount, 0  ManCount, count(patient.ID) WomanCount, 0 NegativeCount, 0 PositiveCount
from (select patient.CENT_ID, patient.ID
from HDIS_DEV.dbo.HD_PATIENT patient
join HDIS_DEV.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.PATIENT_SEX = '02' and patient.STATE = 1
group by patient.ID, patient.CENT_ID) patient
join HDIS_DEV.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
where center.STATE = 1
group by center.ID

UNION  ALL

select center.ID CENT_ID, 0 TotalCount, 0  ManCount, 0 WomanCount, 0 NegativeCount, count(patient.ID) PositiveCount
from (select patient.CENT_ID, patient.ID
from HDIS_DEV.dbo.HD_PATIENT patient
join HDIS_DEV.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and (patient.HEPATITISB_STATUS='02' OR  patient.HCV_STATUS='02' OR patient.HIV_STATUS='02' OR patient.SYPHILIS_STATUS='02') and patient.STATE = 1
group by patient.ID, patient.CENT_ID) patient
join HDIS_DEV.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
where center.STATE = 1
group by center.ID

UNION  ALL

select center.ID CENT_ID, 0 TotalCount, 0  ManCount, 0 WomanCount, count(patient.ID) NegativeCount, 0 PositiveCount
from (select patient.CENT_ID, patient.ID
from HDIS_DEV.dbo.HD_PATIENT patient
join HDIS_DEV.dbo.HD_TREATMENT treat on treat.PATIENT_ID  = patient.ID
where treat.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE()) and patient.HEPATITISB_STATUS='01' and  patient.HCV_STATUS='01' and patient.HIV_STATUS='01' and patient.SYPHILIS_STATUS='01' and patient.STATE = 1
group by patient.ID, patient.CENT_ID) patient
join HDIS_DEV.dbo.SYS_INST_CENTER center on patient.CENT_ID = center.ID
where center.STATE = 1
group by center.ID) a
group by a.CENT_ID
