using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.DataEntity.DictEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.System
{
    /// <summary>
    /// 中心信息表
    /// </summary>
    public class SYS_INST_CENTER : GuidEntityHasCreationModify
    {
        public SYS_INST_CENTER ()
        {
            TYPE_CODE = CenterTypeEnum.血透;
        }

        /// <summary>
        /// 机构ID
        /// </summary>
        public Guid INST_ID { get; set; }
        [ForeignKey("INST_ID")]
        public virtual SYS_INST INST { get; set; }

        /// <summary>
        /// 中心CODE
        /// </summary>
        [Required]
        [StringLength(128)]
        public string CODE { get; set; }

        /// <summary>
        /// 中心名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string NAME { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [StringLength(128)]
        public string SORT_CODE { get; set; }

        /// <summary>
        /// 拼音
        /// </summary>
        [StringLength(50)]
        public string PY { get; set; }

        /// <summary>
        /// 描述备注
        /// </summary>
        [StringLength(256)]
        public string CENT_DESC { get; set; }

        /// <summary>
        /// 类型编码
        /// </summary>
        public CenterTypeEnum TYPE_CODE { get; set; }
    }
}
