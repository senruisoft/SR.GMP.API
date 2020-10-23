create view [dbo].[view_TreatOrderInfo]
 as 
select TREATMENT.PATIENT_ID, TREATMENT.ID as TREATMENT_ID, TREATMENT.CENT_ID, TREATMENT.TRAETMENT_DATE, 
	treat_order.ORDER_NAME, 
 cast (  case	treat_order.ORDER_STATE when '07' then 1 else 0  end  as bit) IS_EXECED ,
  
	treat_order.SUBMIT_USER, treat_order.EXEC_USER, dict.NAME as EXEC_METHOD
 
from [HDIS_DEV].[dbo].[HD_PATIENT] patient
join [HDIS_DEV].[dbo].HD_TREATMENT TREATMENT
on patient.ID = TREATMENT.PATIENT_ID
join [HDIS_DEV].[dbo].[HD_TREATMENT_ORDER] treat_order
on treat_order.TREATMENT_ID = TREATMENT.ID
left join (select  dict.NAME,dict.CODE  from
[HDIS_DEV].[dbo].[SYS_DICT_CATEGORY] category
join [HDIS_DEV].[dbo].[SYS_DICT_ITEM] dict
on category.ID = dict.CATEGORY_ID
where category.CODE = 'CV0002_0020') dict
on treat_order.EXEC_METHOD = dict.CODE
where treat_order.STATE = 1