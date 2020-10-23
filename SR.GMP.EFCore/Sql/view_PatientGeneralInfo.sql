/****** SSMS 的 SelectTopNRows 命令的脚本  ******/
create view [dbo].[view_PatientGeneralInfo]
 as
SELECT patient.ID as PATIENT_ID, patient.CENT_ID, patient.PATIENT_NAME, patient.DIALYSIS_ID, treatment.BED_LABEL , sche_class.NAME as CLASS_NAME,

case patient.patient_sex when '04' then N'未知的性别' when '01' then N'男' when '02' then N'女' when '03' then N'未说明的性别' else N'' end PATIENT_SEX,
(SELECT CASE WHEN  MONTH(patient.patient_birthday)>MONTH(getdate())
OR (MONTH(patient.patient_birthday)=MONTH(getdate())
AND DAY(patient.patient_birthday)>DAY(getdate()))
THEN datediff(yy,patient.patient_birthday,getdate())-1 
else datediff(yy,patient.patient_birthday,getdate()) end patient_age ) as PATIENT_AGE,

case  when patient.HEPATITISB_STATUS='02' OR  patient.HCV_STATUS='02' OR patient.HIV_STATUS='02' OR patient.SYPHILIS_STATUS='02' then N'阳性患者' 
when patient.HEPATITISB_STATUS='01' and  patient.HCV_STATUS='01' and patient.HIV_STATUS='01' and patient.SYPHILIS_STATUS='01' then N'阴性患者'
else '未检患者' end PATIENT_TYPE,

patient.TREATMENT_START_DATE ,

case patient.MEDICAL_TYPE when '01' then N'医保' when '02' then N'自费' else N'' end MEDICAL_TYPE,
 treatment.DOCTOR_USER as DOCTOR_NAME,
 treatment.UP_USER as NURSE_NAME,
 treatment.TRAETMENT_DATE

  FROM [HDIS_DEV].[dbo].[HD_PATIENT] patient
  join  [HDIS_DEV].[dbo].HD_TREATMENT  treatment
  on patient.ID = treatment.PATIENT_ID
  join [HDIS_DEV].[dbo].HD_SCHEDULING sche
  on sche.ID = treatment.SCHEDULING_ID
  join [HDIS_DEV].[dbo].HD_SCHEDULING_CLASS sche_class
  on sche.SCHEDULING_CLASS = sche_class.ID

 