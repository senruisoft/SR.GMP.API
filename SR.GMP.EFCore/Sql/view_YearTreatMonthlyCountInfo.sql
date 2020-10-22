create view [dbo].[view_YearTreatMonthlyCountInfo]
 as 


select center.ID CENT_ID, COUNT(treat.ID) Count, MONTH(treat.TRAETMENT_DATE) MONTH
from HDIS_DEV.dbo.HD_TREATMENT treat
join HDIS_DEV.dbo.SYS_INST_CENTER center on treat.CENT_ID = center.ID
where treat.STATE = 1 and center.STATE = 1 and DATENAME(YEAR,treat.TRAETMENT_DATE) = DATENAME(YEAR,GETDATE())
group by center.ID, MONTH(treat.TRAETMENT_DATE)
