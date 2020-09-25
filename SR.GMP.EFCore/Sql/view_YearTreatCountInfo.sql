create view [dbo].[view_YearTreatCountInfo]
 as

select a.CENT_ID , sum(a.TotalCount) TotalCount,  sum(a.ManCount)  ManCount, sum(a.WomanCount) WomanCount, sum(a.NegativeCount) NegativeCount, sum(a.PositiveCount) PositiveCount
from
(select center.ID CENT_ID, 0 TotalCount,  COUNT(treat.ID)  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
from HDIS_DEV.dbo.HD_TREATMENT treat
join HDIS_DEV.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and patient.PATIENT_SEX = '01'
join HDIS_DEV.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
group by center.ID

UNION  ALL

select center.ID CENT_ID,  0 TotalCount, 0 ManCount, COUNT(treat.ID)  WomanCount, 0 NegativeCount, 0 PositiveCount
from HDIS_DEV.dbo.HD_TREATMENT treat
join HDIS_DEV.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and patient.PATIENT_SEX = '02'
join HDIS_DEV.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
group by center.ID

UNION  ALL

select center.ID CENT_ID, 0 TotalCount,  0  ManCount, 0 WomanCount, 0 NegativeCount, COUNT(treat.ID) PositiveCount
from HDIS_DEV.dbo.HD_TREATMENT treat
join HDIS_DEV.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and (patient.HEPATITISB_STATUS='02' OR  patient.HCV_STATUS='02' OR patient.HIV_STATUS='02' OR patient.SYPHILIS_STATUS='02')
join HDIS_DEV.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
group by center.ID

UNION  ALL

select center.ID CENT_ID, 0 TotalCount,  0  ManCount, 0 WomanCount, COUNT(treat.ID) NegativeCount, 0 PositiveCount
from HDIS_DEV.dbo.HD_TREATMENT treat
join HDIS_DEV.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID and (patient.HEPATITISB_STATUS='01' and  patient.HCV_STATUS='01' and patient.HIV_STATUS='01' and patient.SYPHILIS_STATUS='01')
join HDIS_DEV.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
group by center.ID

UNION  ALL

select center.ID CENT_ID, COUNT(treat.ID) TotalCount,  0  ManCount, 0 WomanCount, 0 NegativeCount, 0 PositiveCount
from HDIS_DEV.dbo.HD_TREATMENT treat
join HDIS_DEV.dbo.HD_PATIENT patient on treat.PATIENT_ID  = patient.ID 
join HDIS_DEV.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
group by center.ID) a

group by a.CENT_ID
