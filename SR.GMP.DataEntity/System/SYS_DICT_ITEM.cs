using SR.GMP.DataEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.System
{
    /// <summary>
    /// 系统字典细表
    /// </summary>
    public class SYS_DICT_ITEM : GuidEntityHasCreationModify
    {
        /// <summary>
        /// 字典类别ID
        /// </summary>
        public Guid CATEGORY_ID { get; set; }
        [ForeignKey("CATEGORY_ID")]
        public virtual SYS_DICT_CATEGORY DICT_CATEGORY { get; set; }

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
        /// 名称拼音
        /// </summary>
        [StringLength(64)]
        public string PY { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SORT_CODE { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(64)]
        public string DESC { get; set; }
    }
}
