using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.DataEntity.DictEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.Dictionary
{
    public class GMP_EVENT_ITEM : Entity<int>
    {
        public GMP_EVENT_ITEM()
        {
            STATE = StateEnum.启用;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get => base.ID; set => base.ID = value; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [StringLength(64)]
        public string ITEM_NAME { get; set; }

        /// <summary>
        /// 项目Code
        /// </summary>
        [Required]
        [StringLength(64)]
        public string ITEM_CODE { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? SORT_CODE { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public StateEnum STATE { get; set; }
    }
}
