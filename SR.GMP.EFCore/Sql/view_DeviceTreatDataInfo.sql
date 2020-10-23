create view [dbo].[view_DeviceTreatDataInfo]
 as


select TREATMENT.PATIENT_ID, TREATMENT.ID as TREATMENT_ID, TREATMENT.CENT_ID, TREATMENT.TRAETMENT_DATE,  device_data.RECORD_TIME, device_data.DEFAULT_TREAT_TIME, IS_UP, IS_DOWN, ELAPSEDTIME, device_data.UF
from [HDIS_DEV].[dbo].[HD_PATIENT] patient
join [HDIS_DEV].[dbo].HD_TREATMENT TREATMENT
on patient.ID = TREATMENT.PATIENT_ID
join [HDIS_DEV].[dbo].HD_DEVICE_TREAT_DATA device_data
on TREATMENT.ID = device_data.TREATMENT_ID