﻿CREATE VIEW [dbo].[view_PadPoliceFileInfo]
AS
SELECT   ID, POLICE_ID, FILE_CONTENT
FROM      HDIS_DEV.dbo.HD_TREATMENT_POLICE_FILE