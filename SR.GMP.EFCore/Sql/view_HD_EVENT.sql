create view [dbo].[view_HD_EVENT]
as
select patient.id as PATIENT_ID,  patient.PATIENT_NAME AS PATIENT_NAME , 
patient.CENT_ID as CENT_ID,
 case patient.patient_sex when '04' then N'未知的性别' when '01' then N'男' when '02' then N'女' when '03' then N'未说明的性别' else N'' end patient_sex  ,
(SELECT CASE WHEN  MONTH(patient.patient_birthday)>MONTH(getdate())
OR (MONTH(patient.patient_birthday)=MONTH(getdate())
AND DAY(patient.patient_birthday)>DAY(getdate()))
THEN datediff(yy,patient.patient_birthday,getdate())-1 
else datediff(yy,patient.patient_birthday,getdate()) end patient_age ) as PATIENT_AGE, 
sche.BED_LABEL as BED_LABEL,
treat.DOCTOR_USER as DOCTOR_NAME,
treat.UP_USER  as NURSE_NAME,
sche.SCHEDULING_CLASS as CLASS_ID,
sche_class.NAME as CLASS_NAME,
dia_event.EVENT_NAME,
dia_event.EVENT_NAME AS EVENT_CODE  ,
dia_event.RECORD_TIME,
dia_event.CREATE_AT 
from  HDIS_DEV.dbo.HD_PATIENT  patient
join  HDIS_DEV.dbo.HD_SCHEDULING sche   on  patient.id = sche.PATIENT_ID
join HDIS_DEV.dbo.HD_SCHEDULING_CLASS sche_class on sche_class.ID = sche.SCHEDULING_CLASS
join   HDIS_DEV.dbo.HD_TREATMENT treat on  sche.ID = treat.SCHEDULING_ID
join  HDIS_DEV.dbo.HD_DIALYSIS_EVENT dia_event on treat.ID = dia_event.TREATMENT_ID
where [EVENT_RESULT] is null
