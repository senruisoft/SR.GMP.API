create view [dbo].[view_EquipmentCountInfo]
as

SELECT equipment.CENT_ID, dict.EquipmentName, dict.EquipmentCode, count(*) EquipmentCount
  FROM  [HDIS_DEV].[dbo].HD_EQUIPMENT  equipment
   JOIN [HDIS_DEV].[dbo].SYS_INST_CENTER center  ON  equipment.CENT_ID = center.id
  join (select item.NAME EquipmentName, item.CODE EquipmentCode from
   [HDIS_DEV].[dbo].[SYS_DICT_CATEGORY] category, [HDIS_DEV].[dbo].[SYS_DICT_ITEM] item
   where category.CODE = 'CV0004_0008_0001' and category.STATE = 1 and item.CATEGORY_ID = category.ID and item.STATE = 1) dict
   on dict.EquipmentCode = equipment.MODEL_CODE
   where equipment.STATE = 1 and center.STATE = 1
   group by equipment.CENT_ID, dict.EquipmentCode, dict.EquipmentName
