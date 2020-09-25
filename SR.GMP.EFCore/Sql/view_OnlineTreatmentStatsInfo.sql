create view [dbo].[view_OnlineTreatmentStatsInfo]
 as 
SELECT  sche.CENT_ID, sche.SCHEDULING_CLASS AS ClassID, sche_class.NAME AS ClassName, sche_class.SORTS AS SortNum, 
                   COUNT(sche.ID) AS TotalCount, COUNT(treat.ID) AS TreatingCount,  COUNT(treat_c.ID) AS CompleteCount
FROM      HDIS_DEV.dbo.HD_SCHEDULING AS sche  JOIN
                   HDIS_DEV.dbo.SYS_INST_CENTER AS center ON sche.CENT_ID = center.ID  JOIN
                   HDIS_DEV.dbo.HD_SCHEDULING_CLASS AS sche_class ON sche.SCHEDULING_CLASS = sche_class.ID AND 
                   sche.CENT_ID = center.ID LEFT  JOIN
                   HDIS_DEV.dbo.HD_TREATMENT AS treat ON treat.SCHEDULING_ID = sche.ID  and treat.DOWN_USER_ID is null

				   LEFT  JOIN
                   HDIS_DEV.dbo.HD_TREATMENT AS treat_c ON treat_c.SCHEDULING_ID = sche.ID and treat_c.DOWN_USER_ID is not null
where sche.STATE = 1 and center.STATE = 1 and [TREAT_DATE] = CONVERT(varchar,GETDATE(),23) 
group by sche.CENT_ID, sche.SCHEDULING_CLASS, sche_class.NAME, sche_class.SORTS

