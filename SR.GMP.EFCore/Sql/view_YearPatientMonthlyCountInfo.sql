create view [dbo].[view_YearPatientMonthlyCountInfo]
 as

SELECT  CENT_ID, Month, COUNT(ID) AS Count
FROM      (SELECT  patient.CENT_ID, patient.ID, MONTH(treat.TRAETMENT_DATE) AS Month
                   FROM       HDIS_DEV.dbo.HD_PATIENT AS patient INNER JOIN
                                      HDIS_DEV.dbo.HD_TREATMENT AS treat ON treat.PATIENT_ID = patient.ID
                   WHERE    (treat.STATE = 1) AND (DATENAME(YEAR, treat.TRAETMENT_DATE) = DATENAME(YEAR, GETDATE())) AND 
                                      (patient.STATE = 1)
                   GROUP BY patient.ID, patient.CENT_ID, MONTH(treat.TRAETMENT_DATE)) AS a
GROUP BY CENT_ID, Month
