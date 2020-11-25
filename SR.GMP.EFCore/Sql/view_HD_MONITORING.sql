create view [dbo].[view_HD_MONITORING]
as
SELECT  b.CENT_ID AS CENT_ID, f.SCHEDULING_CLASS as CLASS_ID, g.NAME as CLASS_NAME, b.ID AS PATIENT_ID, b.PATIENT_NAME, 
                   CASE b.patient_sex WHEN '04' THEN N'未知的性别' WHEN '01' THEN N'男' WHEN '02' THEN N'女' WHEN '03' THEN N'未说明的性别'
                    ELSE N'' END AS patient_sex,
                       (SELECT  CASE WHEN MONTH(b.patient_birthday) > MONTH(getdate()) OR
                                           (MONTH(b.patient_birthday) = MONTH(getdate()) AND DAY(b.patient_birthday) > DAY(getdate())) 
                                           THEN datediff(yy, b.patient_birthday, getdate()) - 1 ELSE datediff(yy, b.patient_birthday, getdate()) 
                                           END AS patient_age) AS PATIENT_AGE, e.BED_LABEL, e.DOCTOR_USER AS DOCTOR_NAME, 
                   e.UP_USER AS NURSE_NAME, a.RECORD_TIME, a.CREATE_AT, CONVERT(decimal(8, 2), a.VENOUS_PRESSURE) 
                   AS VENOUS_PRESSURE, CONVERT(decimal(8, 2), a.ARTERIAL_PRESSURE) AS ARTERIAL_PRESSURE, 
                   CONVERT(decimal(8, 2), a.TRANS_PRESSURE) AS TRANS_PRESSURE, CONVERT(decimal(8, 2), a.BLOOD_FLOW) 
                   AS BLOOD_FLOW, CONVERT(decimal(8, 2), a.RP_FLUID_FLOW) AS RP_FLUID_FLOW, CONVERT(decimal(8, 2), a.UF_RATE) 
                   AS UF_RATE, CONVERT(decimal(8, 2), a.UF) AS UF, CONVERT(decimal(8, 2), a.BREATHE) AS BREATHE, 
                   CONVERT(decimal(8, 2), a.DIALYSATE_TEMPERATURE) AS DIALYSATE_TEMPERATURE, CONVERT(decimal(8, 2), 
                   a.BODY_TEMPERATURE) AS BODY_TEMPERATURE, CONVERT(decimal(8, 2), a.SYSTOLIC_BLOOD_PRESSURE) 
                   AS SYSTOLIC_BLOOD_PRESSURE, CONVERT(decimal(8, 2), a.STRETCH_PRESSURE) AS STRETCH_PRESSURE, 
                   CONVERT(decimal(8, 2), a.HEART_RATE) AS HEART_RATE, CONVERT(decimal(8, 2), a.ELECTRICAL_CONDUCTIVITY) 
                   AS ELECTRICAL_CONDUCTIVITY, CONVERT(decimal(8, 2), a.KTV) AS ktv
FROM      HDIS_DEV.dbo.HD_PATIENT AS b  JOIN
                   HDIS_DEV.dbo.HD_TREATMENT AS e ON e.PATIENT_ID = b.ID INNER JOIN
                   HDIS_DEV.dbo.HD_DEVICE_TREAT_DATA AS a ON a.TREATMENT_ID = e.ID INNER JOIN
				   HDIS_DEV.dbo.HD_SCHEDULING as f on e.SCHEDULING_ID = f.ID join
				   HDIS_DEV.dbo.HD_SCHEDULING_CLASS as g on g.ID = f.SCHEDULING_CLASS
