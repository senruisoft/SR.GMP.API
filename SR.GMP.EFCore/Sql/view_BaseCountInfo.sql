create view [dbo].[view_BaseCountInfo]
as
select CENT_ID, SUM(PatientCount) as PatientCount, SUM(NurseCount) as NurseCount, SUM(DoctorCount) as DoctorCount,SUM(BedCount) as BedCount
from  
(SELECT USER_CENTER.CENTER_ID as CENT_ID,
0 as PatientCount,0 as BedCount  ,count(*) as DoctorCount ,0 as NurseCount 
FROM  HDIS_DEV.dbo.SYS_USER as sys_user
  join HDIS_DEV.dbo.SYS_USER_CENTER as USER_CENTER  on  sys_user.ID = USER_CENTER.USER_ID
  join  HDIS_DEV.dbo.SYS_INST_CENTER center on USER_CENTER.CENTER_ID  = center.id
WHERE sys_user.STATE = 1 and sys_user.TYPE_CODE = '01' and center.STATE = 1
GROUP BY USER_CENTER.CENTER_ID

union all

SELECT USER_CENTER.CENTER_ID as CENT_ID,
0 as PatientCount,0 as BedCount  ,0 as DoctorCount ,count(*) as NurseCount 
FROM  HDIS_DEV.dbo.SYS_USER as sys_user
  join HDIS_DEV.dbo.SYS_USER_CENTER as USER_CENTER  on  sys_user.ID = USER_CENTER.USER_ID
  join  HDIS_DEV.dbo.SYS_INST_CENTER center on USER_CENTER.CENTER_ID  = center.id
WHERE sys_user.STATE = 1 and sys_user.TYPE_CODE = '02' and center.STATE = 1
GROUP BY USER_CENTER.CENTER_ID

union all

select  CENT_ID ,
count(*) as PatientCount ,0 as BedCount  ,0 as DoctorCount ,0 as NurseCount  
 from  HDIS_DEV.dbo.HD_PATIENT  patient
 join  HDIS_DEV.dbo.SYS_INST_CENTER center on patient.CENT_ID  = center.id
 where patient.STATE = 1 and center.STATE = 1
 GROUP BY CENT_ID

 union all

 select CENT_ID,
0 as PatientCount ,count(*) as BedCount ,0 as DoctorCount ,0 as NurseCount  
  from  HDIS_DEV.dbo.HD_BED bed
  join  HDIS_DEV.dbo.SYS_INST_CENTER center on bed.CENT_ID  = center.id
   where bed.STATE = 1 and center.STATE = 1
group  by CENT_ID ) a
group by a.CENT_ID
