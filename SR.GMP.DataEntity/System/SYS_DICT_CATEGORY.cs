using SR.GMP.DataEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SR.GMP.DataEntity.System
{
    /// <summary>
    /// 系统字典类别表
    /// </summary>
    public class SYS_DICT_CATEGORY : GuidEntityHasCreationModify
    {
        /// <summary>
        /// 父节点ID
        /// </summary>
        public Guid? P_ID { get; set; }

        /// <summary>
        /// 目录CODE
        /// </summary>
        [Required]
        [StringLength(64)]
        public string CODE { get; set; }

        /// <summary>
        /// 目录名称
        /// </summary>
        [Required]
        [StringLength(64)]
        public string NAME { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SORT_CODE { get; set; }

        /// <summary>
        /// 系统字典细表列表
        /// </summary>
        public ICollection<SYS_DICT_ITEM> DICT_ITEM_LIST { get; set; }
    }
}
