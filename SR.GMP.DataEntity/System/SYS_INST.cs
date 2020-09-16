using SR.GMP.DataEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.System
{
    /// <summary>
    /// 机构信息表
    /// </summary>
    public class SYS_INST : GuidEntityHasCreationModify
    {
        /// <summary>
        /// 机构编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CODE { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        /// <summary>
        /// 机构地址
        /// </summary>
        [StringLength(128)]
        public string ADDRESS { get; set; }

    }
}
